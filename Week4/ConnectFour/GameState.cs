namespace ConnectFour;

public class GameState
{
    public int PlayerTurn { get; private set; } = 1;

    public int CurrentTurn { get; private set; } = 0;

    private int[] board = new int[42];


    public enum WinState
    {
        No_Winner,
        Player1_Wins,
        Player2_Wins,
        Tie
    }


    public void ResetBoard()
    {
        board = new int[42];
        PlayerTurn = 1;
        CurrentTurn = 0;
    }


    public int PlayPiece(byte column)
    {
        for (int row = 5; row >= 0; row--)
        {
            int index = row * 7 + column;

            if (board[index] == 0)
            {
                board[index] = PlayerTurn;

                CurrentTurn++;

                int landingRow = row + 1;

                PlayerTurn = PlayerTurn == 1 ? 2 : 1;

                return landingRow;
            }
        }

        throw new ArgumentException("That column is full.");
    }


    public WinState CheckForWin()
    {
        // Horizontal
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                int index = row * 7 + col;

                if (board[index] != 0 &&
                    board[index] == board[index + 1] &&
                    board[index] == board[index + 2] &&
                    board[index] == board[index + 3])
                {
                    return GetWinner(board[index]);
                }
            }
        }


        // Vertical
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                int index = row * 7 + col;

                if (board[index] != 0 &&
                    board[index] == board[index + 7] &&
                    board[index] == board[index + 14] &&
                    board[index] == board[index + 21])
                {
                    return GetWinner(board[index]);
                }
            }
        }


        // Diagonal down-right
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                int index = row * 7 + col;

                if (board[index] != 0 &&
                    board[index] == board[index + 8] &&
                    board[index] == board[index + 16] &&
                    board[index] == board[index + 24])
                {
                    return GetWinner(board[index]);
                }
            }
        }


        // Diagonal up-right
        for (int row = 3; row < 6; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                int index = row * 7 + col;

                if (board[index] != 0 &&
                    board[index] == board[index - 6] &&
                    board[index] == board[index - 12] &&
                    board[index] == board[index - 18])
                {
                    return GetWinner(board[index]);
                }
            }
        }


        if (CurrentTurn == 42)
        {
            return WinState.Tie;
        }


        return WinState.No_Winner;
    }


    private WinState GetWinner(int player)
    {
        return player == 1
            ? WinState.Player1_Wins
            : WinState.Player2_Wins;
    }
}