using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScoringSystem : MonoBehaviour
{
    public int pointsPerRoute = 1;
    public int pointsPerDestinationCard = 5;

    private int totalPoints = 0;

    // Called when a route is built
    public void RouteBuilt(int points)
    {
        totalPoints += points;
        Debug.Log("Route built! +" + points + " points");
    }

    // Called when a destination card is completed
    public void DestinationCardCompleted()
    {
        totalPoints += pointsPerDestinationCard;
        Debug.Log("Destination card completed! +" + pointsPerDestinationCard + " points");
    }

    // Called to retrieve the current total points
    public int GetTotalPoints()
    {
        return totalPoints;
    }
}
