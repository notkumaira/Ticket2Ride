using UnityEngine;

public class RouteBuilder : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float routeWidth = 0.5f;

    private LineRenderer lineRenderer;
    private TrainCarManager trainCarManager;
    private bool startPointClicked = false;
    private bool endPointClicked = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        trainCarManager = FindObjectOfType<TrainCarManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.transform == startPoint)
                {
                    startPointClicked = true;
                }
                else if (hit.collider.transform == endPoint)
                {
                    endPointClicked = true;
                }
            }
        }

        if (startPointClicked && endPointClicked)
        {
            BuildRoute();
        }
    }

    private void BuildRoute()
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

        int requiredTrainCars = CalculateRequiredTrainCars(Vector3.Distance(startPointPosition, endPointPosition));

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
    }

    private int CalculateRequiredTrainCars(float routeDistance)
    {
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
}
