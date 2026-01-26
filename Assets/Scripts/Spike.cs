using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Spike : MonoBehaviour
{
    [FormerlySerializedAs("respawnManager")] [SerializeField] private PlayerRespawnManager playerRespawnManager;
    private TagHandle _playerHandle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Utils.CrashIfNull(playerRespawnManager, "Respawn manager can't be null!");
        _playerHandle = TagHandle.GetExistingTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerHandle))
            playerRespawnManager.Respawn();
    }
}
