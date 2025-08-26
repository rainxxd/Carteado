using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;
    private Random random = new Random();

    public Deck()
    {
        cards = new List<Card>();
        string[] suits = { "Copas", "Ouros", "Espadas", "Paus" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        for (int i = 0; i < ranks.Length; i++)
        {
            foreach (var suit in suits)
            {
                cards.Add(new Card(suit, ranks[i], values[i]));
            }
        }
    }

    public Card DrawCard()
    {
        int index = random.Next(cards.Count);
        Card card = cards[index];
        cards.RemoveAt(index);
        return card;
    }
}