using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using SquareApi.Models;

namespace SquareApi.Services;

public static class SquareService
{
    static List<Square> Squares { get; }

    static int nextId = 1;

    static SquareService()
    {
        Squares = JsonFileHelper.ReadFromJsonFile<Square>();

    }

    public static List<Square> GetAll() => Squares;

    public static Square? Get(int id) => Squares.FirstOrDefault(s => s.Id == id);

    public static void Add( Square square)
    {
        square.Id = nextId++;
        Squares.Add(square);
        JsonFileHelper.WriteToJsonFile(Squares);
    }

    public static void Delete(int id)
    {
        Squares.RemoveAll(i => i.Id == id);

        JsonFileHelper.WriteToJsonFile(Squares);
    }

    public static void Update(Square square)
    {
        var index = Squares.FindIndex(p => p.Id == square.Id);
        if (index == -1)
            return;

        Squares[index] = square;
        JsonFileHelper.WriteToJsonFile(Squares);
    }
    
}