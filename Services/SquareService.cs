using SquareApi.Models;

namespace SquareApi.Services;

public static class SquareService
{
    static List<Square> Squares { get; }

    static int nextId = 1;

    static SquareService()
    {
        Squares = 
        [
            new Square {Id = 0, Color = "rgb(000,000,000)", X = 0, Y = 0}
        ];
    }

    public static List<Square> GetAll() => Squares;

    public static Square? Get(int id) => Squares.FirstOrDefault(p => p.Id == id);

    public static void Add(Square square)
    {
        square.Id = nextId++;
        Squares.Add(square);
    }

    public static void Delete(int id)
    {
        var square = Get(id);
        if (square is null)
            return;

        Squares.Remove(square);
        nextId--;
    }
    
     public static void Update(Square square)
    {
        var index = Squares.FindIndex(p => p.Id == square.Id);
        if(index == -1)
            return;

        Squares[index] = square;
    }
}