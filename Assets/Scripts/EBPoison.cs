using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EBPoison : MonoBehaviour
{
    private Vector3 _initial;
    private Vector3 _target;

    private Vector3 _currentTarget;

    private float _progress = 0;
    [SerializeField]
    private float hoverSpeed = 1;
    
    private void Start()
    {
        _initial = transform.localPosition;
        _target = transform.localPosition + Vector3.up;
        _currentTarget = _target;
    }

    private void Update()
    {
        var current = transform.localPosition;
        if (Vector3.Distance(_currentTarget, current) < 0.01) // Switch targets
        {
            _currentTarget = _currentTarget.Equals(_target) ? _initial : _target;
            _progress = 0;
        }

        transform.localPosition = Vector3.SlerpUnclamped(current, _currentTarget, _progress);
        _progress = Mathf.Clamp(_progress + (Time.deltaTime * hoverSpeed) , 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var damage = Random.Range(5, 16);
            EventBus.TriggerDamageTaken(damage);
            Destroy(gameObject);
        }
    }
}
