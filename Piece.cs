public class Piece
{
    // Propriedades da peça
    public int Row { get; set; }
    public int Column { get; set; }
    public PieceColor Color { get; }

    public Piece(int row, int column, PieceColor color)
    {
        Row = row;
        Column = column;
        Color = color;
    }

    // Enum para representar a cor das peças
    public enum PieceColor
    {
        White,
        Black
    }
}