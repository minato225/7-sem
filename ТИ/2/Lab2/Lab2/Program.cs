Func<double, double> log = Math.Log;
Func<double, double> abs = Math.Abs;
Action<string> print = Console.WriteLine;
Func<double, double, double> pow = Math.Pow;

static double factorial(int i)
{
    if (i == 0) return 1;
    else return i * factorial(i - 1);
}

var (p, e, n) = (0.5, 0.138, 15);

var H = -p * log(p) / log(2.0) - (1 - p) * log(1.0 - p) / log(2.0);
print($"""
    Вероятность P(X) выпадения чёрного шарика = {p}
    Значение e = {e}
    Значение n = {n}
    Энтропия H(X) двоичной случайной величины X = {H}
    Нижняя граница e-типичной последовательности: {(1 - e) * pow(2, n * (H - e))}
    Верхняя граница e-типичной последовательности: {pow(2, n * (H + e))}
    """);

var (sum, totalP) = (0.0, 0.0);
for (var i = 1; i <= n; ++i)
{
    if (abs(i / n - p) <= e / log((1 - p) / p) / log(2))
    {
        //var factN = 1.0;
        //for (int k = 1; k <= n - i; k++)
        //    factN *= (i + k) / k;

        double factN = (factorial(n) / (factorial(i) * factorial(n - i)));

        sum += factN;
        totalP += factN * pow(p, i) * pow(1 - p, n - i);
    }
}

print($"""
    Число всех e-типичных последовательностей: {sum}
    Доля всех e-типичных последовательностей относительно всех возможных последовательностей: {sum / pow(2, n)}
    Сумма вероятностей всех e-типичных последовательностей: {totalP}
    "Pe > 1 - e"? {totalP} {(totalP > 1 - e ? $"> {1 - e} " : $"< {1 - e} не")}выполняется
    """);