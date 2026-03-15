using System;
using UnityEngine;

public class EBCat : MonoBehaviour
{
    public GameObject removeToo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.TriggerCatPickedUp();
            Destroy(gameObject);
            Destroy(removeToo);
        }
    }
}
