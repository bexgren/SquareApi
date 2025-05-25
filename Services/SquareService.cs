
using Microsoft.AspNetCore.Mvc;
using SquareApi.Models;

namespace SquareApi.Services;

public static class SquareService
{
    static List<Square> Squares { get; }

    static SquareService()
    {
        Squares = JsonFileHelper.ReadFromJsonFile<Square>();
    }

    public static List<Square> GetAll() => Squares;

    public static Square? Get(int id) => Squares.FirstOrDefault(s => s.id == id);

    public static void Add( Square square)
    {
        Squares.Add(square);
        JsonFileHelper.WriteToJsonFile(Squares);
    }

    public static void Delete(int id)
    {
        Squares.Clear();
        JsonFileHelper.WriteToJsonFile(Squares);
    }

    public static void Update(Square square)
    {
        Squares[0] = square;
        JsonFileHelper.WriteToJsonFile(Squares);
    }
    public static void DeleteAll(Square square)
    {
        var count = Squares.Count;
        Squares.RemoveRange(1, count);
        Squares[0] = square;
        JsonFileHelper.WriteToJsonFile(Squares);
    }
}