using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Matrix matrix1 = new Matrix(random);
            matrix1.completionArray(random);
            Console.WriteLine("Matrix1");
            matrix1.Print();
            Console.WriteLine();
            Matrix matrix2 = new Matrix(random);
            matrix2.completionArray(random);
            Console.WriteLine("Matrix2");
            matrix2.Print();
            Matrix matrix3 = new Matrix();
            matrix3 = matrix1 + matrix2;
            Console.WriteLine();
            Console.WriteLine("Результат сложения matrix1 и matrix2");
            matrix3.Print();
            Matrix matrix4 = new Matrix();
            matrix4 = matrix1 - matrix2;
            Console.WriteLine();
            Console.WriteLine("Результат вычитания matrix1 и matrix2");
            matrix4.Print();
            Matrix matrix5 = new Matrix();
            matrix5 = matrix1 * matrix2;
            Console.WriteLine();
            Console.WriteLine("Результат умножения matrix1 и matrix2");
            matrix5.Print();
            Matrix matrix6 = new Matrix();
            matrix6 = matrix1 / matrix2;
            Console.WriteLine();
            Console.WriteLine("Результат деления matrix1 и matrix2");
            matrix6.Print();
        }

        /*Реализовать класс Matrix для работы с матрицами
        Реализовать операции:
        	сложения, вычитания, умножения, деления двух матриц (чекайте теорию в интернете)
        	умножение матрицы на число-множитель
        	изменение знака матрицы (*-1)
        	инкремент/декремент
        	получение определителя (перегрузить любой унарный оператор на выбор)
        	Equals, GetHashCode, CompareTo
        	получение/установка элемента матрицы по индексам строки/столбца
        */


        internal class Matrix
        {
            private int[,] array1 = new int[5, 5];

            // Конструктор без параметров
            public Matrix(){ } // По умолчанию матрица будет заполнена нулями     

            // Конструктор, принимающий генератор случайных чисел
            public Matrix(Random random)
            {
                completionArray(random);
            }

            // Метод для заполнения массива случайными числами
            public void completionArray(Random random)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        array1[i, j] = random.Next(1, 10);
                    }
                }
            }

            // Метод для получения значения элемента матрицы по индексам
            public int GetValue(int row, int column)
            {
                return array1[row, column];
            }

            // Метод для установки значения элемента матрицы по индексам
            public void SetValue(int row, int column, int value)
            {
                array1[row, column] = value;
            }

            // Метод для печати матрицы
            public void Print()
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(array1[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            // Перегрузка оператора сложения
            public static Matrix operator +(Matrix matrix1, Matrix matrix2)
            {
                Matrix result = new Matrix();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int value1 = matrix1.GetValue(i, j);
                        int value2 = matrix2.GetValue(i, j);
                        result.SetValue(i, j, value1 + value2); // Сложение элементов
                    }
                }
                return result; // Возвращаем новую матрицу с результатом
            }

            public static Matrix operator -(Matrix matrix1, Matrix matrix2)
            {
                Matrix result = new Matrix();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int value1 = matrix1.GetValue(i, j);
                        int value2 = matrix2.GetValue(i, j);
                        result.SetValue(i, j, value1 - value2); // Сложение элементов
                    }
                }
                return result;
            }

            public static Matrix operator *(Matrix matrix1, Matrix matrix2)
            {
                Matrix result = new Matrix();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < 5; k++)
                        {
                            sum += matrix1.GetValue(i, k) * matrix2.GetValue(k, j);
                        }
                        result.SetValue(i, j, sum);
                    }
                }
                return result;
            }

            public static Matrix operator /(Matrix matrix1, Matrix matrix2)
            {
                Matrix result = new Matrix();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < 5; k++)
                        {
                            // Проверка на ноль в знаменателе
                            if (matrix2.GetValue(k, j) == 0)
                            {
                                throw new InvalidOperationException("Division by zero is not allowed.");
                            }
                            sum += matrix1.GetValue(i, k) / matrix2.GetValue(k, j);
                        }
                        result.SetValue(i, j, sum);
                    }
                }
                return result;
            }

        }


    }
}
