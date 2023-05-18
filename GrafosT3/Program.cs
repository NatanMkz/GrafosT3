using Graph;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

Console.WriteLine("Grafo Lista");
Console.WriteLine("\r");

GraphList graphList = new(false, true);

graphList.LoadFile(System.Environment.CurrentDirectory + "/graph.txt");
graphList.GraphPrint();
