using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointWalker : MonoBehaviour
{
    private int idx;
    [SerializeField] private List<Transform> waypoints;
    
    public Vector3 GetTarget
    {
        get
        {
            if (waypoints.Count == 0)
            {
                return transform.position;
            }
            var clamped = idx < waypoints.Count ? idx : idx % waypoints.Count;
            return waypoints[clamped].position;
        }
    }
    private NavMeshAgent _agent;
    
    private void OnDrawGizmos()
    {
        if (waypoints.Count > 0)
        {
            var startPos = waypoints[0].position;
            startPos.y += 0.5f;
            for (var i = 1; i < waypoints.Count; i++)
            {
                var end = waypoints[i].position;
                end.y += 0.5f;
                Gizmos.DrawLine(startPos, end);
                startPos = waypoints[i].position;
                startPos.y += 0.5f;
            }

            var endPos = waypoints[0].position;
            endPos.y += 0.5f;
            Gizmos.DrawLine(startPos, endPos);
        }
        
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent ??= GetComponent<NavMeshAgent>();
        _agent.SetDestination(GetTarget);
        
        Assert.IsNotNull(_agent, "agent != null");       
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            idx += 1;
            Debug.Log("Changing target! " + idx);
        }

        _agent.SetDestination(GetTarget);    
    }
}
