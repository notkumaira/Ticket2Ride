using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public string playerName;
    public int score;
    public int trains;
    private List<string> destinationTickets = new List<string>();
    private List<string> trainCards = new List<string>();

    public List<string> GetDestinationTickets()
    {
        return destinationTickets;
    }

    public void SetDestinationTickets(List<string> tickets)
    {
        destinationTickets = tickets;
    }

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

    public void AddDestinationTicket(string ticket)
    {
        destinationTickets.Add(ticket);
    }

    public void RemoveDestinationTicket(string ticket)
    {
        destinationTickets.Remove(ticket);
    }

    public List<string> GetTrainCards()
    {
        return trainCards;
    }

    public void AddTrainCard(string card)
    {
        trainCards.Add(card);
    }

    public void RemoveTrainCard(string card)
    {
        trainCards.Remove(card);
    }
}
