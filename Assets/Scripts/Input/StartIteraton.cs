using UnityEngine.InputSystem;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif

public class StartIteration : IInputInteraction
{
    private static bool IsFirstClickReleased = false;

    static StartIteration()
    {
        InputSystem.RegisterInteraction<StartIteration>();
    }

    public static void ResetStartIteraton()
    {
        IsFirstClickReleased = false;
    }

    public void Process(ref InputInteractionContext context)
    {
        if (IsFirstClickReleased)
        {
            context.Canceled();
        }
        else
        {
            IsFirstClickReleased = true;
            context.Performed();
        }
    }

    public void Reset()
    {
    }
}