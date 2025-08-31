using System.Collections.Generic;
using DataStructures;

var list = new DataStructures.LinkedList<int>();


list.Add(1);
list.Add(2);
list.Add(3);


var listString = new DataStructures.LinkedList<string>();

listString = ["fine", "fineman", "fish"];


listString.InsertAt(1, "her");
listString.RemoveAt(2);


foreach (var item in listString)
{
    Console.Write(item+ ",");
}
Console.WriteLine();

Console.WriteLine($"Count: {list.Count}");




