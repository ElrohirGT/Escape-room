using System;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Player player;

    public event EventHandler PlayerRespawned; 

    public void Respawn()
    {
        Debug.Log("Respawning player...");
        player.Teleport(respawnPoint);
        PlayerRespawned?.Invoke(this, EventArgs.Empty);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Utils.CrashIfNull(respawnPoint, "Respawn point is null!");
        Utils.CrashIfNull(player, "Respawn target is null!");
    }
}
