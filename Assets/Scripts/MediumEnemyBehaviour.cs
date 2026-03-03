using UnityEngine;

public class MediumEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waveManager.PlayerDied();
        }
    }
}
