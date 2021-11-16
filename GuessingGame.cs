using System;
using System.Collections.Generic;
using System.Threading;

namespace Activity5._4._1
{
    class GuessingGame
    {
        public static int guessMe { get; protected set; } //if this field is not static, you have no way to check its value without creating objects
        public static Random r { get; private set;  } //making static random object will hep you generate unbiased uniform randoms 
        public static int steps { get; private set; } //count total play turns
        public static int LOW { get; private set; } //lowest guess value 
        public static int HIGH { get; private set; }  //highest guess value
        public static int totalPlayers { get; private set; }
        public string playerName { get; private set; } //you can read player name, but can not change it from main function
        //player name is object dependent non-static field
        static GuessingGame()  //initialize all atatic variables
        {
            r = new Random();
            steps = 0;
            LOW = 0;
            HIGH = 100; //change this value to change the number range
            totalPlayers = 0;
            guessMe = r.Next(LOW, HIGH);
        }

        public GuessingGame(string Name) //constructor for object initialization, set player name, and count total players
        {
            this.playerName = Name;
            totalPlayers++;
        }
        public static int CheckWin(int currentGuess)// common method for all players 
        {
            if(currentGuess == guessMe) return 0;
            else return -1;     
            //return 0 for correct guess, 1 if actual value is bigger, -1 Otherwise.
        }
        public static void GiveHints(int guess) //common hints for all players
        {
            if(guess > guessMe)
            {
                Console.WriteLine("Smaller!");
            }
            else
            {
                Console.WriteLine("Greater!");
            }
            //give some hints: text-output example: guess bigger or guess smaller
        }
        public static int WhoseTurn() //shared field for all players
        {
            return steps % totalPlayers + 1;
            //determine whose turn and return playerID number
        }
        public static int GetWinningPlayerID() //shared filed for all players
        {
            return (steps-1) % totalPlayers + 1;  //a player just won at the last step
        }
        public string GetPlayerName() //Object dependent non-static data
        {
            return this.playerName;//return player name
        }
        
        public int Play() //object dependent non static method
        {
            int input;
            steps++; //update total steps
            Console.WriteLine($"{this.playerName}, enter your guess:"); //write a message like playerName-Enter your guess
            input = int.Parse(Console.ReadLine()); //input a number
            return input;//return the number
        }
    }
}