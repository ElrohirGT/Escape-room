using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int score;
    public int Score => score;

    public void OnPickedUpCoin()
    {
        score += 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}