using System;
using System.Threading;

namespace tic_tac_toe
{
    class Program
    {
        // initialise each position on the board that we are going to create later on
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // by default player 1 is set
        static int choice; // this holds the choice that the current user has made


        // flag is the var that will represent the game status (-1 Draw, 0 - Still Running, 1 -  Someone has won)
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // clears the console
                Console.WriteLine("Player1: X and Player2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0) // checking which players turn it is
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Board(); // calls the board function () - creates the board
                choice = int.Parse(Console.ReadLine()); // reads the users choice from the console

                // checking whether or not the users choice is available or already taken
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) // determines whether to place a 'X' or 'O' at the chosen position (based on player)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else // if a user makes such a choice (already taken), then the console will prompt them to wait 2 seconds, while it "reloads" (C# Timeout)
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 seconds, as the board is loading again...");
                    Thread.Sleep(2000); // suspends the current thread by an amount of milliseconds
                }
                flag = CheckWin(); // checks if someone has won after each move 
            } 
            while (flag != 1 && flag != -1); // if the game isn't over, then the board will refrech after each move

            Console.Clear(); // clearing the console
            Board(); // refreshing of board

            if (flag == 1) // ... if someone has won 
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else // if it is a draw...
            {
                Console.WriteLine("Draw!");
            }
            Console.ReadLine();

        }
        // board method - creates the board (copy and paste if it does not look as expected when you run the program)
        private static void Board()
        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");

        }

        // checking if someone has won already
        private static int CheckWin()
        {
            #region Horizontal Winning Condition
            // winning condition for first row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            // winning condition for second row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            // winning condition for third row   
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion

            // winning condition for first column       

            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            // winning condition for second column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            // winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            #endregion


            #region Diagonal Winning Condition
            // top right-bottom left winning condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            // top left-bottom right winning condition
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {

                return 1;

            }
            #endregion
            
            #region Checking for Draw
            // if all cells or values filled with X or O then neither player has won the math
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
                {
                return -1;
            }
            #endregion

            else
            {
                return 0;

            }
        }
    }
}
