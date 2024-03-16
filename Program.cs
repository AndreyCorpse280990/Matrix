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

            // Создание и заполнение матрицы 1
            Matrix matrix1 = new Matrix(random);
            matrix1.CompletionArray(random);
            Console.WriteLine("Matrix1");
            matrix1.Print();
            Console.WriteLine();

            // Создание и заполнение матрицы 2
            Matrix matrix2 = new Matrix(random);
            matrix2.CompletionArray(random);
            Console.WriteLine("Matrix2");
            matrix2.Print();
            Console.WriteLine();

            // Сложение matrix1 и matrix2
            Matrix matrix3 = matrix1 + matrix2;
            Console.WriteLine("Результат сложения matrix1 и matrix2");
            matrix3.Print();
            Console.WriteLine();

            // вычитание matrix1 и matrix2
            Matrix matrix4 = matrix1 - matrix2;
            Console.WriteLine("Результат вычитания matrix1 и matrix2");
            matrix4.Print();
            Console.WriteLine();

            // умножение matrix1 и matrix2
            Matrix matrix5 = matrix1 * matrix2;
            Console.WriteLine("Результат умножения matrix1 и matrix2");
            matrix5.Print();
            Console.WriteLine();

            // деление matrix1 и matrix2
            Matrix matrix6 = matrix1 / matrix2;
            Console.WriteLine("Результат деления matrix1 на matrix2");
            matrix6.Print();
            Console.WriteLine();

            // умножение  matrix1 на 3
            Matrix matrix9 = Matrix.multiplication(matrix1, 3);
            Console.WriteLine("Результат умножения matrix1 на число 3 ");
            matrix9.Print();
            Console.WriteLine();

            //  изменение знака матрицы
            Matrix matrix8 = -matrix1;
            Console.WriteLine("Результат изменения знака матрицы matrix1");
            matrix8.Print();
            Console.WriteLine();


            //  Equals
            Console.WriteLine("Результат сравнения matrix1 и matrix2:");
            Console.WriteLine(matrix1.Equals(matrix2));
            Console.WriteLine();

            //  GetHashCode
            Console.WriteLine("Хэш-код матрицы matrix1:");
            Console.WriteLine(matrix1.GetHashCode());
            Console.WriteLine();

            // CompareTo
            Console.WriteLine("Сравнение матриц matrix1 и matrix2 при помощи CompareTo:");
            Console.WriteLine(matrix1.CompareTo(matrix2));
            Console.WriteLine();
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
                CompletionArray(random);
            }

            // Метод для заполнения массива случайными числами
            public void CompletionArray(Random random)
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
                return result; 
            }

            // Перегрузка оператора вычитания
            public static Matrix operator -(Matrix matrix1, Matrix matrix2)
            {
                Matrix result = new Matrix();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int value1 = matrix1.GetValue(i, j);
                        int value2 = matrix2.GetValue(i, j);
                        result.SetValue(i, j, value1 - value2); // вычитание элементов
                    }
                }
                return result;
            }

            // Перегрузка оператора деления
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

            // Перегрузка оператора умножения матрицы на матрицу
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

            
            // перегрузка оператора умножения на число-множитель
            public static Matrix multiplication(Matrix matrix, int number)
            {
                Matrix result = new Matrix();
                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0;j < 5; j++)
                    {
                        result.SetValue(i, j, matrix.GetValue(i, j) * number);
                    }                    
                }
                return result;
            }

            
            //перегрузка оператора изменения знака матрицы
            public static Matrix operator -(Matrix matrix)
            {
                Matrix result = new Matrix();
                for(int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        result.SetValue(i, j, -matrix.GetValue(i, j));
                    }
                }
                return result;
            }

            // Метод для сравнения матриц по содержимому
            public bool Equals(Matrix other)
            {
                if (other == null)
                    return false;

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (array1[i, j] != other.GetValue(i, j))
                            return false;
                    }
                }
                return true;
            }

            // Метод для получения хэш-кода матрицы
            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            hash = hash * 23 + array1[i, j].GetHashCode();
                        }
                    }
                    return hash;
                }
            }

            // Метод для сравнения матриц
            public int CompareTo(Matrix other)
            {
                if (other == null)
                    return 1;

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int compare = array1[i, j].CompareTo(other.GetValue(i, j));
                        if (compare != 0)
                            return compare;
                    }
                }
                return 0;
            }
        }
    }
}
