using UnityEngine;

public class ActionMediator : MonoBehaviour
{
    private bool canPerformAction = true;

    public bool IsActionAllowed()
    {
        return canPerformAction;
    }

    public void SetActionAllowed(bool allowed)
    {
        canPerformAction = allowed;
    }
}