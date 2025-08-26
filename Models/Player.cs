using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }
    public bool IsDealer { get; }

    public Player(string name, bool isDealer = false)
    {
        Name = name;
        IsDealer = isDealer;
        Hand = new List<Card>();
    }

    public void AddCard(Card card)
    {
        Hand.Add(card);
    }

    public int GetScore()
    {
        int score = 0;
        int aceCount = 0;

        foreach (var card in Hand)
        {
            score += card.Value;
            if (card.Rank == "A") aceCount++;
        }

        while (score > 21 && aceCount > 0)
        {
            score -= 10;
            aceCount--;
        }

        return score;
    }

    public void ShowHand(bool hideFirstCard = false)
    {
        Console.WriteLine($"{Name} tem:");
        for (int i = 0; i < Hand.Count; i++)
        {
            if (hideFirstCard && i == 0 && IsDealer)
                Console.WriteLine("Carta escondida");
            else
                Console.WriteLine(Hand[i]);
        }
        if (!hideFirstCard || !IsDealer)
            Console.WriteLine($"Pontuação: {GetScore()}");
        Console.WriteLine();
    }
}