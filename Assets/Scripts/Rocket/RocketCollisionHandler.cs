using UnityEngine;

[RequireComponent(typeof(Rocket))]
[RequireComponent(typeof(SpriteRenderer))]
public class RocketCollisionHandler : MonoBehaviour
{
    private Rocket _rocket;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();
        _renderer = GetComponent<SpriteRenderer>();
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

        if (collision.TryGetComponent(out FinishPoint finish))
        {
            _renderer.color = Color.clear;
            finish.LoadScene();
        }        
    }
}
