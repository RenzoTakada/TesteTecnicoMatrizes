
//Montando Matriz A
Console.WriteLine("Digite o numero de linhas da matriz  A");
int linhas = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o numero de colunas da matriz  A");
int colunas  = int.Parse(Console.ReadLine());

var matrizPrincipal = GeraMatriz(linhas,colunas,true);

//Montando SubMatriz B
Console.WriteLine("Digite o numero de linhas da SubMatriz B");
int linhasB = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o numero de colunas da SubMatriz B");
int colunasB = int.Parse(Console.ReadLine());

var matrizB = GeraMatriz(linhasB, colunasB, false);

//Aprensentação
Console.WriteLine($"Sua Matriz A {linhas}X{colunas}: ");
Console.Write(MontaMatriz(matrizPrincipal));

Console.WriteLine($"Sua SubMatriz B {linhasB}X{colunasB}: ");
Console.Write(MontaMatriz(matrizB));

var resultado = ContadorDeOcorrencias(matrizPrincipal, matrizB);

Console.WriteLine($"O total de vezes que a SubMatriz B pode ser entrada em A: {resultado}");

//Funções

 int ContadorDeOcorrencias(Dictionary<int, IList<int>> matrizA, Dictionary<int, IList<int>> matrizB)
{
    int count = 0;
    int linhasA = matrizA.Count;
    int colunasA = matrizA[1].Count;
    int linhasB = matrizB.Count;
    int colunasB = matrizB[1].Count;

    for (int i = 1; i <= linhasA - linhasB + 1; i++)
    {
        for (int j = 1; j <= colunasA - colunasB + 1; j++)
        {
            if (SubMatrizIgual(i, j, matrizA, matrizB))
            {
                count++;
            }
        }
    }

    return count;
}

 bool SubMatrizIgual(int linhaA, int colunaA, Dictionary<int, IList<int>> matrizA, Dictionary<int, IList<int>> matrizB)
{
    foreach (var (linhaB, valoresB) in matrizB)
    {
        if (!matrizA.ContainsKey(linhaA + linhaB - 1))
            return false;

        var valoresA = matrizA[linhaA + linhaB - 1];
        var valoresSubmatrizB = matrizB[linhaB];

        for (int colunaB = 0; colunaB < valoresSubmatrizB.Count; colunaB++)
        {
            if (!valoresA.Contains(valoresSubmatrizB[colunaB]))
                return false;
        }
    }

    return true;
}


Dictionary<int, IList<int>> GeraMatriz(int linhasMatriz , int colunasMatriz,bool tipoPrincipal)
 {
    var taamanho =tipoPrincipal == true ? 15 : 10;
    var matriz = new Dictionary<int, IList<int>>();
    for (int i = 1; i <= linhasMatriz; i++)
    {
        var lista = new List<int>();
        var valorMatriz = i;
        for (int j = 1; j <= colunasMatriz; j++)
        {
            
            lista.Add(valorMatriz);
            valorMatriz++;
        }
        matriz.Add(i, lista);
    }   
        return matriz;
 }

string MontaMatriz(Dictionary<int, IList<int>> matriz)
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


