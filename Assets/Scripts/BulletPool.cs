using UnityEngine;
using UnityEngine.Assertions;

public class BulletPool : ObjectPool
{

    [SerializeField] private WaveManager manager;
    
    protected override void InitializeObject(GameObject obj)
    {
        var bullet = obj.GetComponent<BulletBehaviour>();
        Assert.IsNotNull(bullet, "bullet != null");

        bullet.manager = manager;
        bullet.pool = this;
    }
}