using UnityEngine;

[RequireComponent(typeof(Rocket))]
public class RocketCollisionHandler : MonoBehaviour
{
    private Rocket _rocket;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
            _rocket.Die();

        if (collision.TryGetComponent(out Battery battery))
        {
            _rocket.Collect();
            battery.Disappear();
        }

        if (collision.TryGetComponent(out TargetPoint target))
            target.LoadScene(); 
    }
}
