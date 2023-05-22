using Graph;
using System.Diagnostics;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

WelshPowell welshPowellList = new();
welshPowellList.LoadFile(System.Environment.CurrentDirectory + "/files/r250-66-65.txt");

Stopwatch stopwatchWelsh = new Stopwatch();

// Iniciar o cronômetro
stopwatchWelsh.Start();

welshPowellList.WelshPowellColoring();

stopwatchWelsh.Stop();

long tempoDecorridoWelsh = stopwatchWelsh.ElapsedMilliseconds;

Console.WriteLine($"Tempo de execução WelshPowell: {tempoDecorridoWelsh} ms");
Console.WriteLine("Cores WelshPowell: ");
Console.WriteLine(welshPowellList.total);

DsaturGraph graphDsaturList = new();
graphDsaturList.LoadFile(System.Environment.CurrentDirectory + "/files/r250-66-65.txt");

Stopwatch stopwatchDsatur = new Stopwatch();

// Iniciar o cronômetro
stopwatchDsatur.Start();

graphDsaturList.DSatur();

stopwatchDsatur.Stop();

long tempoDecorridoDsatur = stopwatchDsatur.ElapsedMilliseconds;

Console.WriteLine($"Tempo de execução Dsatur: {tempoDecorridoDsatur} ms");
Console.WriteLine("Cores Dsatur: ");
Console.WriteLine(graphDsaturList.colorsUsed.Count);

//Console.WriteLine(graphDsaturList.colorsUsed.Count);

struct nodeInfo
{
    public int sat;
    public int deg;
    public int vertex;
}

 
 







//GraphList graphList = new(false, true);

//graphList.LoadFile(System.Environment.CurrentDirectory + "/files/k33.txt");
//graphList.GraphPrint();

//if (graphList.HasK5())
//{
//    Console.WriteLine("Possui K5");
//    Console.WriteLine("\r");
//}
//else
//{
//    Console.WriteLine("Não possui K5");
//    Console.WriteLine("\r");
//}

