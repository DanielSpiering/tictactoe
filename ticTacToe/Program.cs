using System;

namespace ticTacToe {
    class Program {
        static void Main(string[] args) {
            string doLoop = "Y";
            //do loop to run program again
            do {
                string[,] board = { { "*", "*", "*" }, { "*", "*", "*" }, { "*", "*", "*" } };
                string markerX = "X";
                string markerO = "O";
                int xCoordinate = 0;
                int yCoordinate = 0;
                bool winnerX = false;
                bool winnerO = false;
                bool emptySpace = true;



                DrawBoard(board);

                while (winnerX == false && winnerO == false) {


                    if (winnerO == false) {
                        //player X
                        xCoordinate = PromptInt("Player X please enter an x coordinate [0,1,2]: ");
                        xCoordinate = ValidateXCoordinate(xCoordinate);

                        yCoordinate = PromptInt("Player X please enter a y coordinate [0,1,2]: ");
                        yCoordinate = ValidateYCoordinate(yCoordinate);

                        emptySpace = ValidateEmptySpace(board, xCoordinate, yCoordinate);

                        while (emptySpace == false) {
                            Console.WriteLine("\nThat space is already taken.");

                            xCoordinate = PromptInt("Please enter an x coordinate [0,1,2]: ");
                            xCoordinate = ValidateXCoordinate(xCoordinate);

                            yCoordinate = PromptInt("Please enter a y coordinate [0,1,2]: ");
                            yCoordinate = ValidateYCoordinate(yCoordinate);

                            emptySpace = ValidateEmptySpace(board, xCoordinate, yCoordinate);
                        }


                        PlaceMarker(board, markerX, xCoordinate, yCoordinate);

                        winnerX = WinCheckX(board);
                        //win check
                    }
                    if (winnerX == false) {
                        //player Y
                        xCoordinate = PromptInt("Player O please enter an x coordinate [0,1,2]: ");
                        xCoordinate = ValidateXCoordinate(xCoordinate);

                        yCoordinate = PromptInt("Player O please enter a y coordinate [0,1,2]: ");
                        yCoordinate = ValidateYCoordinate(yCoordinate);


                        emptySpace = ValidateEmptySpace(board, xCoordinate, yCoordinate);

                        while (emptySpace == false) {
                            Console.WriteLine("\nThat space is already taken.");

                            xCoordinate = PromptInt("Please enter an x coordinate [0,1,2]: ");
                            xCoordinate = ValidateXCoordinate(xCoordinate);

                            yCoordinate = PromptInt("Please enter a y coordinate [0,1,2]: ");
                            yCoordinate = ValidateYCoordinate(yCoordinate);

                            emptySpace = ValidateEmptySpace(board, xCoordinate, yCoordinate);
                        }
                        PlaceMarker(board, markerO, xCoordinate, yCoordinate);

                        winnerO = WinCheckO(board);
                        //win check
                    }
                }//end while to loop game

                //ask to run again
                Console.Write("\nWould you like to run the program again? [Y/N]: ");
                doLoop = Console.ReadLine().Trim().ToUpper();
                //validation
                while (doLoop != "Y" && doLoop != "N") {
                    Console.WriteLine("This is not valid input. Please press 'Y' or 'N'. Run again? [Y/N]: ");
                    doLoop = Console.ReadLine().Trim().ToUpper();
                }//end while 

                Console.Clear();

            } while (doLoop == "Y");
        }//end main
        static string Prompt(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }//end prompt

        static string PromptStringUpper(string message) {
            Console.Write(message);
            return Console.ReadLine().Trim().ToUpper();
        }//end PromptString

        static double PromptDouble(string message) {
            double parsedValue = 0.0;
            while (double.TryParse(Prompt(message), out parsedValue) == false) {
                Console.WriteLine("Invalid Value. Please enter a numerical value.");
            }//end while
            return parsedValue;
        }//end PromptDouble

        static int PromptInt(string message) {
            int parsedValue = 0;
            while (int.TryParse(Prompt(message), out parsedValue) == false) {
                Console.WriteLine("Invalid Value. Please enter an integer.\n");
            }//end while
            return parsedValue;
        }//end PromptInt

        static void DrawBoard(string[,] board) {
            int height = 3;
            int length = 3;

            for (int row = 0; row < length; row++) {
                for (int column = 0; column < height; column++) {
                    Console.Write(board[column, row] + " ");
                }//writes to column
                Console.WriteLine();
            }//write to row
        }//end DrawBoard

        static void PlaceMarker(string[,] board, string marker, int xCoordinate, int yCoordinate) {

            board[xCoordinate, yCoordinate] = marker;
            DrawBoard(board);

        }//end PlaceMarker

        static int ValidateXCoordinate(int xCoordinate) {
            //validation
            while (xCoordinate < 0 || xCoordinate > 2) {
                Console.WriteLine("That location is off the board");
                xCoordinate = PromptInt("Please enter an x coordinate [0,1,2]: ");
            }//end validation
            return xCoordinate;
        }//end ValidateXCoordinate

        static int ValidateYCoordinate(int yCoordinate) {
            //validation
            while (yCoordinate < 0 || yCoordinate > 2) {
                Console.WriteLine("That location is off the board");
                yCoordinate = PromptInt("Please enter a y coordinate [0,1,2]: ");
            }//end validation
            return yCoordinate;
        }//end ValidateYCoordinate

        static bool ValidateEmptySpace(string[,] board, int xCoordinate, int yCoordinate) {
            if (board[xCoordinate, yCoordinate] == "X" || board[xCoordinate, yCoordinate] == "O") {
                return false;
            } else {
                return true;
            }//end if
        }//end ValidateEmptySpace
        static bool WinCheckX(string[,] board) {
            if (board[0, 0] == "X" && board[1, 0] == "X" && board[2, 0] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[0, 1] == "X" && board[1, 1] == "X" && board[2, 1] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[0, 2] == "X" && board[1, 2] == "X" && board[2, 2] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[0, 0] == "X" && board[0, 1] == "X" && board[0, 2] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[1, 0] == "X" && board[1, 1] == "X" && board[1, 2] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[2, 0] == "X" && board[2, 1] == "X" && board[2, 2] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[0, 0] == "X" && board[1, 1] == "X" && board[2, 2] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else if (board[0, 2] == "X" && board[1, 1] == "X" && board[2, 0] == "X") {
                Console.WriteLine("Congratulations player X! You win!");
                return true;
            } else {
                return false;
            }

        }//end WinCheckX
        static bool WinCheckO(string[,] board) {
            if (board[0, 0] == "O" && board[1, 0] == "O" && board[2, 0] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[0, 1] == "O" && board[1, 1] == "O" && board[2, 1] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[0, 2] == "O" && board[1, 2] == "O" && board[2, 2] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[0, 0] == "O" && board[0, 1] == "O" && board[0, 2] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[1, 0] == "O" && board[1, 1] == "O" && board[1, 2] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[2, 0] == "O" && board[2, 1] == "O" && board[2, 2] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[0, 0] == "O" && board[1, 1] == "O" && board[2, 2] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else if (board[0, 2] == "O" && board[1, 1] == "O" && board[2, 0] == "O") {
                Console.WriteLine("Congratulations player O! You win!");
                return true;
            } else {
                return false;
            }//end if

        }//end WinCheckO

    }//end class
}//end namespace
