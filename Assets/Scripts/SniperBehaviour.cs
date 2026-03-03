using System;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Timer), typeof(Animator))]
public class SniperBehaviour : MonoBehaviour
{
    private static readonly int Fire = Animator.StringToHash("fire");
    [SerializeField] private Player player;
    
    [SerializeField] private BulletPool bulletPool;
    private Timer _fireTimer;

    private bool _canFire ;
    
    private Vector3 PlayerFace => player.transform.position + Vector3.up;

    private Animator _animator;

    private void Awake()
    {
        _fireTimer = GetComponent<Timer>();
        Assert.IsNotNull(_fireTimer, "fireTimer != null");
        _fireTimer.Done += FireTimerOnDone;

        _animator = GetComponent<Animator>();
        Assert.IsNotNull(_animator, "_animator != null");
    }

    private void FireTimerOnDone(object sender, EventArgs e)
    {
        _canFire = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Assert.IsNotNull(bulletPool, "bulletPool != null");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerFace);
        if (_canFire)
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        _canFire = false;
        
        _animator.SetTrigger(Fire);
        
        var bullet = bulletPool.Aquire();
        bullet.transform.position = transform.position + Vector3.up;
        // Predict player movement a little
        bullet.transform.LookAt(PlayerFace + player.transform.forward * 0.3f);
        
        _fireTimer.Reset();
        // _animator.SetBool(ShouldFire, false);
    }
}
