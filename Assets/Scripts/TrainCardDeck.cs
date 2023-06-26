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

    public List<Transform> cardPositions;
    public List<Transform> trainCardHandPositions;

    public Button trainDeckButton;

    private List<GameObject> deck;
    private List<GameObject> trainCardHand;
    private int currentCardIndex;

    private void Start()
    {
        InitializeDeck();
        ShuffleDeck();
        MoveCardsToPositions();
        trainCardHand = new List<GameObject>();

        trainDeckButton.onClick.AddListener(MoveRandomCardToHand);
    }

    private void InitializeDeck()
    {
        deck = new List<GameObject>();

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
            deck.Add(card);
        }
    }

    private void ShuffleDeck()
    {
        int deckSize = deck.Count;
        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = Random.Range(i, deckSize);
            GameObject temp = deck[randomIndex];
            deck[randomIndex] = deck[i];
            deck[i] = temp;
        }
    }

    private void MoveCardsToPositions()
    {
        currentCardIndex = 0;

        for (int i = 0; i < cardPositions.Count; i++)
        {
            if (currentCardIndex >= deck.Count)
                break;

            GameObject card = deck[currentCardIndex];
            card.transform.position = cardPositions[i].position;
            currentCardIndex++;
        }
    }

    private void MoveRandomCardToHand()
    {
        if (currentCardIndex >= deck.Count)
            return;

        if (trainCardHand.Count >= trainCardHandPositions.Count)
            return;

        int randomIndex = Random.Range(currentCardIndex, deck.Count);
        GameObject randomCard = deck[randomIndex];
        deck[randomIndex] = deck[currentCardIndex];
        deck[currentCardIndex] = randomCard;

        MoveCardToHandPosition(randomCard);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                GameObject clickedCard = hit.collider.gameObject;
                if (trainCardHand.Contains(clickedCard))
                {
                    // Handle the click on train card
                    Debug.Log("Train Card Clicked");
                }
            }
        }
    }

    public void MoveCardToHandPosition(GameObject card)
    {
        if (currentCardIndex >= deck.Count)
            return;

        if (trainCardHand.Count >= trainCardHandPositions.Count)
            return;

        trainCardHand.Add(card);
        card.transform.position = trainCardHandPositions[trainCardHand.Count - 1].position;
        currentCardIndex++;
    }
}
