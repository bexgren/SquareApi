using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.ObjectPool;

namespace SquareApi.Services;

public static class JsonFileHelper
{
    private static readonly string JsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "squares.json");
    public static List<T> ReadFromJsonFile<T>()
    {
        using StreamReader file = File.OpenText(JsonFilePath);
        JsonSerializer serializer = new();
        return (List<T>)serializer.Deserialize(file, typeof(List<T>));
    }
    public static void WriteToJsonFile<T>(List<T> data)
    {
        using StreamWriter file = File.CreateText(JsonFilePath);
        JsonSerializer serializer = new();
        serializer.Serialize(file, data);
    }
 
   
}