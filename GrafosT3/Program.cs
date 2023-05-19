using Graph;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

Console.WriteLine("Grafo Lista");
Console.WriteLine("\r");

GraphList graphList = new(false, true);

graphList.LoadFile(System.Environment.CurrentDirectory + "/files/graph.txt");
graphList.GraphPrint();

if (graphList.HasK5())
{
    Console.WriteLine("Possui K5");
    Console.WriteLine("\r");
}
else
{
    Console.WriteLine("Não possui K5");
    Console.WriteLine("\r");
}