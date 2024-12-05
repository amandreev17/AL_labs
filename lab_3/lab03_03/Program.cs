CurrencyUSD uSD1 = new CurrencyUSD(0.9, 90, 10);
CurrencyRUB rUB1 = (CurrencyRUB)uSD1;
Console.WriteLine($"rub: {rUB1.Value}");
CurrencyEUR eUR1 = (CurrencyEUR)uSD1;
Console.WriteLine($"euro: {eUR1.Value}");

CurrencyRUB rUB2 = new CurrencyRUB(0.01, 1000, 0.011);
CurrencyUSD uSD2 = (CurrencyRUB)rUB2;
Console.WriteLine($"usd: {uSD2.Value}");
CurrencyEUR eUR2 = (CurrencyEUR)rUB2;
Console.WriteLine($"euro: {eUR2.Value}");


class Currency
{
    public double Value { get; set; }
    public Currency(double v)
    {
        Value = v;
    }
}

class CurrencyUSD : Currency
{
    public double CurrencyEUR { get; set; }
    public double CurrencyRUB { get; set; }

    public CurrencyUSD(double eur, double rub, double usd): base(usd)
    {
        CurrencyEUR = eur;
        CurrencyRUB = rub;
    }

    public static implicit operator CurrencyEUR(CurrencyUSD uSD)
    {
        return new CurrencyEUR(uSD.Value * uSD.CurrencyEUR, uSD.CurrencyRUB / uSD.CurrencyEUR, 1 / uSD.CurrencyEUR);
    }

    public static implicit operator CurrencyRUB(CurrencyUSD uSD)
    {
        return new CurrencyRUB(uSD.CurrencyEUR / uSD.CurrencyRUB, uSD.Value * uSD.CurrencyRUB, 1 / uSD.CurrencyRUB);
    }
}

class CurrencyEUR : Currency
{
    public double CurrencyUSD { get; set; }
    public double CurrencyRUB { get; set; }

    public CurrencyEUR(double eur, double rub, double usd) : base(eur)
    {
        CurrencyUSD = usd;
        CurrencyRUB = rub;
    }

    public static implicit operator CurrencyUSD(CurrencyEUR eUR)
    {
        return new CurrencyUSD(1 / eUR.CurrencyUSD, eUR.CurrencyRUB / eUR.CurrencyUSD, eUR.Value * eUR.CurrencyUSD);
    }

    public static implicit operator CurrencyRUB(CurrencyEUR eUR)
    {
        return new CurrencyRUB(1 / eUR.CurrencyRUB, eUR.Value * eUR.CurrencyRUB, eUR.CurrencyUSD / eUR.CurrencyRUB);
    }
}

class CurrencyRUB : Currency
{
    public double CurrencyUSD { get; set; }
    public double CurrencyEUR { get; set; }

    public CurrencyRUB(double eur, double rub, double usd) : base(rub)
    {
        CurrencyUSD = usd;
        CurrencyEUR = eur;
    }

    public static implicit operator CurrencyUSD(CurrencyRUB rUB)
    {
        return new CurrencyUSD(rUB.CurrencyEUR / rUB.CurrencyUSD, 1 / rUB.CurrencyUSD, rUB.Value * rUB.CurrencyUSD);
    }

    public static implicit operator CurrencyEUR(CurrencyRUB rUB)
    {
        return new CurrencyEUR(rUB.Value * rUB.CurrencyEUR, 1 / rUB.CurrencyEUR, rUB.CurrencyUSD / rUB.CurrencyEUR);
    }
}