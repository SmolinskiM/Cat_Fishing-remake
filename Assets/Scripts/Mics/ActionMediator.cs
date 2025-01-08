using UnityEngine;

public class ActionMediator : MonoBehaviour
{
    private bool canPerformAction = true;

    // Zarz¹dza stanem akcji i powiadamia inne obiekty
    public bool IsActionAllowed()
    {
        return canPerformAction;
    }

    public void SetActionAllowed(bool allowed)
    {
        canPerformAction = allowed;
    }
}