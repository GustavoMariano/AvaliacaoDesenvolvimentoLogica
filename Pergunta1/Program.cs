#region Pergunta 1
//Uma concessionária de carros está vendendo os seus veículos com desconto.

//Faça um algoritmo em Portugol (ou na linguagem de sua preferência) que calcule e exiba o valor do desconto e o valor a ser pago pelo cliente de vários carros.

//O desconto deverá ser calculado de acordo com o ano do veículo.

//• Até 2000 - 12%
//• Acima de 2000 - 7%


//O algoritmo deverá perguntar se deseja continuar calculando desconto até que a resposta seja “N” (Não).

//Informar total de carros com ano até 2000 e total geral.
#endregion Pergunta 1

int totalCarrosAte2000 = 0;
int totalGeral = 0;

string continuar;

do
{
    Console.WriteLine("Informe o ano do veículo:");
    int ano = int.Parse(Console.ReadLine());

    Console.WriteLine("Informe o valor do veículo:");
    double valor = double.Parse(Console.ReadLine());

    double desconto;
    if (ano <= 2000)
    {
        desconto = 0.12;
        totalCarrosAte2000++;
    }
    else
    {
        desconto = 0.07;
    }

    double valorDesconto = valor * desconto;
    double valorFinal = valor - valorDesconto;

    Console.WriteLine($"Valor do desconto: R$ {valorDesconto:N2}");
    Console.WriteLine($"Valor a ser pago: R$ {valorFinal:N2}");

    totalGeral++;

    Console.WriteLine("Deseja continuar calculando desconto? (S/N)");
    continuar = Console.ReadLine().ToUpper();

    if (continuar != "S" && continuar != "N")
    {
        do
        {
            Console.WriteLine("Opção inválida, tente novamente!");
            Console.WriteLine("Deseja continuar calculando desconto? (S/N)");
            continuar = Console.ReadLine().ToUpper();
        } while (continuar != "S" && continuar != "N");
    }

    Console.Clear();
} while (continuar == "S");

Console.WriteLine($"Total de carros com ano até 2000: {totalCarrosAte2000}");
Console.WriteLine($"Total geral: {totalGeral}");