using UnityEngine;

public class EBLightCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.TriggerLightCubePickedUp();
            Destroy(gameObject);
        }
    }
}
