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