using UnityEngine;
using UnityEngine.Events;

public class PauseScreen : Screen
{
    public event UnityAction ResumeButtonClick;
    protected override void OnButtonClick()
    {
        ResumeButtonClick?.Invoke();
    }
}