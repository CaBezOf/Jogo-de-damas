public class Board
{
    // Matriz para representar as posições no tabuleiro
    private const int size = 8;
    private Piece[,] positions;

    public Board()
    {
        // Inicializa o tabuleiro com posições vazias
        positions = new Piece[size, size];

        // Configura as peças iniciais no tabuleiro
        // Você pode personalizar essa parte com base no layout específico do jogo de damas
        for (int line = 0; line < size; line++)
        {
            for (int column = 0; column < size; column++)
            {
                // Verifica se a posição deve ter uma peça
                if ((line % 2 == 0 && column % 2 != 0) || (line % 2 != 0 && column % 2 == 0))
                {
                    if(row > 3){
                        positions[line, column] = new Piece(line, column, PieceColor.White);
                    }
                    else if(row > 4){
                        positions[line, column] = new Piece(line, column, PieceColor.Black);
                    }
                }
            }
        }
    }

    // Método para obter uma peça em uma posição específica
    public Piece GetPiece(int line, int column)
    {
        return positions[line, column];
    }

    // Método para mover uma peça de uma posição para outra
    public void MovePiece(Piece piece, int newline, int newColumn)
    {
        positions[newline, newColumn] = piece;
        positions[piece.Line, piece.Column] = null;
        piece.Line = newline;
        piece.Column = newColumn;
    }

      public void RemovePiece(int row, int column)
    {
        // Verifica se a posição está dentro dos limites do tabuleiro
        if (IsValidPosition(row, column))
        {
            // Remove a peça definindo-a como null na matriz de peças
            pieces[row, column] = null;
        }
    }

    private bool IsValidPosition(int row, int column)
    {
        // Verifica se a posição está dentro dos limites do tabuleiro
        return row >= 0 && row < 8 && column >= 0 && column < 8;
    }
}