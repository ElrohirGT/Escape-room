using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CoinManager))]
public class RoomManager : MonoBehaviour
{
    [SerializeField] private DoorManager doorToOpen;
    [SerializeField] private CoinManager coinManager;
    [FormerlySerializedAs("objectRespawnManager")] [SerializeField] private Room5PuzzleManager room5PuzzleManager;
    [FormerlySerializedAs("respawnManager")] [SerializeField] private PlayerRespawnManager playerRespawnManager;

    private int _coinsToPickUp ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _coinsToPickUp = gameObject.GetComponentsInChildren<Coin>().Length;
        Debug.Log($"Will need: {_coinsToPickUp} coins to exit {gameObject.name}!");

        coinManager ??= gameObject.GetComponent<CoinManager>();
        doorToOpen ??= gameObject.GetComponentInChildren<DoorManager>();
        playerRespawnManager ??= gameObject.GetComponent<PlayerRespawnManager>();
        room5PuzzleManager ??= gameObject.GetComponent<Room5PuzzleManager>();
        
        Utils.CrashIfNull(coinManager, "Coin manager can't be null!");
        Utils.CrashIfNull(doorToOpen, "Door to open can't be null!");

        if (room5PuzzleManager is not null)
            playerRespawnManager.PlayerRespawned += OnPlayerRespawned;
    }

    private void OnPlayerRespawned(object sender, EventArgs e)
    {
        room5PuzzleManager.Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinManager.Score >= _coinsToPickUp && doorToOpen.IsClosed)
        {
            Debug.Log($"Opening door for {gameObject.name}");
            doorToOpen.Open();
        }
    }
}
