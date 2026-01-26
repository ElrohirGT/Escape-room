using System;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float delta;
    
    private TagHandle _playerHandle;

    private bool _playerIsTouchingBox;

    private void Start()
    {
        _playerHandle = TagHandle.GetExistingTag("Player");
        
        Utils.CrashIfNull(player, "Player can't be null!");
    }

    private void Update()
    {
        if (!_playerIsTouchingBox) return;
        
        var previousY = transform.position.y;
        var newPosition = player.position + mainCamera.forward * delta;
        transform.position = new Vector3(newPosition.x, previousY, newPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(_playerHandle))
            return;
        _playerIsTouchingBox = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(_playerHandle))
            return;
        _playerIsTouchingBox = false;
    }
}
