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

        DestinationTicket ZurichToBudapestTicket = new DestinationTicket();
        ZurichToBudapestTicket.CityA = "Zurich";
        ZurichToBudapestTicket.CityB = "Budapest";
        ZurichToBudapestTicket.Points = 6;

        ticketDeck.AddTicket(ZurichToBudapestTicket);

        DestinationTicket ZurichToBrindisiTicket = new DestinationTicket();
        ZurichToBrindisiTicket.CityA = "Zurich";
        ZurichToBrindisiTicket.CityB = "Brindisi";
        ZurichToBrindisiTicket.Points = 6;

        ticketDeck.AddTicket(ZurichToBrindisiTicket);

        DestinationTicket ZurichToMadridTicket = new DestinationTicket();
        ZurichToMadridTicket.CityA = "Zurich";
        ZurichToMadridTicket.CityB = "Madrid";
        ZurichToMadridTicket.Points = 8;

        ticketDeck.AddTicket(ZurichToMadridTicket);

        DestinationTicket ZacrabToBrindisiTicket = new DestinationTicket();
        ZacrabToBrindisiTicket.CityA = "Zacrab";
        ZacrabToBrindisiTicket.CityB = "Brindisi";
        ZacrabToBrindisiTicket.Points = 6;

        ticketDeck.AddTicket(ZacrabToBrindisiTicket);

        DestinationTicket WeinToStockholmTicket = new DestinationTicket();
        WeinToStockholmTicket.CityA = "Wein";
        WeinToStockholmTicket.CityB = "Stockholm";
        WeinToStockholmTicket.Points = 11;

        ticketDeck.AddTicket(WeinToStockholmTicket);

        DestinationTicket WeinToLondonTicket = new DestinationTicket();
        WeinToLondonTicket.CityA = "Wein";
        WeinToLondonTicket.CityB = "London";
        WeinToLondonTicket.Points = 10;

        ticketDeck.AddTicket(WeinToLondonTicket);

        DestinationTicket SmyrnaToSofiaTicket = new DestinationTicket();
        SmyrnaToSofiaTicket.CityA = "Smyrna";
        SmyrnaToSofiaTicket.CityB = "Sofia";
        SmyrnaToSofiaTicket.Points = 5;

        ticketDeck.AddTicket(SmyrnaToSofiaTicket);

        DestinationTicket SmolensktoWarsawTicket = new DestinationTicket();
        SmolensktoWarsawTicket.CityA = "Smolensk";
        SmolensktoWarsawTicket.CityB = "Sofia";
        SmolensktoWarsawTicket.Points = 6;

        ticketDeck.AddTicket(SmolensktoWarsawTicket);

        DestinationTicket SmolenskToRostovTicket = new DestinationTicket();
        SmolenskToRostovTicket.CityA = "Smolensk";
        SmolenskToRostovTicket.CityB = "Rostov";
        SmolenskToRostovTicket.Points = 8;

        ticketDeck.AddTicket(SmolenskToRostovTicket);

        DestinationTicket SmolenskToFrankfurt = new DestinationTicket();
        SmolenskToFrankfurt.CityA = "Smolensk";
        SmolenskToFrankfurt.CityB = "Rostov";
        SmolenskToFrankfurt.Points = 13;

        ticketDeck.AddTicket(SmolenskToFrankfurt);

        DestinationTicket SarajevoToEevastapol = new DestinationTicket();
        SarajevoToEevastapol.CityA = "Sarajevo";
        SarajevoToEevastapol.CityB = "Eevastapol";
        SarajevoToEevastapol.Points = 8;

        ticketDeck.AddTicket(SarajevoToEevastapol);

        DestinationTicket RicaToBucuresti = new DestinationTicket();
        RicaToBucuresti.CityA = "Rica";
        RicaToBucuresti.CityB = "Bucuresti";
        RicaToBucuresti.Points = 10;

        ticketDeck.AddTicket(RicaToBucuresti);

        DestinationTicket ParisToZacrab = new DestinationTicket();
        ParisToZacrab.CityA = "Paris";
        ParisToZacrab.CityB = "Zacrab";
        ParisToZacrab.Points = 7;

        ticketDeck.AddTicket(ParisToZacrab);

        DestinationTicket ParistoWein = new DestinationTicket();
        ParistoWein.CityA = "Paris";
        ParistoWein.CityB = "Wein";
        ParistoWein.Points = 8;

        ticketDeck.AddTicket(ParistoWein);

        DestinationTicket ParistoEdinburgh = new DestinationTicket();
        ParistoEdinburgh.CityA = "Paris";
        ParistoEdinburgh.CityB = "Edinburgh";
        ParistoEdinburgh.Points = 7;

        ticketDeck.AddTicket(ParistoEdinburgh);

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

        DestinationTicket ErzurumToKobenhaven = new DestinationTicket();
        ErzurumToKobenhaven.CityA = "Erzurum";
        ErzurumToKobenhaven.CityB = "Kobenhaven";
        ErzurumToKobenhaven.Points = 21;

        ticketDeck.AddTicket(ErzurumToKobenhaven);

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

        DestinationTicket BerlinToBuccuresti = new DestinationTicket();
        BerlinToBuccuresti.CityA = "Berlin";
        BerlinToBuccuresti.CityB = "Buccuresti";
        BerlinToBuccuresti.Points = 8;

        ticketDeck.AddTicket(BerlinToBuccuresti);

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
