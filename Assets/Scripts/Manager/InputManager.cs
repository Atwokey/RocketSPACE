using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private RocketMovement _rocketMovement;
    [SerializeField] private PauseScreen _pauseScreen;

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

    private void Start()
    {
        _rocketMovement.enabled = false;
    }

    private void Update()
    {
        if (_rocketMovement == null)
            return;

        int value = (_rocketInput.Rocket.Move.ReadValue<float>() > 0.1f) ? 1 : -1;
        
        if (_rocketMovement.enabled)
            _rocketMovement.Move(value);
        else
            _rocketMovement.enabled = (value > 0) ? true : false;
    }

}
