using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CircleCollider2D))]
public class Battery : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Animator _animator;
    private CircleCollider2D _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CircleCollider2D>();
    }

    public void Disappear()
    {
        _collider.enabled = false;
        _animator.Play("BatteryDisappear");
        _audioSource.Play();
        enabled = false;
    }
}
