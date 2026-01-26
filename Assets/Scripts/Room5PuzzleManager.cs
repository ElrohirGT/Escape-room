using System;
using UnityEngine;

public enum PuzzleState
{
    Unsolved,
    Solved,
}

public class Room5PuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform target;

    [SerializeField] private Transform goal;

    [SerializeField] private PuzzleState state;

    private PushableBox _pushable;

    public void Respawn()
    {
        Debug.Log("Respawning object...");
        if (state != PuzzleState.Unsolved) return;
        
        _pushable.enabled = false;
        target.position = respawnPoint.position;
        _pushable.enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         _pushable = target.GetComponent<PushableBox>();
        Utils.CrashIfNull(respawnPoint, "Respawn point is null!");
        Utils.CrashIfNull(target, "Respawn target is null!");
    }

    private void Update()
    {
        var delta = target.position - goal.position;
        if (delta.magnitude <= 1.3)
        {
            state = PuzzleState.Solved;
        }
        if (state == PuzzleState.Solved)
        {
            target.position = new Vector3(goal.position.x, target.position.y, goal.position.z);
        }
    }
}
