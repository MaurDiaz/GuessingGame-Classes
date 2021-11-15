using System;
using System.Collections.Generic;
using System.Threading;

namespace Activity5._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            string playerName;
            List<GuessingGame> players = new List<GuessingGame>();  //list of objects
            do  //adding players
            {   Console.WriteLine("Please enter a player name: ");
                playerName = Console.ReadLine();
                GuessingGame newPlayer = new GuessingGame(playerName); //add a player
                players.Add(newPlayer);                              //add list of player objects
                Console.WriteLine("Another player? :Y/N ");
                choice = Console.ReadLine();
            } while (choice == "y" || choice == "Y");

            //Console.WriteLine("Assume You dont Know The Number: " + GussingGame.guessMe); //this is secret (shared) number, players will guess
            //Thread.Sleep(1000);
            int currentGuess;
            do
            {
                Console.Clear();
                Console.WriteLine("Guess a number in range {0} to {1}: ", GuessingGame.LOW, GuessingGame.HIGH); //accessing through class
                Console.WriteLine("Now playing player: {0}", GuessingGame.WhoseTurn()); //accessing class to determine who will play
                currentGuess = players[GuessingGame.WhoseTurn() - 1].Play();    //right object will respond by sharing game world
                GuessingGame.GiveHints(currentGuess);  //accessing through class, shared message for all objects
                Thread.Sleep(1000); 
            } while (GuessingGame.CheckWin(currentGuess) != 0); //common/shared message

            Console.WriteLine("Congratulations! Player {0}: {1} Wins...", GuessingGame.GetWinningPlayerID(), players[GuessingGame.GetWinningPlayerID()-1].GetPlayerName()); 
            Console.WriteLine("Total attempt counted for all players was {0}.", GuessingGame.steps); //accessing through class field which is shared by all objects
            Console.ReadKey();
        }
    }
}
