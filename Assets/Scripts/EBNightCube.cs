using UnityEngine;

public class EBNightCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.TriggerNightCubePickedUp();
            Destroy(gameObject);
        }
    }
}
