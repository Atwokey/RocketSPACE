using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Point[] _points;

    private Point _target;
    private int _currentIndexPoint;

    private void Start()
    {
        _target = _points[_currentIndexPoint];
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if (transform.position == _target.transform.position)
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        _currentIndexPoint++;

        if (_currentIndexPoint >= _points.Length)
            _currentIndexPoint = 0;

        _target = _points[_currentIndexPoint];
    }
}
