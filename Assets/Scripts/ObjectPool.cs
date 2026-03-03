using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject template;
    [SerializeField] private int quantity;

    private List<GameObject> pool = new();

    private void Awake(){
        for (var i = 0; i < quantity; i++)
        {
            var obj = Instantiate(template, transform);
            InitializeObject(obj);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    protected abstract void InitializeObject(GameObject obj);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Assert.IsNotNull(template, "template != null");
    }

    public GameObject Aquire()
    {
        if (pool.Count == 0)
        {
            pool.Add(Instantiate(template, transform));
        }

        var item = pool[0];
        pool.RemoveAt(0);
        item.SetActive(true);
        return item;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Add(obj);
    }
}
