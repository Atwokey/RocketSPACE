using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        Application.Quit();
    }
}
