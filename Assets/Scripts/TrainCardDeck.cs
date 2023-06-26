using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainCardDeck : MonoBehaviour
{
    public GameObject blackTrainCardPrefab;
    public GameObject blueTrainCardPrefab;
    public GameObject purpleTrainCardPrefab;
    public GameObject whiteTrainCardPrefab;
    public GameObject yellowTrainCardPrefab;
    public GameObject orangeTrainCardPrefab;
    public GameObject redTrainCardPrefab;
    public GameObject greenTrainCardPrefab;
    public GameObject rainbowTrainCardPrefab;

    public List<TrainCard> deck = new List<TrainCard>();
    public Transform[] cardPositions;

    public Transform[] HandPositions;
    public bool[] player1AvailableHandPositions = new bool[3];
    public bool[] player2AvailableHandPositions = new bool[3];

    public GameObject player1HandPrefab;
    public GameObject player2HandPrefab;
    public Button trainDeckButton;

    public Transform player1HandParent;
    public Transform player2HandParent;
    private int currentCardIndex;

    public List<TrainCard> player1Hand = new List<TrainCard>();
    public List<TrainCard> player2Hand = new List<TrainCard>();

    private void Start()
    {
        InitializeDeck();
        ShuffleDeck();
        MoveCardsToPositions();

        trainDeckButton.onClick.AddListener(MoveRandomCardToHand);
    }

    private void InitializeDeck()
    {
        deck = new List<TrainCard>();

        AddTrainCardsToDeck(blackTrainCardPrefab, 12);
        AddTrainCardsToDeck(blueTrainCardPrefab, 12);
        AddTrainCardsToDeck(purpleTrainCardPrefab, 12);
        AddTrainCardsToDeck(whiteTrainCardPrefab, 12);
        AddTrainCardsToDeck(yellowTrainCardPrefab, 12);
        AddTrainCardsToDeck(orangeTrainCardPrefab, 12);
        AddTrainCardsToDeck(redTrainCardPrefab, 12);
        AddTrainCardsToDeck(greenTrainCardPrefab, 12);
        AddTrainCardsToDeck(rainbowTrainCardPrefab, 14);
    }

    private void AddTrainCardsToDeck(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject card = Instantiate(prefab, transform);
            TrainCard trainCard = card.GetComponent<TrainCard>();
            deck.Add(trainCard);
        }
    }

    private void ShuffleDeck()
    {
        int deckSize = deck.Count;
        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = Random.Range(i, deckSize);
            TrainCard temp = deck[randomIndex];
            deck[randomIndex] = deck[i];
            deck[i] = temp;
        }
    }

    private void MoveCardsToPositions()
    {
        currentCardIndex = 0;

        for (int i = 0; i < cardPositions.Length; i++)
        {
            if (currentCardIndex >= deck.Count)
                break;

            TrainCard card = deck[currentCardIndex];
            card.transform.position = cardPositions[i].position;
            currentCardIndex++;
        }
    }

    private void MoveRandomCardToHand()
    {
        if (currentCardIndex >= deck.Count)
            return;

        int player1HandCount = player1Hand.Count;
        int player2HandCount = player2Hand.Count;

        if (player1HandCount >= player1AvailableHandPositions.Length && player2HandCount >= player2AvailableHandPositions.Length)
            return;

        int randomIndex = Random.Range(currentCardIndex, deck.Count);
        TrainCard randomCard = deck[randomIndex];
        deck[randomIndex] = deck[currentCardIndex];
        deck[currentCardIndex] = randomCard;

        if (player1HandCount < player1AvailableHandPositions.Length)
        {
            // Move the card to the hand position only if player 1's hand is active and there is an available position
            if (player1HandPrefab.activeSelf && player1AvailableHandPositions[player1HandCount])
            {
                MoveCardToHandPosition(randomCard, player1HandParent, player1Hand);
                player1AvailableHandPositions[player1HandCount] = false;
            }
        }
        else if (player2HandCount < player2AvailableHandPositions.Length)
        {
            // Move the card to the hand position only if player 2's hand is active and there is an available position
            if (player2HandPrefab.activeSelf && player2AvailableHandPositions[player2HandCount])
            {
                MoveCardToHandPosition(randomCard, player2HandParent, player2Hand);
                player2AvailableHandPositions[player2HandCount] = false;
            }
        }

        currentCardIndex++;
    }



    public void MoveCardToHandPosition(TrainCard card, Transform handParent, List<TrainCard> hand)
    {
        card.transform.SetParent(handParent);

        // Get the index of the hand position where the card should be placed
        int handIndex = hand.Count;

        // Check if the hand index is valid and within the range of hand positions
        if (handIndex >= 0 && handIndex < handParent.childCount)
        {
            Transform handPosition = handParent.GetChild(handIndex);
            card.transform.position = handPosition.position;
            card.transform.rotation = handPosition.rotation;
        }

        hand.Add(card);
        currentCardIndex++;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                TrainCard clickedCard = hit.collider.GetComponent<TrainCard>();
                if (player1Hand.Contains(clickedCard))
                {
                    // Handle the click on train card for player 1
                    Debug.Log("Player 1 Train Card Clicked");
                }
                else if (player2Hand.Contains(clickedCard))
                {
                    // Handle the click on train card for player 2
                    Debug.Log("Player 2 Train Card Clicked");
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
            player1HandPrefab.transform.SetParent(player2HandParent);
            player1HandPrefab.transform.localPosition = Vector3.zero;
            player2HandPrefab.transform.SetParent(player1HandParent);
            player2HandPrefab.transform.localPosition = Vector3.zero;

            // Switch available card slots with the other player
            bool[] temp = player1AvailableHandPositions;
            player1AvailableHandPositions = player2AvailableHandPositions;
            player2AvailableHandPositions = temp;
        }
        else if (player2HandPrefab.activeSelf)
        {
            player2HandPrefab.SetActive(false);
            player2HandPrefab.transform.SetParent(player1HandParent);
            player2HandPrefab.transform.localPosition = Vector3.zero;
            player1HandPrefab.transform.SetParent(player2HandParent);
            player1HandPrefab.transform.localPosition = Vector3.zero;

            // Switch available card slots with the other player
            bool[] temp = player2AvailableHandPositions;
            player2AvailableHandPositions = player1AvailableHandPositions;
            player1AvailableHandPositions = temp;
        }

        // Activate new active player hand
        if (player1HandPrefab.transform.parent == player1HandParent)
        {
            player1HandPrefab.SetActive(true);
        }
        else if (player2HandPrefab.transform.parent == player2HandParent)
        {
            player2HandPrefab.SetActive(true);
        }
    }

}