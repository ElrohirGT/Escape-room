using UnityEngine;

[RequireComponent(typeof(Transform), typeof(CharacterController))]
public class Player : MonoBehaviour
{

    private Transform _transform;
    private CharacterController _controller;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _controller = gameObject.GetComponent<CharacterController>();
        
        Utils.CrashIfNull(_transform, "Transform can't be null!");
        Utils.CrashIfNull(_controller, "Character Controller can't be null!");
    }

    public void Teleport(Transform to)
    {
        _controller.enabled = false;
        _transform.SetPositionAndRotation(to.position, to.rotation);
        _controller.enabled = true;
    }
}
