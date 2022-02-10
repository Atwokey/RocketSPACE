using UnityEngine;
using UnityEngine.Events;

public class PauseScreen : Screen
{
    public bool IsPaused { get; private set; }

    protected override void OnButtonClick()
    {
        Close();
    }

    public override void Open()
    {
        if (IsPaused)
        {
            Close();
            return;
        }

        IsPaused = true;
        base.Open();
    }

    public override void Close()
    {
        IsPaused = false;
        base.Close();
    }
}