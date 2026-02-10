using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[RequireComponent(typeof(ScoreManager))]
public class RoomManager : MonoBehaviour
{
    [SerializeField] private DoorManager doorToOpen;
    [FormerlySerializedAs("coinManager")] [SerializeField] private ScoreManager scoreManager;
    [FormerlySerializedAs("objectRespawnManager")] [SerializeField] private Room5PuzzleManager room5PuzzleManager;
    [FormerlySerializedAs("respawnManager")] [SerializeField] private PlayerRespawnManager playerRespawnManager;

    [SerializeField] bool shouldEnd;

    private int _coinsToPickUp ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _coinsToPickUp = gameObject.GetComponentsInChildren<Coin>().Length;
        Debug.Log($"Will need: {_coinsToPickUp} coins to exit {gameObject.name}!");

        scoreManager ??= gameObject.GetComponent<ScoreManager>();
        doorToOpen ??= gameObject.GetComponentInChildren<DoorManager>();
        playerRespawnManager ??= gameObject.GetComponent<PlayerRespawnManager>();
        room5PuzzleManager ??= gameObject.GetComponent<Room5PuzzleManager>();
        
        Utils.CrashIfNull(scoreManager, "Coin manager can't be null!");
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
        if (scoreManager.Score >= _coinsToPickUp && doorToOpen.IsClosed)
        {
            Debug.Log($"Opening door for {gameObject.name}");
            doorToOpen.Open();
            
            if (shouldEnd)
            {
                SceneManager.LoadScene("EndMenu");
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
