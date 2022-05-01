using System;
using System.Collections.Generic;

namespace TICTACTOE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = NewBoard();
            string currentPlayer = "x";

            while (!GameOver(board))
            {
                ShowBoard(board);

                int choice = GetMove(currentPlayer);
                MadeMove(board, choice, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);
            }

            ShowBoard(board);
            Console.WriteLine("GG, well done!");
        }
        static List<string> NewBoard()
        {
            List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }
        static void ShowBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }
        static bool GameOver(List<string> board)
        {
            bool GameOver = false;

            if (Winner(board, "x") || Winner(board, "o") || Tie(board))
            {
                GameOver = true;
            }

            return GameOver;
        }
        static bool Winner(List<string> board, string player)
        {
            bool Winner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                Winner = true;
            }

            return Winner; 
        }
        static bool Tie(List<string> board)
        {
            bool Digit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    Digit = true;
                    break;
                }
            }

            return !Digit;
        }
        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }
        static int GetMove(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string);
            return choice;
        }
        static void MadeMove(List<string> board, int choice, string currentPlayer)
        {
            int index = choice - 1;
            board[index] = currentPlayer;
        }
    }
}