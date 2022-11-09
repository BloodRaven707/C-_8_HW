namespace Console_Program
{
    class Project
    {
        /// <summary>Выводит сообщение в консоль, проверяет и преобразует пользовательский ввод.</summary>
        /// <param name="min_value">Нижняя граница диапозона чисел</param>
        /// <param name="max_value">Верхняя граница диапозона чисел</param>
        /// <param name="message">Выводимое в консоль сообщение</param>
        /// <returns>Число типа Int32</returns>
        public static int ConsoleInputInt32( int min_value=-1000000, int max_value=1000000, string message="Введите целое число: " ) {
            int result = 0; 

            while ( true ) {
                Console.Write( message );

                if ( int.TryParse( Console.ReadLine() ?? "", out result ) )
                    if ( result >= min_value && result <= max_value )
                        break;

                Console.WriteLine( "[!] Вы ввели не верные данные!\n" );
            }
            return result; 
        }


        /// <summary>Генерирует двумерный массив указанного размера и заполняет его
        /// случайными числами, типа Int32, в указанном диапазоне.</summary>
        /// <param name="array_rows">Число строк массива</param>
        /// <param name="array_cols">Число столбцов массива</param>
        /// <param name="min_range">Нижняя граница диапозона чисел</param>
        /// <param name="max_range">Верхняя граница диапозона чисел</param>
        /// <returns>Двумерный массив случайных число типа Int32</returns>
        public static int[,] RandomInt2dArry( int array_rows=3, int array_cols=3, int min_range=100, int max_range=100 ) {
            Random rand = new Random();
            int[,] new_array = new int[array_rows, array_cols];

            for ( int i = 0; i < array_rows; i++ )
                for ( int j = 0; j < array_cols; j++ )
                    new_array[i, j] = rand.Next( min_range, max_range );

            return new_array;
        }


        /// <summary>Принимает и выводит в консоль двумерный массив.</summary>
        /// <param name="some_array">Объект типа Int32[,]</param>
        public static void ConsoleWrite2dArray( int[,] some_array ) {
            for ( int i = 0; i < some_array.GetLength(0) ; i++ ) {
                
                for ( int j = 0; j < some_array.GetLength(1); j++ )
                    Console.Write( $"{some_array[i, j], 6:g}" );

                Console.WriteLine();
            }
        }


        private static void Main( string[] args ) {
            // Задача 58. Задайте две матрицы.
            Console.Write( "\nЗадача 58: Задайте две матрицы. " );
            // Напишите программу, которая будет находить произведение двух матриц.
            Console.WriteLine( "Напишите программу, которая будет находить произведение двух матриц." );

            Console.WriteLine( "\nДля генерации прямогольного массива, пожалуйста введите целое число от 2 до 9." );
            int array_size = ConsoleInputInt32( 2, 9, "Введите размер прямоугольного массива = " );

            Console.WriteLine( "\nСлучайно сформированные прямоугольные матрицы:");
            int[,] first_array = RandomInt2dArry( array_size, array_size, 1, 10 );
            int[,] second_array = RandomInt2dArry( array_size, array_size, 1, 10 );

            for ( int i = 0; i < first_array.GetLength(0) ; i++ ) {
                for ( int j = 0; j < first_array.GetLength(1); j++ )
                    Console.Write( $"{first_array[i, j], 4:g}" );

                Console.Write( "   |" );

                for ( int j = 0; j < first_array.GetLength(1); j++ )
                    Console.Write( $"{second_array[i, j], 4:g}" );

                Console.WriteLine();
            }

            // Считаем произведение 2-х матриц
            Console.WriteLine( "\nПроизведение двух матриц:" );

            int[,] new_array = new int[array_size, array_size];
            for ( int i = 0; i < array_size; i++ )
                for ( int j = 0; j < array_size; j++ )
                {
                    new_array[i, j] = 0;
                    for (int k = 0; k < array_size; k++)
                        new_array[i, j] += first_array[i, k] * second_array[k, j];
                }

            // Выводим на экран матрицу - произведение 2-х матриц
            ConsoleWrite2dArray ( new_array );
            Console.WriteLine();
        }
    }
}