using System.Linq.Expressions;

namespace Tic_Tac_ToeGame
{
    internal class TicTacToe
    {
        static void Main(string[] args)
        {
            //declare variables
            string[,] board = new string[3, 3] { {"*", "*", "*"},
                                                 {"*", "*", "*"},
                                                 {"*", "*", "*"} };
            string playerOneInput = "X";
            string playerTwoInput = "O";

            int x_coord = 0;
            int y_coord = 0;
            int winState;
            int tieState;

            //outputs the blank board to the console
            drawBoard(board);

            //loops turns between players until a winner is declared
            do
            {
                //resets tieState to 1 to continue checking if the game has tied
                tieState = 1;

                //runs a function to prompt the player on where they want to place their marker on the board
                placeMarker(board, playerOneInput, x_coord, y_coord);
                //checks if player one has won the game
                winState = winCheck(board, playerOneInput);

                //checks if there is a vacant area still on the table
                foreach (string element in board)
                {
                    if (element == "*")
                        tieState = 0;
                }
                //and exits the code if there are no more spots to play on
                if (tieState == 1)
                {
                    Console.WriteLine("The Game was a Tie!");
                    System.Environment.Exit(0);
                }

                //runs player two's turn if player one did not win the game
                if (winState != 1)
                {
                    //runs a function to prompt the player on where they want to place their marker on the board
                    placeMarker(board, playerTwoInput, x_coord, y_coord);
                    //checks if player two has won the game
                    winState = winCheck(board, playerTwoInput);
                }

                //checks if there is a vacant area still on the table
                foreach (string element in board)
                {
                    if (element == "*")
                        tieState = 0;
                }
                //and exits the code if there are no more spots to play on
                if (tieState == 1)
                {
                    Console.WriteLine("The Game was a Tie!");
                    System.Environment.Exit(0);
                }

            } while (winState != 1);
        }//END MAIN

        //outputs the board to the console
        static void drawBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
        //runs the process of allowing the user to place their marker at a certain area of the board
        static void placeMarker(string[,] board, string marker, int x_coord, int y_coord) 
        {
            //declare variables
            string currentPlayer = "";
            bool isVacant = false;

            //determines which player's turn it is to output the proper prompt in the console
            if (marker == "X")
                currentPlayer = "Player One: ";
            else if (marker == "O")
                currentPlayer = "Player Two: ";

            //repeats until the user picks a valid area to place their marker
            do
            {
                Console.WriteLine(currentPlayer + "What row do you want to place your marker on? (enter a number between 0 - 2 representing rows from top to bottom)");

                //validates variable
                x_coord = GetInt();
                x_coord = NumRangeCheck(x_coord);

                drawBoard(board);
                Console.WriteLine(currentPlayer + "What column do you want to place your marker on? (enter a number between 0 - 2 representing columns from left to right)");
                
                //validates variable
                y_coord = GetInt();
                y_coord = NumRangeCheck(y_coord);

                //runs a function to check if the spot the user picked is vacant and a valid spot to place their marker
                isVacant = VacancyCheck(isVacant, x_coord, y_coord, board);

            } while (isVacant == false);
            
            //places the player's marker at the desired spot on the board
            board[x_coord, y_coord] = marker;

            drawBoard(board);
        }
        //checks all the possible win conditions of the game and sets winState to 1 if one of the win conditions is true
        //and then outputs which player has won based on the playerInput variable passed to the function
        static int winCheck(string[,] board , string playerInput)
        {
            //declares variable
            int winState = 0;

            //checks if any of the win conditions for tic tac toe has been achieved
            switch (playerInput) 
            {
                case var expression when (playerInput == board[0, 0] && playerInput == board[0, 1] && playerInput == board[0, 2]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
                case var expression when (playerInput == board[1, 0] && playerInput == board[1, 1] && playerInput == board[1, 2]):
                    winState = 1;
                    break;
                case var expression when (playerInput == board[2, 0] && playerInput == board[2, 1] && playerInput == board[2, 2]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
                case var expression when (playerInput == board[0, 0] && playerInput == board[1, 0] && playerInput == board[2, 0]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
                case var expression when (playerInput == board[0, 1] && playerInput == board[1, 1] && playerInput == board[2, 1]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
                case var expression when (playerInput == board[0, 2] && playerInput == board[1, 2] && playerInput == board[2, 2]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
                case var expression when (playerInput == board[0, 0] && playerInput == board[1, 1] && playerInput == board[2, 2]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
                case var expression when (playerInput == board[0, 2] && playerInput == board[1, 1] && playerInput == board[2, 0]):
                    if (playerInput == "X")
                        Console.WriteLine("Player 1 Wins!");
                    else if (playerInput == "O")
                        Console.WriteLine("Player 2 Wins!");

                    winState = 1;
                    break;
            }

            return winState;
        }

        static int GetInt()
        {
            string userInput = "";
            bool tester = true;

            do
            {
                if (!tester)
                {
                    Console.WriteLine("Not a number. Try Again.");
                }

                userInput = Console.ReadLine();

                tester = int.TryParse(userInput, out _);

            } while (!tester);

            return int.Parse(userInput);
        }

        static int NumRangeCheck(int userInput)
        {
            //runs while user input is not within the range of 0 - 2
            while (userInput < 0 || userInput > 2)
            {
                //outputs an error and prompts the user to reattempt the input
                Console.WriteLine("Error: value inputted is not within the range of 0 - 2.");
                Console.WriteLine("Please enter a value between 0 - 2.");

                userInput = GetInt();

                Console.Clear();
            }

            Console.Clear();

            //returns to where it is called after the value is in the correct range
            return userInput;
        }

        static bool VacancyCheck(bool isVacant, int x_coord, int y_coord, string[,] board)
        {
            if (board[x_coord, y_coord] != "*")
            {
                isVacant = false;

                drawBoard(board);

                Console.WriteLine("Area is not vacant. Try a different area.");
            }
            else if (board[x_coord, y_coord] == "*")
            {
                isVacant = true;
            }

            return isVacant;
        }

    }//END CLASS

}//END NAMESPACE
