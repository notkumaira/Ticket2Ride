using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationTicket : MonoBehaviour
{
    [SerializeField] private string cityA;
    [SerializeField] private string cityB;
    [SerializeField] private int points;

    public string CityA { get { return cityA; } set { cityA = value; } }
    public string CityB { get { return cityB; } set { cityB = value; } }
    public int Points { get { return points; } set { points = value; } }
}

