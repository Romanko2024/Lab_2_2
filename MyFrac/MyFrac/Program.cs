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

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
    //виділяє цілу частину з дробу
    public static string ToStringWithIntegerPart(MyFrac frac)
    {
        long integerPart = frac.Numerator / frac.Denominator; //виділяє цілу частину ділення
        long remainder = frac.Numerator % frac.Denominator;   //обчислює залишок від ділення 

        if (remainder == 0)
        {
            return integerPart.ToString(); // if залишок нуль, результат — ціле число
        }

        return $"{integerPart}+{Math.Abs(remainder)}/{frac.Denominator}"; // ціла частина+дробова частина (abs щоб не було мінус дробова частина), а чи може він взагаліф бути від'ємним....
    }
    //дріб у дійсне число
    public static double DoubleValue(MyFrac frac)
    {
        return (double)frac.Numerator / frac.Denominator; //ділимо дріб і приводимо результат до типу double
    }
    //додавання двох дробів
    public static MyFrac Plus(MyFrac f1, MyFrac f2)
    {
        long numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator; //обчислюємо новий чисельник
        long denominator = f1.Denominator * f2.Denominator; //новий знаменник (добуток знаменників)
        return new MyFrac(numerator, denominator); // новйи дріб (конструктор скоротить)
    }
    //віднімання дробів
    public static MyFrac Minus(MyFrac f1, MyFrac f2)
    {
        long numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator; 
        long denominator = f1.Denominator * f2.Denominator; 
        return new MyFrac(numerator, denominator); 
    }
    //мнроження дробів
    public static MyFrac Multiply(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator); 
    }
    //ділення
    public static MyFrac Divide(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator); //множимо на обернений дріб
    }
    //
}
