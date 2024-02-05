using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogodavelha
{
  
    
       
        
            using System;

class Program
{
    static char[,] board = new char[3, 3]; // Matriz para representar o tabuleiro
    static char currentPlayer = 'X'; // Jogador atual (X ou O)

    static void Main(string[] args)
    {
        InitializeBoard();
        bool gameWon = false;

        // Loop principal do jogo
        while (!gameWon)
        {
            DrawBoard();
            MakeMove();
            gameWon = CheckForWin();
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Alternância entre jogadores
        }

        DrawBoard();
        Console.WriteLine($"Parabéns! O jogador {currentPlayer} venceu!");
    }

    // Inicializa o tabuleiro com espaços em branco
    static void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    // Desenha o tabuleiro na tela
    static void DrawBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + " ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    // Solicita a jogada do jogador atual
    static void MakeMove()
    {
        bool validMove = false;
        while (!validMove)
        {
            Console.Write($"Jogador {currentPlayer}, insira a linha e a coluna (ex: 0 1): ");
            string[] input = Console.ReadLine().Split();
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                validMove = true;
            }
            else
            {
                Console.WriteLine("Jogada inválida. Tente novamente.");
            }
        }
    }

    // Verifica se o jogador atual venceu
    static bool CheckForWin()
    {
        // Verifica linhas e colunas
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }

        // Verifica diagonais
        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        // Verifica empate
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                {
                    return false; // Ainda há espaço vazio, o jogo não acabou
                }
            }
        }
        
        // Se todas as posições estiverem preenchidas e não houver um vencedor, é um empate
        Console.WriteLine("O jogo empatou!");
        Environment.Exit(0);
        return true;
    }
}

        }
    

