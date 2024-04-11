#region Pergunta 2
//Escreva um algoritmo em Portugol (ou na linguagem de sua preferência), que leia um número não determinado de valores.

//Cada conjunto formado por número do aluno (código) e suas três notas.

//Calcular para cada aluno a média ponderada com pesos respectivos de 4 para a MAIOR nota, e 3 para as outras duas notas.

//Escrever o número do aluno (código), suas 3 notas, a média calculada e uma mensagem (APROVADO), se a média for ≥ 6 e (REPROVADO) se a média for < 6.

//Encerrar a leitura de valores assim que for digitado 0 no código de aluno.
#endregion Pergunta 2

int codigoAluno;
double[] notas;

do
{
    notas = new double[3];
    Console.WriteLine("Digite o código do aluno (0 para encerrar):");
    codigoAluno = int.Parse(Console.ReadLine());

    if (codigoAluno == 0)
        break;

    Console.WriteLine("Digite a primeira nota:");
    notas[0] = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite a segunda nota:");
    notas[1] = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite a terceira nota:");
    notas[2] = double.Parse(Console.ReadLine());

    double media = CalcularMediaPonderada(notas);
    string situacao = media >= 6 ? "APROVADO" : "REPROVADO";

    Console.WriteLine($"Aluno: {codigoAluno}");
    Console.WriteLine($"Notas: {notas[0]}, {notas[1]}, {notas[2]}");
    Console.WriteLine($"Média: {media:N2} - {situacao}");
    Console.WriteLine();
} while (codigoAluno != 0);

static double CalcularMediaPonderada(double[] notas)
{
    double maiorNota = notas.Max();
    double media = (4 * maiorNota + 3 * (notas.Sum() - maiorNota)) / 10;
    return media;
}