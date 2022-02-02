// Start typing here
using System.Collections.Generic;
using System;

public class SnakeAndLadder
{
    Dictionary<int, int> players = new Dictionary<int, int>();

    /// <summary>
    /// Snake and ladder game to choose first winner
    /// </summary>
    /// <param name="playersCount"></param>
    public void SnakeGame(int playersCount)
    {
        //Console.WriteLine("Enter number of players");
        //int playersCount = Convert.ToInt32(Console.ReadLine());
        players = new Dictionary<int, int>();
        if (playersCount < 2)
        {
            Console.WriteLine("Invalid players count. Quitting the game!");
            return;
        }

        for (int i = 0; i < playersCount; i++)
        {
            players.Add(i, 1);

        }

        bool isWinnerFound = false;
        while (!isWinnerFound)
        {
            for (int i = 0; i < playersCount; i++)
            {
                if (!players.ContainsKey(i))
                    continue;
                Random rand = new Random();
                int diceVal = rand.Next(1, 7); //Get dice value
                isWinnerFound = Game(diceVal, i);
                if(isWinnerFound)
                    break;
            }
        }

    }

    private bool Game(int diceVal, int i)
    {

        if ((players[i] + diceVal) <= 100)
            players[i] += diceVal;

        //If snake is encountered
        if (SnakeAndLadderUtility.GetSnakePosition().ContainsKey(players[i]))
            players[i] += SnakeAndLadderUtility.GetSnakePosition()[players[i]];

        //If ladder is encountered
        else if (SnakeAndLadderUtility.GetLadderPosition().ContainsKey(players[i]))
            players[i] += SnakeAndLadderUtility.GetLadderPosition()[players[i]];


        if ((players[i]) == 100)
        {
            Console.WriteLine("Player: " + i + " has won");
            return true;
        }

        return false;

    }

    public static class SnakeAndLadderUtility
    {
        public static Dictionary<int, int> GetSnakePosition()
        {
            Dictionary<int, int> snakePos = new Dictionary<int, int>();
            snakePos.Add(2, -1);
            snakePos.Add(10, -2);
            snakePos.Add(35, -5);
            return snakePos;
        }

        public static Dictionary<int, int> GetLadderPosition()
        {
            Dictionary<int, int> ladderPos = new Dictionary<int, int>();
            ladderPos.Add(3, 1);
            ladderPos.Add(14, 2);
            ladderPos.Add(59, 15);
            return ladderPos;
        }
    }

}


public class GameCaller
{
    public static void Main()
    {
        SnakeAndLadder sn = new SnakeAndLadder();
        sn.SnakeGame(2);
        sn.SnakeGame(2);
        sn.SnakeGame(3);
        sn.SnakeGame(4);

        Console.ReadLine();
    }
}