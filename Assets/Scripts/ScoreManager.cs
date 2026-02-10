using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    
    public int Score => score;

    public void OnPickedUpCoin()
    {
        score += 1;
    }
    
    
}