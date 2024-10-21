public class Program
{
    public static void Main(string[] args)
    {
        MyFrac frac1 = null;
        MyFrac frac2 = null;
        //перевірка конструктора
        try
        {
            frac1 = new MyFrac(1, 2); // 1/2
            frac2 = new MyFrac(3, 4); // 3/4
            MyFrac frac3 = new MyFrac(-2, -3); // 2/3
            MyFrac frac4 = new MyFrac(5, -6); // -5/6
            Console.WriteLine($"frac1: {frac1}");
            Console.WriteLine($"frac2: {frac2}");
            Console.WriteLine($"frac3: {frac3}");
            Console.WriteLine($"frac4: {frac4}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        //перевірка ToStringWithIntegerPart
        MyFrac frac5 = new MyFrac(7, 3); // 7/3
        Console.WriteLine($"ToStringWithIntegerPart of frac5: {MyFrac.ToStringWithIntegerPart(frac5)}");

        //перевірка DoubleValue
        Console.WriteLine($"DoubleValue of frac1: {MyFrac.DoubleValue(frac1)}");

        //перевірка додавання
        MyFrac sum = MyFrac.Plus(frac1, frac2);
        Console.WriteLine($"Sum of frac1 and frac2: {sum}");

        //перевірка віднімання
        MyFrac difference = MyFrac.Minus(frac1, frac2);
        Console.WriteLine($"Difference of frac1 and frac2: {difference}");

        //перевірка множення
        MyFrac product = MyFrac.Multiply(frac1, frac2);
        Console.WriteLine($"Product of frac1 and frac2: {product}");

        //перевірка ділення
        MyFrac quotient = MyFrac.Divide(frac1, frac2);
        Console.WriteLine($"Quotient of frac1 and frac2: {quotient}");

        //перевірка суми ряду
        MyFrac sum1 = MyFrac.CalcSum1(5); //сума дробів
        Console.WriteLine($"CalcSum1(5): {sum1}");

        //перевірка добутку ряду
        MyFrac sum2 = MyFrac.CalcSum2(5); //добуток дробів
        Console.WriteLine($"CalcSum2(5): {sum2}");
    }
}
