#region Pergunta 4
//Escreva um algoritmo em Portugol (ou na linguagem de sua preferência), para realizar o recálculo de Boletos.
//Ele deverá ler a data de vencimento original, a data de vencimento nova (data de pagamento) e valor do boleto, e deverá apresentar o valor do boleto recalculado, e o valor total dos juros do período.

//Você deve considerar:

//*Valor dos juros por dia: R$ 0,03 e Valor da multa: R$ 2,00 (valores fixos)
//* As datas podem ser informadas com o tipo de dados data
//* As datas podem ser comparadas com os Operadores Relacionais, e podem ser usados Operadores Aritméticos
//* Ex.: data < -data + 1 // Acrescenta um dia na data
//* Ex.: numDias < -dataFim - dataInicio // Retorna o número de dias entre as duas datas
//* Existe uma função VerificaFeriado(data : data) : lógico
//* Essa função retorna VERDADEIRO quando uma data for feriado, e FALSO caso contrário
//* Existe uma função VerificaFinalDeSemana(data : data) : lógico
//* Essa função retorna VERDADEIRO quando uma data for final de semana, e FALTO caso contrário

//As regras de recálculo que devem ser respeitadas:

//1.Se a data de vencimento for final de semana ou feriado, e a data de pagamento no dia útil consecutivo, não deve ser cobrado juros nem multa. Ex.: Vencimento sábado e pagamento na segunda-feira;
//2.Se a data de vencimento for final de semana ou feriado, e o pagamento for posterior ao dia útil consecutivo, deve ser cobrado juros de todo o período. Ex.: Vencimento sábado e pagamento na terça-feira: três dias de juros + multa.
//3. Se a data de vencimento for feriado, e o pagamento no dia seguinte (dia útil), não deve ser cobrado juros nem multa. Ex.: Vencimento 01/maio/2023 e pagamento 02/maio/2023;
//4.Se a data de vencimento for feriado antecessor a um final de semana, e o pagamento for na segunda-feira (dia útil consecutivo), não deve ser cobrado juros nem multa. Ex.: Vencimento 21/abril/2023 e pagamento 24/abril/2023;
//5.Se a data de vencimento for feriado, e o pagamento dois dias úteis consecutivos após feriado, deve ser cobrado jutos de todo o período. Ex. Vencimento 07/abril/2023 e pagamento 11/abril/2023: quatro dias de juros + multa;
//6.Se o vencimento for dia útil, e o pagamento no mesmo dia, não deve ser cobrado juros nem multa;
//7.Se a data de pagamento for anterior à data de vencimento, não deve ser cobrado juros nem multa;
//8.Se o vencimento for dia útil, e o pagamento no dia útil consecutivo, dever ser cobrado juros e multa de apenas um período. Ex.: Vencimento 08/maio/2023 pagamento 09/maio/2023: um dia de juros + multa.
#endregion Pergunta 4

double valorJurosPorDia = 0.03;
double valorMulta = 2.00;

Console.Write("Informe a data de vencimento original (DD/MM/AAAA): ");
DateTime dataVencimentoOriginal = ConverterData(Console.ReadLine());

Console.Write("Informe o valor do boleto: R$ ");
double valorBoleto = double.Parse(Console.ReadLine());

Console.Write("Informe a data de vencimento nova (data de pagamento) (DD/MM/AAAA): ");
DateTime dataVencimentoNova = ConverterData(Console.ReadLine());

TimeSpan diferencaDatas = dataVencimentoNova - dataVencimentoOriginal;
int diasAtraso = (int)diferencaDatas.TotalDays;

if (diasAtraso < 0)
    Console.WriteLine("A data de pagamento não pode ser anterior à data de vencimento.");
else
{
    bool vencimentoDiaUtil = dataVencimentoOriginal.DayOfWeek != DayOfWeek.Saturday && dataVencimentoOriginal.DayOfWeek != DayOfWeek.Sunday;
    bool pagamentoDiaUtil = dataVencimentoNova.DayOfWeek != DayOfWeek.Saturday && dataVencimentoNova.DayOfWeek != DayOfWeek.Sunday;
    bool vencimentoFeriado = VerificaFeriado(dataVencimentoOriginal);
    bool vencimentoFinalSemana = dataVencimentoOriginal.DayOfWeek == DayOfWeek.Saturday || dataVencimentoOriginal.DayOfWeek == DayOfWeek.Sunday;

    if (vencimentoFinalSemana || vencimentoFeriado)
    {
        if (pagamentoDiaUtil)
        {
            Console.WriteLine("Valor do boleto recalculado: R$ " + valorBoleto);
            Console.WriteLine("Valor total dos juros do período: R$ 0.00");
        }
        else
        {
            double valorJuros = (diasAtraso + 1) * valorJurosPorDia;
            double valorTotal = valorBoleto + valorJuros + valorMulta;
            Console.WriteLine("Valor do boleto recalculado: R$ " + valorTotal);
            Console.WriteLine("Valor total dos juros do período: R$ " + valorJuros.ToString("0.00"));
        }
    }
    else if (vencimentoFeriado && VerificaFinalDeSemana(dataVencimentoNova.AddDays(1)))
    {
        Console.WriteLine("Valor do boleto recalculado: R$ " + valorBoleto);
        Console.WriteLine("Valor total dos juros do período: R$ 0.00");
    }
    else if (vencimentoFeriado && pagamentoDiaUtil)
    {
        Console.WriteLine("Valor do boleto recalculado: R$ " + valorBoleto);
        Console.WriteLine("Valor total dos juros do período: R$ 0.00");
    }
    else if (vencimentoFeriado && VerificaFeriado(dataVencimentoNova.AddDays(1)))
    {
        double valorJuros = (diasAtraso + 2) * valorJurosPorDia;
        double valorTotal = valorBoleto + valorJuros + valorMulta;
        Console.WriteLine("Valor do boleto recalculado: R$ " + valorTotal);
        Console.WriteLine("Valor total dos juros do período: R$ " + valorJuros.ToString("0.00"));
    }
    else if (vencimentoDiaUtil && pagamentoDiaUtil && diasAtraso == 0)
    {
        Console.WriteLine("Valor do boleto recalculado: R$ " + valorBoleto);
        Console.WriteLine("Valor total dos juros do período: R$ 0.00");
    }
    else if (pagamentoDiaUtil && diasAtraso == 1)
    {
        if (vencimentoDiaUtil)
        {
            double valorJuros = valorJurosPorDia;
            double valorTotal = valorBoleto + valorJuros + valorMulta;
            Console.WriteLine("Valor do boleto recalculado: R$ " + valorTotal);
            Console.WriteLine("Valor total dos juros do período: R$ " + valorJuros.ToString("0.00"));
        }
        else
        {
            Console.WriteLine("Valor do boleto recalculado: R$ " + valorBoleto);
            Console.WriteLine("Valor total dos juros do período: R$ 0.00");
        }
    }
    else
    {
        double valorJuros = diasAtraso * valorJurosPorDia;
        double valorTotal = valorBoleto + valorJuros + valorMulta;
        Console.WriteLine("Valor do boleto recalculado: R$ " + valorTotal);
        Console.WriteLine("Valor total dos juros do período: R$ " + valorJuros.ToString("0.00"));
    }
}

static bool VerificaFeriado(DateTime data)
{
    if (data == new DateTime(2023, 01, 01))
        return true;
    else if (data == new DateTime(2023, 02, 20))
        return true;
    else if (data == new DateTime(2023, 02, 21))
        return true;
    else if (data == new DateTime(2023, 04, 07))
        return true;
    else if (data == new DateTime(2023, 04, 21))
        return true;
    else if (data == new DateTime(2023, 05, 01))
        return true;
    else if (data == new DateTime(2023, 06, 08))
        return true;
    else if (data == new DateTime(2023, 09, 07))
        return true;
    else if (data == new DateTime(2023, 10, 12))
        return true;
    else if (data == new DateTime(2023, 11, 02))
        return true;
    else if (data == new DateTime(2023, 11, 15))
        return true;
    else if (data == new DateTime(2023, 12, 25))
        return true;

    return false;
}

static bool VerificaFinalDeSemana(DateTime data)
{
    return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
}

static DateTime ConverterData(string dataString)
{
    return new DateTime(
        int.Parse(dataString.Split('/')[2]),
        int.Parse(dataString.Split('/')[1]),
        int.Parse(dataString.Split('/')[0])
        );
}