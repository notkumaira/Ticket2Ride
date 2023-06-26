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
        Vector3 startPointPosition = startPoint.position;
        Vector3 endPointPosition = endPoint.position;

        Vector3 clickedPosition = Input.mousePosition;
        clickedPosition.z = Camera.main.transform.position.z;

        float distanceToStart = Vector3.Distance(clickedPosition, startPointPosition);
        float distanceToEnd = Vector3.Distance(clickedPosition, endPointPosition);

        if (distanceToStart < distanceToEnd)
        {
            positions[0] = startPointPosition;
            positions[1] = endPointPosition;
        }
        else
        {
            positions[0] = endPointPosition;
            positions[1] = startPointPosition;
        }

        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);

        // Calculate the required train cars based on the distance between start and end points
        float routeDistance = Vector3.Distance(startPointPosition, endPointPosition);
        int requiredTrainCars = CalculateRequiredTrainCars(routeDistance);

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

        pointScoringSystem.RouteBuilt(requiredTrainCars);
    }

    private int CalculateRequiredTrainCars(float routeDistance)
    {
        // Define the train car requirements based on the route distance
        if (routeDistance <= 2f)
        {
            return 1;
        }
        else if (routeDistance <= 4f)
        {
            return 2;
        }
        else if (routeDistance <= 6f)
        {
            return 3;
        }
        else if (routeDistance <= 8f)
        {
            return 4;
        }
        else if (routeDistance <= 10f)
        {
            return 5;
        }
        else
        {
            return 6;
        }
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
