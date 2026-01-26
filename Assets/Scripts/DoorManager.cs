using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [SerializeField] private bool isClosed =true;
    public bool IsClosed => isClosed;

    public void Open()
    {
        if (!isClosed) return;

        isClosed = false;
        Destroy(gameObject);
    }
}
