using UnityEngine;

public enum CageState
{
    NotAppeared,
    Appeared,
    Lifted
}

public class CageManager : MonoBehaviour
{

    [SerializeField] private CageState state = CageState.NotAppeared;
    public CageState State => state;

    public void DropCage()
    {
        state = CageState.Appeared;
        gameObject.SetActive(true);
    }
    
    public void LiftCage()
    {
        state = CageState.Lifted;
    }
    
    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(state == CageState.Appeared);
    }
}
