using System;
using System.IO;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Collections.Specialized.BitVector32;
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory,"Numbers.txt");

        List<int> numbers = new List<int>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }
        }
        /*Конвертуемо наш список чисел у массив*/
        int[] numbersArray = numbers.ToArray();
        int minValue = numbersArray.Min();
        int maxValue = numbersArray.Max();
        Console.WriteLine($"Min value in array : {minValue} ");
        Console.WriteLine($"Max value in array : {maxValue}");
        MedianArray();
        MaxSequences();
        AverageArray();
        MinSequences();
        Console.ReadLine();
        void MedianArray()
        {
            int lengthArray = numbersArray.Length;
            /*Дізнаємося чи довжина массива парне чи не парне число*/
            int parity = lengthArray % 2;
            /*Якщо ні то знаходимо медіану розділивши нашу довжину масиву на 2 отриманне число буде індексом нашого числа*/ 
            if (parity != 0)
            {
                int index = numbersArray.Length / 2;
                Console.WriteLine($"Median array: {numbersArray[index]}");
            }
            /*Якщо так то розділяемо на 2
              це і буде індекс нашого першого числа після чого додаемо до цього індексу 1
              і таким чином отримуемо індекс нашого другого числа додавши їх ми знайдемо медіанну*/
            else if (parity == 0)
            {
                int IndexFirstElement = numbersArray.Length / 2;
                int FirstElement = numbersArray[IndexFirstElement];
                int SecondElement = numbersArray[IndexFirstElement - 1];
                int MedianResult = FirstElement + SecondElement;
                Console.WriteLine($"Median array: {MedianResult}");
            }
        }
        /*Для знаходження середнього арефметичного нашої послідовності у циклі
         * ми беремо елемент массиву розділяемо його на кількість елементів й додаемо до змінної з результатом ціеї операції */
        void AverageArray()
        {
            int arrayLength = numbersArray.Length;
            double result = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                result = result + (numbersArray[i] / arrayLength);
            }
            Console.WriteLine($"Average : {result}");
        }
        /*Знаходимо найбільшу послідовність*/
        void MaxSequences()
        {
            /*Поточна послідовність*/
            List<int> currentSequence = new List<int>();
            /*Найбільша зростаюча послідовність*/
            List<int> maxSequence = new List<int>();
            for (int i = 0; i < numbersArray.Length - 1; i++)
            {
                /*Очищуемо наш поточний список*/
                currentSequence.Clear();
                /*Додаємо до нього перше число*/
                currentSequence.Add(numbersArray[i]);

                for (int j = i + 1; j < numbersArray.Length; j++)
                {
                    /*Перевіряемо чи дійсно поточне число більше ніж те що знаходиться у currentSequences*/
                    if (numbersArray[j] > currentSequence[currentSequence.Count - 1])
                    {
                        /*Якщо так то додаемо у currentSequences*/
                        currentSequence.Add(numbersArray[j]);
                    }
                    else
                    {
                        /*Якщо ні зупиняємо цикл*/
                        break;
                    }
                }

                if (currentSequence.Count > maxSequence.Count)
                {
                    /*Якщо кількість елементів у поточному списку(currentSequences) більше ніж y maxSequences(Найбільшій зростаючій послідовності)
          * то додаемо нашу послідовнысть currentSequence в maxSequence*/
                    maxSequence.Clear();
                    maxSequence.AddRange(currentSequence);
                }
            }
            /*Виводимо нашу послідовність*/
            Console.WriteLine("Max sequences:");
            foreach (int num in maxSequence)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        void MinSequences()
        {
            /*Поточна послідовність*/
            List<int> currentSequence = new List<int>();
            /*Найбільша спадаюча послідовність*/
            List<int> minSequence = new List<int>();
            for (int i = 0; i < numbersArray.Length - 1; i++)
            {
                /*Очищуемо наш поточний список*/
                currentSequence.Clear();
                /*Додаємо до нього перше число*/
                currentSequence.Add(numbersArray[i]);
                for (int j = i + 1; j < numbersArray.Length; j++)
                {
                    /*Перевіряемо чи дійсно поточне число менше ніж те що знаходиться у currentSequences*/
                    if (numbersArray[j] < currentSequence[currentSequence.Count - 1])
                    {
                        /*Якщо так то додаемо у currentSequences*/
                        currentSequence.Add(numbersArray[j]);
                    }
                    else
                    {
                        /*Якщо ні зупиняємо цикл*/
                        break;
                    }
                }
                /*Якщо кількість елементів у поточному списку(currentSequences) більше ніж y minSequences(Найбільшій спадаючій послідовності)
                 * то додаемо нашу послідовнысть currentSequence в minSequence*/
                if (currentSequence.Count > minSequence.Count)
                {
                    minSequence.Clear();
                    minSequence.AddRange(currentSequence);
                }
            }
            /*Виводимо нашу послідовність*/
            Console.WriteLine("Min sequences:");
            foreach (int num in minSequence)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
