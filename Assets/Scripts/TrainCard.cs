using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class TrainCard : MonoBehaviour, IPointerDownHandler
{
    private TrainCardDeck trainCardDeck;

    public int id;
    public string cardDescription;
    public int count;

    public TrainCard()
    {

    }

    public TrainCard(int Id, string CardDescription, int Count)
    {
        id = Id;
        cardDescription = CardDescription;
        count = Count;
    }

    private void Start()
    {
        // Find the TrainCardDeck script in the scene
        trainCardDeck = FindObjectOfType<TrainCardDeck>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Call the MoveCardToHandPosition method in the TrainCardDeck script
        if (trainCardDeck != null)
        {
            Transform handParent = gameObject.transform.parent;
            List<TrainCard> hand = (handParent == trainCardDeck.player1HandParent) ? trainCardDeck.player1Hand : trainCardDeck.player2Hand;
            trainCardDeck.MoveCardToHandPosition(this, handParent, hand);
        }
    }
}
