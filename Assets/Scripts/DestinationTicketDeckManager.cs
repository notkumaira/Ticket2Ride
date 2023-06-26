using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTicketDeckManager : MonoBehaviour
{
    public List<DestinationTicket> deck = new List<DestinationTicket>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            DestinationTicket randDestinationTicket = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    randDestinationTicket.gameObject.SetActive(true);
                    randDestinationTicket.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randDestinationTicket);
                    return;
                }
            }
        }
    }
}
