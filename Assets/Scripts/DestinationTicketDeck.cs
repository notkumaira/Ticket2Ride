using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationTicketDeck : MonoBehaviour
{
    private List<DestinationTicket> tickets;
    private List<DestinationTicket> drawnTickets;
    private DestinationTicketDeck ticketDeck;
    private List<GameObject> deck;
    private int currentCardIndex;
    private int currentIndex;

    [SerializeField] private Button drawButton;
    [SerializeField] private List<Transform> ticketPositions;
    [SerializeField] private List<Transform> DestinationTickets;

    private void Awake()
    {
        tickets = new List<DestinationTicket>();
        drawnTickets = new List<DestinationTicket>();
        currentIndex = 0;
    }

    public DestinationTicketDeck()
    {
        tickets = new List<DestinationTicket>();
    }

    public void AddTicket(DestinationTicket ticket)
    {
        tickets.Add(ticket);
    }

    private void ShuffleDeck()
    {
        int n = tickets.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            DestinationTicket temp = tickets[k];
            tickets[k] = tickets[n];
            tickets[n] = temp;
        }
    }

    private void Start()
    {
        ticketDeck = new DestinationTicketDeck();

        DestinationTicket amsterdamToWilnoTicket = new DestinationTicket();
        amsterdamToWilnoTicket.CityA = "Amsterdam";
        amsterdamToWilnoTicket.CityB = "Wilno";
        amsterdamToWilnoTicket.Points = 12;

        // Add the ticket to the deck
        ticketDeck.AddTicket(amsterdamToWilnoTicket);

        DestinationTicket athinaToAncoraTicket = new DestinationTicket();
        athinaToAncoraTicket.CityA = "Athina";
        athinaToAncoraTicket.CityB = "Ancora";
        athinaToAncoraTicket.Points = 5;

        ticketDeck.AddTicket(athinaToAncoraTicket);

        DestinationTicket MadridToDieppe = new DestinationTicket();
        MadridToDieppe.CityA = "Madrid";
        MadridToDieppe.CityB = "Dieppe";
        MadridToDieppe.Points = 8;

        ticketDeck.AddTicket(MadridToDieppe);

        DestinationTicket MoskvaToPallermo = new DestinationTicket();
        MoskvaToPallermo.CityA = "Moskva";
        MoskvaToPallermo.CityB = "Pallermo";
        MoskvaToPallermo.Points = 21;

        ticketDeck.AddTicket(MoskvaToPallermo);

        DestinationTicket LisboaToDanzic = new DestinationTicket();
        LisboaToDanzic.CityA = "Lisboa";
        LisboaToDanzic.CityB = "Danzic";
        LisboaToDanzic.Points = 20;

        ticketDeck.AddTicket(LisboaToDanzic);

        DestinationTicket KyivToSochi = new DestinationTicket();
        KyivToSochi.CityA = "Kyiv";
        KyivToSochi.CityB = "Sochi";
        KyivToSochi.Points = 8;

        ticketDeck.AddTicket(KyivToSochi);

        DestinationTicket KyivToEssen = new DestinationTicket();
        KyivToEssen.CityA = "Kyiv";
        KyivToEssen.CityB = "Essen";
        KyivToEssen.Points = 10;

        DestinationTicket KyivToPetrograd = new DestinationTicket();
        KyivToPetrograd.CityA = "Kyiv";
        KyivToPetrograd.CityB = "Petrograd";
        KyivToPetrograd.Points = 6;

        ticketDeck.AddTicket(KyivToPetrograd);

        DestinationTicket FrankfurtToKobenhaven = new DestinationTicket();
        FrankfurtToKobenhaven.CityA = "FrankFurt";
        FrankfurtToKobenhaven.CityB = "Kobenhaven";
        FrankfurtToKobenhaven.Points = 5;

        ticketDeck.AddTicket(FrankfurtToKobenhaven);

        DestinationTicket EssenToMarseille = new DestinationTicket();
        EssenToMarseille.CityA = "Essen";
        EssenToMarseille.CityB = "Marseille";
        EssenToMarseille.Points = 8;

        ticketDeck.AddTicket(EssenToMarseille);

        DestinationTicket ErzurumToRostov = new DestinationTicket();
        ErzurumToRostov.CityA = "Erzurum";
        ErzurumToRostov.CityB = "Rostov";
        ErzurumToRostov.Points = 5;

        ticketDeck.AddTicket(ErzurumToRostov);

        DestinationTicket ConstantinopleToVenezia = new DestinationTicket();
        ConstantinopleToVenezia.CityA = "Constantinople";
        ConstantinopleToVenezia.CityB = "Venezia";
        ConstantinopleToVenezia.Points = 10;

        ticketDeck.AddTicket(ConstantinopleToVenezia);

        DestinationTicket ConstantinopleToPallermo = new DestinationTicket();
        ConstantinopleToPallermo.CityA = "Constaninople";
        ConstantinopleToPallermo.CityB = "Pallermo";
        ConstantinopleToPallermo.Points = 8;

        ticketDeck.AddTicket(ConstantinopleToPallermo);

        DestinationTicket CadizToStockholm = new DestinationTicket();
        CadizToStockholm.CityA = "Cadiz";
        CadizToStockholm.CityB = "Stockholm";
        CadizToStockholm.Points = 21;

        ticketDeck.AddTicket(CadizToStockholm);

        DestinationTicket BudapestToSofia = new DestinationTicket();
        BudapestToSofia.CityA = "Budapest";
        BudapestToSofia.CityB = "Sofia";
        BudapestToSofia.Points = 5;

        ticketDeck.AddTicket(BudapestToSofia);

        DestinationTicket BruxToDanzic = new DestinationTicket();
        BruxToDanzic.CityA = "Brux";
        BruxToDanzic.CityB = "Danzic:";
        BruxToDanzic.Points = 9;

        ticketDeck.AddTicket(BruxToDanzic);

        DestinationTicket BrestToPetrograd = new DestinationTicket();
        BrestToPetrograd.CityA = "Brest";
        BrestToPetrograd.CityB = "Petrograd";
        BrestToPetrograd.Points = 20;

        ticketDeck.AddTicket(BrestToPetrograd);

        DestinationTicket BrestToVenezia = new DestinationTicket();
        BrestToVenezia.CityA = "Brest";
        BrestToVenezia.CityB = "Venezia";
        BrestToVenezia.Points = 8;

        ticketDeck.AddTicket(BrestToVenezia);

        DestinationTicket BrestToMarseille = new DestinationTicket();
        BrestToMarseille.CityA = "Brest";
        BrestToMarseille.CityB = "Marseille";
        BrestToMarseille.Points = 7;

        ticketDeck.AddTicket(BrestToMarseille);

        DestinationTicket BerlinToRoma = new DestinationTicket();
        BerlinToRoma.CityA = "Berlin";
        BerlinToRoma.CityB = "Roma";
        BerlinToRoma.Points = 9;

        ticketDeck.AddTicket(BerlinToRoma);

        DestinationTicket BerlinToMoskva = new DestinationTicket();
        BerlinToMoskva.CityA = "Berlin";
        BerlinToMoskva.CityB = "Moskva";
        BerlinToMoskva.Points = 12;

        ticketDeck.AddTicket(BerlinToMoskva);

        DestinationTicket BerlinToLondon = new DestinationTicket();
        BerlinToLondon.CityA = "Berlin";
        BerlinToLondon.CityB = "London";
        BerlinToLondon.Points = 7;

        ticketDeck.AddTicket(BerlinToLondon);

        DestinationTicket BerlinToBucuresti = new DestinationTicket();
        BerlinToBucuresti.CityA = "Berlin";
        BerlinToBucuresti.CityB = "Bucuresti";
        BerlinToBucuresti.Points = 8;

        ticketDeck.AddTicket(BerlinToBucuresti);

        DestinationTicket BarcelonaToMunchen = new DestinationTicket();
        BarcelonaToMunchen.CityA = "Barcelona";
        BarcelonaToMunchen.CityB = "Munchen";
        BarcelonaToMunchen.Points = 8;

        ticketDeck.AddTicket(BarcelonaToMunchen);

        DestinationTicket BarcelonaToBrux = new DestinationTicket();
        BarcelonaToBrux.CityA = "Barcelona";
        BarcelonaToBrux.CityB = "Brux";
        BarcelonaToBrux.Points = 8;

        ticketDeck.AddTicket(BarcelonaToBrux);

        DestinationTicket AthinaToWilno = new DestinationTicket();
        AthinaToWilno.CityA = "Athina";
        AthinaToWilno.CityB = "Wilno";
        AthinaToWilno.Points = 11;

        ticketDeck.AddTicket(AthinaToWilno);

        DestinationTicket AthinaToEdinburgh = new DestinationTicket();
        AthinaToEdinburgh.CityA = "Athina";
        AthinaToEdinburgh.CityB = "Edinburgh";
        AthinaToEdinburgh.Points = 21;

        ticketDeck.AddTicket(AthinaToEdinburgh);

        DestinationTicket AncoraToKharkov = new DestinationTicket();
        AncoraToKharkov.CityA = "Ancora";
        AncoraToKharkov.CityB = "Kharkov";
        AncoraToKharkov.Points = 10;

        ticketDeck.AddTicket(AncoraToKharkov);

        DestinationTicket AmsterdamnToPampelona = new DestinationTicket();
        AmsterdamnToPampelona.CityA = "Amsterdamn";
        AmsterdamnToPampelona.CityB = "Pampelona";
        AmsterdamnToPampelona.Points = 7;

        ticketDeck.AddTicket(AmsterdamnToPampelona);

        ShuffleDeck();
        drawButton.onClick.AddListener(DrawTicket);
    }

    private void DrawTicket()
    {
        if (currentIndex >= tickets.Count)
        {
            Debug.Log("No more tickets in the deck.");
            return;
        }

            currentCardIndex = 0;

            for (int i = 0; i < ticketPositions.Count; i++)
            {
                if (currentCardIndex >= deck.Count)
                    break;

                GameObject card = deck[currentCardIndex];
                card.transform.position = ticketPositions[i].position;
                currentCardIndex++;
            }

    }
}
