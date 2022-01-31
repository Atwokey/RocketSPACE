using UnityEngine;

public class RocketEffectControl : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;

    private void Start()
    {
        StopEffect();
    }
    public void PlayEffect()
    {
        if(!_particle.isPlaying)
            _particle.Play();
    }

    public void StopEffect()
    {
        if (_particle.isPlaying)
            _particle.Stop();
    }
}
