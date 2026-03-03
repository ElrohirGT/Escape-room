using System;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Timer))]
public class BulletBehaviour : MonoBehaviour
{
    public WaveManager manager;
    public BulletPool pool;
    public float speed;

    private Timer _lifeTimer;

    private void Awake()
    {
        _lifeTimer = GetComponent<Timer>();
        Assert.IsNotNull(_lifeTimer, "_lifeTimer != null");
        
        _lifeTimer.Done += LifeTimerOnDone;
    }

    private void LifeTimerOnDone(object sender, EventArgs e)
    {
        pool.Return(gameObject);
    }

    private void Update()
    {
        var newPosition = transform.position + transform.forward * (speed * Time.deltaTime);
        transform.SetPositionAndRotation(newPosition, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.tag);
        if (other.CompareTag("Player"))
        {
            manager.PlayerDied();
            pool.Return(gameObject);
        }
    }
}
