using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTicketDeckManager : MonoBehaviour
{
    public List<DestinationTicket> deck = new List<DestinationTicket>();
    public Transform[] cardSlots;
    public bool[] player1AvailableCardSlots = new bool[3];
    public bool[] player2AvailableCardSlots = new bool[3];

    public GameObject player1HandPrefab;
    public GameObject player2HandPrefab;

    public Transform player1TicketParent;
    public Transform player2TicketParent;

    public List<DestinationTicket> player1Tickets = new List<DestinationTicket>();
    public List<DestinationTicket> player2Tickets = new List<DestinationTicket>();

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            DestinationTicket randDestinationTicket = deck[Random.Range(0, deck.Count)];

            bool[] availableCardSlots = null;
            if (player1HandPrefab.activeSelf)
            {
                availableCardSlots = player1AvailableCardSlots;
                player1Tickets.Add(randDestinationTicket);
            }
            else if (player2HandPrefab.activeSelf)
            {
                availableCardSlots = player2AvailableCardSlots;
                player2Tickets.Add(randDestinationTicket);
            }

            if (availableCardSlots != null)
            {
                int slotIndex = -1; // Declare a variable to store the index of the available card slot

                for (int i = 0; i < availableCardSlots.Length; i++)
                {
                    if (availableCardSlots[i] == true)
                    {
                        slotIndex = i; // Assign the index to the slotIndex variable
                        break;
                    }
                }

                if (slotIndex != -1)
                {
                    randDestinationTicket.gameObject.SetActive(true);
                    randDestinationTicket.transform.position = cardSlots[slotIndex].position;

                    if (player1HandPrefab.activeSelf)
                    {
                        randDestinationTicket.transform.SetParent(player1TicketParent);
                    }
                    else if (player2HandPrefab.activeSelf)
                    {
                        randDestinationTicket.transform.SetParent(player2TicketParent);
                    }

                    availableCardSlots[slotIndex] = false;
                    deck.Remove(randDestinationTicket);
                    return;
                }
            }


        }
    }

    public void SwitchPlayerHand()
    {
        // Deactivate current active player hand
        if (player1HandPrefab.activeSelf)
        {
            player1HandPrefab.SetActive(false);
            player1HandPrefab.transform.SetParent(player2TicketParent);
            player1HandPrefab.transform.localPosition = Vector3.zero;
            player2HandPrefab.transform.SetParent(player1TicketParent);
            player2HandPrefab.transform.localPosition = Vector3.zero;

            // Switch available card slots with the other player
            bool[] temp = player1AvailableCardSlots;
            player1AvailableCardSlots = player2AvailableCardSlots;
            player2AvailableCardSlots = temp;
        }
        else if (player2HandPrefab.activeSelf)
        {
            player2HandPrefab.SetActive(false);
            player2HandPrefab.transform.SetParent(player1TicketParent);
            player2HandPrefab.transform.localPosition = Vector3.zero;
            player1HandPrefab.transform.SetParent(player2TicketParent);
            player1HandPrefab.transform.localPosition = Vector3.zero;

            // Switch available card slots with the other player
            bool[] temp = player2AvailableCardSlots;
            player2AvailableCardSlots = player1AvailableCardSlots;
            player1AvailableCardSlots = temp;
        }

        // Activate new active player hand
        if (player1HandPrefab.transform.parent == player1TicketParent)
        {
            player1HandPrefab.SetActive(true);
        }
        else if (player2HandPrefab.transform.parent == player2TicketParent)
        {
            player2HandPrefab.SetActive(true);
        }
    }

}