using UnityEngine;
using UnityEngine.AI;
using Assert = UnityEngine.Assertions.Assert;

[RequireComponent(typeof(NavMeshAgent))]
public class LightEnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent Agent => GetComponent<NavMeshAgent>();

    [SerializeField]
    private Transform target;

    [SerializeField] private WaveManager waveManager;

    private void Start()
    {
        Assert.IsNotNull(target, "target != null");
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waveManager.PlayerDied();
        }
    }
}
