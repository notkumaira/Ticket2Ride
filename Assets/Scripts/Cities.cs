using UnityEngine;
using UnityEngine.UI;

public class Cities : MonoBehaviour
{
    public Button[] cities;
    private string startCity;
    private string endCity;

    void Start()
    {
        foreach (Button button in cities)
        {
            button.onClick.AddListener(() => OnCityButtonClick(button.name));
        }
    }

    void OnCityButtonClick(string cityName)
    {
        if (startCity == null)
        {
            startCity = cityName;
            Debug.Log("Start City: " + startCity);
        }
        else if (endCity == null && cityName != startCity)
        {
            endCity = cityName;
            Debug.Log("End City: " + endCity);
        }
    }
}
