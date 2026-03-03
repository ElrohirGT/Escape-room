using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _originalDuration; 
    [SerializeField] private float duration;
    private bool _alreadyInvoked;

    public float Duration
    {
        get => duration;
        set {
        _originalDuration = value;
        duration = value;
    }
    }
    
    public event EventHandler Done; 

    private void Start()
    {
        _originalDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration <= 0 && !_alreadyInvoked)
        {
            Done?.Invoke(this, EventArgs.Empty);
            _alreadyInvoked = true;
        }
        else
        {
            duration -= Time.deltaTime;
        }
    }
    
    public void Reset()
    {
        duration = _originalDuration;
        _alreadyInvoked = false;
    }
}
