﻿using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingRod : SingletoneMonobehaviour<FishingRod>
{
    [SerializeField] private Hook hook;
    [SerializeField] private Transform pointRod;
    [SerializeField] private Transform pointHook;
    [SerializeField] private Rigidbody2D hookRb;

    [SerializeField] private ActionMediator mediator;

    private bool isThrowIsCharge;
    private float pressTimeStart;
    private float maxDistance = 70;
    private LineRenderer lr;

    private const float MAX_POWER = 5;
    private const float MIN_DISTANCE = 4;

    // Properties
    public float MaxPower { get { return MAX_POWER; } }
    //public bool IsThrowable { get { return isThrowable; } }
    public float PressTimeStart { get { return pressTimeStart; } }
    public float MaxDistance { get { return maxDistance; } set { maxDistance = value; } }
    public Hook Hook { get { return hook; } }

    public ActionMediator Mediator { get { return mediator; } }

    // Event for throwable state changes
    public event Action<bool> OnThrowableChanged;

    private PlayerAction throwHook;

    private new void Awake()
    {
        hook.onHookBackToRodFree += HookBackToRod;
        // Initialize components
        lr = GetComponent<LineRenderer>();
        throwHook = new PlayerAction();

        // Enable the input action and bind methods
        throwHook.Rod.ThrowHook.Enable();
        throwHook.Rod.ThrowHook.started += OnThrowStarted;
        throwHook.Rod.ThrowHook.canceled += OnThrowReleased;
    }

    private void Start()
    {
        hook.IsHookOnRod = true;
    }

    private void LateUpdate()
    {
        // Draw the rope between rod and hook
        DrawRope();
    }

    #region Hook Throwing Logic

    private void OnThrowStarted(InputAction.CallbackContext context)
    {
        if(!mediator.IsActionAllowed())
        {
            return;
        }

        // Start tracking press time when throwing begins
        if (!hook.IsHookOnRod)
        {
            return;
        }

        mediator.SetActionAllowed(false);
        isThrowIsCharge = true;
        pressTimeStart = Time.time;
        OnThrowableChanged?.Invoke(true);  // Show power bar
    }

    private void OnThrowReleased(InputAction.CallbackContext context)
    {
        if(!isThrowIsCharge && !mediator.IsActionAllowed())
        {
            return;
        }
        // Handle throw logic when button is released
        if (!hook.IsHookOnRod)
        {
            return;
        }

        float power = Time.time - pressTimeStart;

        // Ensure bait size is valid
        if (hook.Bait.BaitSize == 0)
        {
            hook.Bait.ChangeSizeBait(hook.Bait.BaitSizeStart);
        }

        ThrowHook(power);

        // Reset states
        pressTimeStart = 0;
        isThrowIsCharge = false;
        hook.IsHookOnRod = false;

        OnThrowableChanged?.Invoke(false); // Hide power bar
    }

    private void ThrowHook(float power)
    {
        // Limit power to max value
        if (power > MAX_POWER)
        {
            power = MAX_POWER;
        }

        // Set the joint distance based on power
        hook.Joint.distance = Mathf.Clamp((power / MAX_POWER) * maxDistance, MIN_DISTANCE, maxDistance);

        // Apply force to the hook
        hookRb.gravityScale = 1;
        hookRb.AddForce(new Vector2(300, 100) * power);
    }

    private void HookBackToRod()
    {
        mediator.SetActionAllowed(true);
    }

    #endregion

    #region Rope Drawing Logic

    private void DrawRope()
    {
        // Set the positions of the rope's line renderer
        lr.SetPosition(0, pointRod.position);
        lr.SetPosition(1, pointHook.position);
    }

    #endregion
}
