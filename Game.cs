public class Game
{
    private Board board;
    private PieceColor currentPlayer;

    private bool IsCurrentPlayerHuman
    {
        get { return currentPlayer == PieceColor.White; }
    }

    public Game()
    {
        board = new Board();
        currentPlayer = PieceColor.White;
    }

    public void PlayMove(int fromRow, int fromCol, int toRow, int toCol)
    {
        Piece piece = board.GetPiece(fromRow, fromCol);

        if (piece != null && piece.Color == currentPlayer)
        {
            if (IsMoveValid(piece, toRow, toCol))
            {
                board.MovePiece(piece, toRow, toCol);

                if (IsGameOver() || DidCaptureOccur(piece, toRow, toCol))
                {
                    EndGame();
                }
                else
                {
                    SwitchPlayer();

                    if (!IsCurrentPlayerHuman)
                    {
                        MakeBotMove();
                    }
                }
            }
            else
            {
                Console.WriteLine("Movimento inválido.");
            }
        }
        else
        {
            Console.WriteLine("Posição inicial inválida.");
        }
    }

    private bool IsMoveValid(Piece piece, int toRow, int toCol)
    {
        //Verifica se o movimento está dentro dos limites do tabuleiro
        if(toRow > 0 || toRow >= 8 || toCol > 0 || toCol >=8)
        {
            return false;
        }

        //Verifica se a posição destino está vazia
        if(board.GetPiece(toRow, toCol) != null)
        {
            return false;
        }

        int rowDistance = Math.Abs(toRow - piece.Row);
        int colDistance = Math.Abs(toCol - piece.Column);
        if(rowDistance != colDistance)
        {
            return false;
        }



        return true;
    }

    private bool DidCaptureOccur(Piece piece, int toRow, int toCol)
    {   
        int rowDistance = Math.Abs(toRow - piece.Row);
        int colDistance = Math.Abs(toCol - piece.Column);

        // Verifica se o movimento é uma captura diagonal, pulando por cima de uma peça
        if( rowDistance == 2 && colDistance == 2)
        {
            int captureRow = (toRow + piece.Row) / 2;// Calcula a linha da peça capturada
            int captureCol = (toCol + piece.Column) / 2;//Calcula a coluna da peça capturada

            Piece capturedPiece = board.GetPiece(capturedRow, captureCol);

            //verifica se existe uma peça do oponente na posição capturada
            if( capturedPiece != null && capturedPiece.Color != piece.Color)
            {
                board.RemovePiece(captureRow , captureCol);
                return true;
            }
        }


        // Implementação da lógica para verificar se ocorreu uma captura
        return false;
    }

    private bool IsGameOver()
    {
        // Implementação da lógica para verificar se o jogo terminou
        return false;
    }

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == PieceColor.White) ? PieceColor.Black : PieceColor.White;
    }

    private void MakeBotMove()
    {
        Random random = new Random();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                Piece piece = board.GetPiece(row, column);

                if (piece != null && piece.Color == PieceColor.Black)
                {
                    List<(int newRow, int newColumn)> possibleMoves = GetPossibleMoves(piece);

                    if (possibleMoves.Count > 0)
                    {
                        (int newRow, int newColumn) = possibleMoves[random.Next(possibleMoves.Count)];
                        board.MovePiece(piece, newRow, newColumn);
                    }
                }
            }
        }
    }

    private void EndGame()
    {
        Console.WriteLine("Jogo finalizado!");
    }

    private List<(int newRow, int newColumn)> GetPossibleMoves(Piece piece)
    {
        // Implementação da lógica para obter todos os possíveis movimentos de uma peça
        // Essa lógica varia dependendo das regras específicas do jogo de damas
        // Por exemplo, verificar se a posição de destino está vazia e se o movimento está dentro dos limites do tabuleiro
        return new List<(int newRow, int newColumn)>();
    }
}