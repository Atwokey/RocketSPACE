using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAngleRotation;
    [SerializeField] private float _stepRotation;
    [SerializeField] private RocketEffectControl _effectControl;
    [SerializeField] private RocketAudioManager _audioManager;
    [SerializeField] private AudioClip _clip;

    private float _currentAngle;

    private void Start()
    {
        _currentAngle = _maxAngleRotation / 2;
    }

    public void Move(int value)
    {
        ControlMovementEffects(value);
        ChangeAngle(value * _stepRotation);
        transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * _currentAngle) * _speed * Time.deltaTime, Mathf.Sin(Mathf.Deg2Rad * _currentAngle) * _speed * Time.deltaTime);
    }

    private void ControlMovementEffects(int value)
    {
        if(value > 0)
        {
            _audioManager.PlayAudio(_clip);
            _effectControl.PlayEffect();
        }
        else
        {
            _audioManager.StopAudio();
            _effectControl.StopEffect();
        }
    }

    private void ChangeAngle(float step)
    {
        _currentAngle += step * Time.deltaTime;

        if (Mathf.Abs(_currentAngle) >= _maxAngleRotation)
            _currentAngle = (_currentAngle < 0) ? -_maxAngleRotation : _maxAngleRotation;

        Rotate();
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
    }
}
