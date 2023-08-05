

Console.WriteLine("Digite o valor da sua matriz quadrada ");
var input = Console.ReadLine(); 
var valorDaMatriz = int.Parse(input!);

var matrizQuadrada = geraMatrizQuadrada(valorDaMatriz);

Console.WriteLine("Sua matriz quadrada seria:");
Console.WriteLine(MontaMatriz(matrizQuadrada));
Console.WriteLine("Sua matriz quadrada invertida:");
Console.WriteLine(InverteDiagonalMatriz(matrizQuadrada));


string InverteDiagonalMatriz(Dictionary<int, IList<int>> matriz)
{
    var matrizInvertida = new Dictionary<int, IList<int>>();
    int tamanho = matriz.Count;

    for (int i = 1; i <= tamanho; i++)
    {
        var linhaOriginal = matriz[i];
        var linhaInvertida = new List<int>(linhaOriginal);

        int temp = linhaInvertida[i - 1];
        linhaInvertida[i - 1] = linhaInvertida[tamanho - i];
        linhaInvertida[tamanho - i] = temp;

        matrizInvertida.Add(i, linhaInvertida);
    }

    return MontaMatriz(matrizInvertida);
}


string MontaMatriz( Dictionary<int, IList<int>> matriz) 
{
    string resposta = "";
    string Apresentacao = "";
    matriz.ToList().ForEach(x =>
    {
        resposta = "|";
        x.Value.ToList().ForEach(y =>
        {
            resposta += $" {y} ";
        });
        resposta += "|";
        Apresentacao += resposta + "\n";
    });
    return Apresentacao;    

}

Dictionary<int, IList<int>>  geraMatrizQuadrada(int valorMatriz)
{
    var matriz = new Dictionary<int, IList<int>>();
    int valor = 1;
    for (int i = 1; i <= valorMatriz; i++)
    {
        var lista = new List<int>();
        for (int b = 1; b <= valorMatriz; b++) { lista.Add(valor); valor++; }
        matriz.Add(i, lista);
    }
    return matriz;
}


