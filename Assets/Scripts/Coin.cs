using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private ScoreManager manager;
    [SerializeField] private float rotationSpeed = 3;
    private TagHandle _playerHandle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Utils.CrashIfNull(manager, "No coin manager set!");
        _playerHandle = TagHandle.GetExistingTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("The player tag is: "+_playerHandle + " But we got: "+other.gameObject.tag);
        if (!other.gameObject.CompareTag(_playerHandle)) return;
        
        Debug.Log("Picking up coin...");
        AudioManager.Instance.PlayEffect(AudioManager.Sound.PickUpCoin);
        manager.OnPickedUpCoin();
        Destroy(gameObject);
    }
}
