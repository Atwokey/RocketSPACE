using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameManager _gameManager;

    private RocketInput _rocketInput; 

    private void Awake()
    {
        _rocketInput = new RocketInput();

        _rocketInput.UI.Pause.performed += ctx => _pauseScreen.Open();
    }


    private void OnEnable()
    {
        _rocketInput.Enable();
    }

    private void OnDisable()
    {
        _rocketInput.Disable();
    }

    private void Update()
    {
        if (_gameManager.Rocket.Movement == null)
            return;

        int value = (_rocketInput.Rocket.Move.ReadValue<float>() > 0.1f) ? 1 : -1;

        if (_gameManager.Rocket.Movement.enabled)
            _gameManager.Rocket.Movement.Move(value);
        else
            _gameManager.Rocket.Movement.enabled = (value > 0) ? true : false;
    }

}
