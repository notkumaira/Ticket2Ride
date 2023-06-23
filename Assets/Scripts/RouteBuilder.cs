using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteBuilder : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float routeWidth = 0.5f;
    public float routeLength = 10f;
    private LineRenderer lineRenderer;
    private PointScoringSystem pointScoringSystem;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        BuildRoute();
        pointScoringSystem = FindObjectOfType<PointScoringSystem>();
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
        pointScoringSystem.RouteBuilt();
    }
}

