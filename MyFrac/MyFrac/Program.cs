using System;

public class MyFrac
{
    //поля для чисельника та знаменника
    public long Numerator { get; private set; } //можна напряму брати, неможна напряму міняти
    public long Denominator { get; private set; }

    //конструктор
    public MyFrac(long numerator, long denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменник не може дорівнювати нулю.");
        }

        //якщо знаменник від'ємний - змінюємо знаки чисельника + знаменника
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        //скорочуємо дріб
        long gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    //алгоритм Евкліда для знаходження НСД(GCD)
    private long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
