using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteBuilder : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float routeWidth = 0.5f;
    public float routeLength = 10f;
    public int requiredTrainCars; // Number of train cars required for the route
    public int pointsReward; // Points rewarded for completing the route

    private LineRenderer lineRenderer;
    private PointScoringSystem pointScoringSystem;
    private bool startPointClicked = false;
    private bool endPointClicked = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        pointScoringSystem = FindObjectOfType<PointScoringSystem>();

        // Initially, both start and end points are not clicked
        startPointClicked = false;
        endPointClicked = false;
    }

    private void Update()
    {
        // Check if the player clicks on the start point
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.transform == startPoint)
            {
                startPointClicked = true;
            }
        }

        // Check if the player clicks on the end point
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.transform == endPoint)
            {
                endPointClicked = true;
            }
        }

        // If both start and end points are clicked, build the route
        if (startPointClicked && endPointClicked)
        {
            BuildRoute();
        }
    }

    void BuildRoute()
    {
        lineRenderer.startWidth = routeWidth;
        lineRenderer.endWidth = routeWidth;

        Vector3[] positions = new Vector3[2];
        positions[0] = startPoint.position;
        positions[0].z = 0f; // Set the z-coordinate to 0 for 2D
        positions[1] = endPoint.position;
        positions[1].z = 0f; // Set the z-coordinate to 0 for 2D

        lineRenderer.positionCount = 2; // Update the position count for 2D

        lineRenderer.SetPositions(positions);

        // Modify the required number of train cars and points reward based on the route length
        requiredTrainCars = transform.childCount + 1; // Include the parent object
        pointsReward = CalculatePointsReward(requiredTrainCars);

        // Subtract train cars from the respective player's group
        TrainCarManager trainCarManager = FindObjectOfType<TrainCarManager>();
        if (trainCarManager != null)
        {
            if (trainCarManager.isPlayer1Active)
            {
                trainCarManager.SubtractTrainCars(trainCarManager.player1Cars, requiredTrainCars);
            }
            else
            {
                trainCarManager.SubtractTrainCars(trainCarManager.player2Cars, requiredTrainCars);
            }
        }


        // Reward points for completing the route
        pointScoringSystem.RouteBuilt(pointsReward);

        // Reset the clicked flags
        startPointClicked = false;
        endPointClicked = false;
    }

    private int CalculatePointsReward(int trainCarsCount)
    {
        int points = 0;

        switch (trainCarsCount)
        {
            case 1:
                points = 1;
                break;
            case 2:
                points = 2;
                break;
            case 3:
                points = 4;
                break;
            case 4:
                points = 7;
                break;
            case 5:
                points = 10;
                break;
            case 6:
                points = 15;
                break;
            default:
                points = 0;
                break;
        }

        return points;
    }

}
