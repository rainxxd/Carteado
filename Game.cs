using System;

public class Game
{
    private Deck deck;
    private Player player;
    private Player dealer;

    public Game()
    {
        deck = new Deck();
        player = new Player("Jogador");
        dealer = new Player("Dealer", true);
    }

    public void Start()
    {
        Console.WriteLine("Bem-vindo ao Blackjack!\n");

        player.AddCard(deck.DrawCard());
        dealer.AddCard(deck.DrawCard());
        player.AddCard(deck.DrawCard());
        dealer.AddCard(deck.DrawCard());

        player.ShowHand();
        dealer.ShowHand(hideFirstCard: true);

        while (player.GetScore() < 21)
        {
            Console.Write("Deseja [P]egar ou [M]anter? ");
            string input = Console.ReadLine().ToUpper();
            if (input == "P" || input == "p")
            {
                player.AddCard(deck.DrawCard());
                player.ShowHand();
            }
            else if (input == "M" || input == "m")
            {
                break;
            }
        }

        dealer.ShowHand();
        while (dealer.GetScore() < 17)
        {
            dealer.AddCard(deck.DrawCard());
            dealer.ShowHand();
        }

        int playerScore = player.GetScore();
        int dealerScore = dealer.GetScore();

        Console.WriteLine($"Pontuação final - Jogador: {playerScore}, Dealer: {dealerScore}");

        if (playerScore > 21)
            Console.WriteLine("Você estourou! Dealer vence.");
        else if (dealerScore > 21 || playerScore > dealerScore)
            Console.WriteLine("Você venceu!");
        else if (playerScore == dealerScore)
            Console.WriteLine("Empate!");
        else
            Console.WriteLine("Dealer venceu!");
    }
}