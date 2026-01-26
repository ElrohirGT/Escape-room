using System;
using UnityEngine;

public class DisableOnPlayerContact : MonoBehaviour
{
    private TagHandle _playerHandle;

    private void Start()
    {
        _playerHandle = TagHandle.GetExistingTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerHandle))
            Destroy(gameObject);
    }
}
