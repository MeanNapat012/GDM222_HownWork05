using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int letters = int.Parse(Console.ReadLine());
        int Number = int.Parse(Console.ReadLine());

        string lastCode = GenerateInitialCode(letters, Number);
        int maximumProduct = CalculateMaximumProduct(letters, Number);
        int count = 0;

        List<string> codes = new List<string>();
        List<string> names = new List<string>();

        codes.Add(lastCode);

        while (true)
        {
            string product = Console.ReadLine();

            if (product == "stop")
            {
                break;
            }

            if (count >= maximumProduct)
            {
                count = 0;
                lastCode = GenerateInitialCode(letters, Number);
                codes.Add(lastCode);
            }

            codes.Add(IncrementCode(lastCode, letters, Number));
            names.Add(product);
            lastCode = codes[codes.Count - 1];
            count++;
        }

        string searchCode = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < codes.Count; i++)
        {
            if (codes[i] == searchCode)
            {
                Console.WriteLine(names[i]);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Not found!");
        }
    }

    static string GenerateInitialCode(int letters, int digits)
    {
        string letterPart = new string('A', letters);
        string digitPart = new string('0', digits);
        return letterPart + digitPart;
    }

    static int CalculateMaximumProduct(int letters, int digits)
    {
        return (letters * 26) * (digits * 10);
    }

    static string IncrementCode(string code, int letters, int digits)
    {
        char[] codeArray = code.ToCharArray();
        int lastIndex = letters + digits - 1;

        for (int i = lastIndex; i >= 0; i--)
        {
            char c = codeArray[i];

            if (char.IsDigit(c))
            {
                if (c == '9')
                {
                    codeArray[i] = '0';

                    if (i == 0)
                    {
                        return null;
                    }
                }
                else
                {
                    codeArray[i] = (char)(c + 1);
                    break;
                }
            }
            else if (char.IsLetter(c))
            {
                if (c == 'Z')
                {
                    codeArray[i] = 'A';
                }
                else
                {
                    codeArray[i] = (char)(c + 1);
                    break;
                }
            }
        }

        return new string(codeArray);
    }
}
