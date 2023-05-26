using Graph;
using System.Diagnostics;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

//WelshPowell welshPowellList = new();
//welshPowellList.LoadFile(System.Environment.CurrentDirectory + "/files/r250-66-65.txt");

//Stopwatch stopwatchWelsh = new Stopwatch();

//// Iniciar o cronômetro
//stopwatchWelsh.Start();

//welshPowellList.WelshPowellColoring();

//stopwatchWelsh.Stop();

//long tempoDecorridoWelsh = stopwatchWelsh.ElapsedMilliseconds;

//Console.WriteLine($"Tempo de execução WelshPowell: {tempoDecorridoWelsh} ms");
//Console.WriteLine("Cores WelshPowell: ");
//Console.WriteLine(welshPowellList.total);

Dsatur dsatur = new();
//dsatur.LoadFile(Environment.CurrentDirectory + "/files/r250-66-65.txt");
dsatur.LoadFile(Environment.CurrentDirectory + "/files/C4000-260-X.txt");

Stopwatch stopwatchDsatur = new Stopwatch();

stopwatchDsatur.Start();
dsatur.DsaturColoring();
stopwatchDsatur.Stop();

long tempoDecorridoDsatur = stopwatchDsatur.ElapsedMilliseconds;

Console.WriteLine($"Tempo de execução Dsatur: {tempoDecorridoDsatur} ms");
Console.WriteLine($"Quantidade de cores usadas: {dsatur.colors.Count}");
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

