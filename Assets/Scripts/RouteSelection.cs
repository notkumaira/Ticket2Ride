using UnityEngine;
using UnityEngine.UI;

public class RouteSelection : MonoBehaviour
{
    private bool isSelectingRoute = false;
    private Button selectedRouteButton = null;

    private void Awake()
    {
        // Attach the Click event to each route button in your UI
        Button[] routeButtons = GetComponentsInChildren<Button>();
        foreach (Button routeButton in routeButtons)
        {
            routeButton.onClick.AddListener(() => SelectRoute(routeButton));
        }
    }

    private void SelectRoute(Button routeButton)
    {
        // Check if the route is available and not already selected
        if (!isSelectingRoute && !routeButton.interactable)
        {
            // Select the route
            selectedRouteButton = routeButton;
            isSelectingRoute = true;

            // Disable the button to prevent multiple selections
            selectedRouteButton.interactable = false;

            // Transport trains to the selected route
            TransportTrains(selectedRouteButton.transform.position);

            // Mark the route as claimed
            // Implement your own logic to mark the route as claimed

            // Clear the selected route
            selectedRouteButton = null;
            isSelectingRoute = false;
        }
    }

    private void TransportTrains(Vector3 targetPosition)
    {
        // Move trains towards the target position
        // Implement your own train movement logic here
    }
}
