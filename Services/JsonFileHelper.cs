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
 
    // public static void AddToJsonFile(object data)
    // {
    //     // using StreamWriter file = File.AppendText(JsonFilePath);
    //     // JsonSerializer serializer = new();
    //     // serializer.Serialize(file, data);
    //     // var newObject = Encoding.UTF8.GetBytes(data.ToString());
    //     // using (FileStream fs = new FileStream(JsonFilePath, FileMode.Create))
    //     // {
    //     //     fs.Seek(-2, SeekOrigin.End);
    //     //     fs.Write(newObject, 0, newObject.Length);
    //     //     fs.SetLength(fs.Position);
    //     //     // JsonSerializer serializer = new();
    //     //     // serializer.Serialize(file, data);

    //     // }
    //     // }
    //         // public static void AddToJsonFile<T>(List<T> data)
    //         // {

    //         //     using (FileStream fs = File.OpenRead(JsonFilePath))
    //         //     {
    //         //         byte[] b = new byte[1024];
    //         //         UTF8Encoding temp = new(true);
    //         //         int readLen;
    //         //         while ((readLen = fs.Read(b, 0, b.Length)) > 0)
    //         //         {
    //         //             Console.WriteLine(temp.GetString(b, 0, readLen));
    //         //         }
    //         //     }
    //         // }
    //         // public static void AddText(FileStream fs, string value)
    //         // {
    //         //     byte[] info = new UTF8Encoding(true).GetBytes(value);
    //         //     fs.Write(info, 0, info.Length);
    //     }
}