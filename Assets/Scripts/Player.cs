using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] public string playerName;
    public int score;
    public int trains;

    public void AddPoints(int points)
    {
        score += points;
    }

    public void UseTrains(int count)
    {
        if (trains >= count)
        {
            trains -= count;
        }
        else
        {
            Debug.LogWarning("Insufficient trains.");
        }
    }
}
