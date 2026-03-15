using System;
using UnityEngine;

public class EBCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.TriggerCoinPickedUp();
            Destroy(gameObject);
        }
    }
}
