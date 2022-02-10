using System;

namespace MatrixExample
{
    public class Program
    {
        /*
         * 1. Дан Двумерный массив. Вставить в него:
            а) строку из чисел 100 после строки с номером s;
            б) столбец из нулей перед столбцом с номером k;
            в) строку из нулей после первой из строк, количество нулей в которой равно заданному числу n;
            г) столбец из чисел 10 после первого из столбцов, у которых сумма элементов не превышает заданное число n;
            д) две строки из нулей: одну перед s-й строкой, вторую — перед р-й строкой;
            е) два столбца из чисел 1: один после k-го столбца, второй — перед q-м столбцом.
         */
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 1;
                }
            }
        }

        // Основные задания.
        public static void A(int[,] matrix, int s) // Задание а)
        {
            FillRow(matrix, s + 1, 100);
        }

        public static void B(int[,] matrix, int k) // Задание б)
        {
            FillRow(matrix, k - 1, 0);
        }

        public static void C(int[,] matrix, int count, int value) // Задание в)
        {
            int index = IndexOfRowWithCountOfValues(matrix, count, value);

            if (index != -1) // Проверяем что существует ряд удовлетворяющий условию.
            {
                FillRow(matrix, index + 1, 0); // Переиспользуем cозданый раннее метод;
            }
        }

        public static void D(int[,] matrix, int n) // Задание г)
        {
            int index = IndexOfColumnWithSumOfElementsLessOrEqualsThan(matrix, n);

            if (index != -1)
            {
                FillColumn(matrix, index + 1, 10);
            }
        }
        public static void E(int[,] matrix, int s, int p) // Задание д)
        {
            FillRow(matrix, s - 1, 0);
            FillRow(matrix, p + 1, 0);
        }

        public static void F(int[,] matrix, int k, int q) // Задание е)
        {
            FillColumn(matrix, k + 1, 1);
            FillRow(matrix, q - 1, 1);
        }
        // Конец Основных заданий.

        // Вспомогательные методы.
        public static bool ValidateMatrix(int[,] matrix) // Метод для проверки матрицы на корректность (валидация). 
        {
            if (matrix is null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0 || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static void FillRow(int[,] matrix, int rowNumber, int value)
        {
            // Проверка входящих аргументов на корректность.
            if (!ValidateMatrix(matrix) || rowNumber < 0 || rowNumber > matrix.GetLength(0) - 1)
            {
                throw new ArgumentOutOfRangeException("Incorrect arguments.");
            }
            // Конец проверки.

            for (int i = 0; i < matrix.GetLength(1); i++) // Проходим по колонкам
            {
                matrix[rowNumber, i] = value; // Заполняем строку.
            }
        }
        public static void FillColumn(int[,] matrix, int columnNumber, int value)
        {
            // Проверка входящих аргументов на корректность.

            if (!ValidateMatrix(matrix) || columnNumber < 0 || columnNumber > matrix.GetLength(1) - 1)
            {
                throw new ArgumentException("Incorrect arguments.");
            }
            // Конец проверки.

            for (int i = 0; i < matrix.GetLength(1); i++) // Проходим по рядам.
            {
                matrix[i, columnNumber] = value; // Заполняем строку.
            }
        }

        public static int IndexOfRowWithCountOfValues(int[,] matrix, int count, int value)
        {
            if (!ValidateMatrix(matrix) || count < 0 || count > matrix.GetLength(0) - 1)
            {
                throw new ArgumentException("Incorrect arguments.");
            }          

            for (int i = 0; i < matrix.GetLength(0); i++) // Проходим по рядам.
            {
                int currentCount = 0; // Объявляем счетчик. Обнуляется на каждой итерации.

                for (int j = 0; j < matrix.GetLength(1); j++) // // Проходим по всем элементам ряда.
                {
                    if (matrix[i, j] == value)
                    {
                        currentCount++; // Считаем кол-во требуемых элементов.
                    }
                }

                if (currentCount == count)
                {
                    return i; // Если собрали нужное кол-во элементов, возвращаем индекс ряда.
                }
            }

            return -1; // Если условие не выполнилось ни в одном из рядов возвращаем -1(Явно некорректный индекс, перед использованием надо делать проверку).
        }

        public static int IndexOfColumnWithSumOfElementsLessOrEqualsThan(int[,] matrix, int sumLimit)
        {
            if (!ValidateMatrix(matrix))
            {
                throw new ArgumentException("Incorrect arguments.");
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int currentSum = 0;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    currentSum += matrix[j, i];
                }

                if (currentSum <= sumLimit)
                {
                    return i;
                }
            }

            return -1; // Если условие не выполнилось ни в одном из столбцов возвращаем -1(Явно некорректный индекс, перед использованием надо делать проверку).
        }
    }
}
