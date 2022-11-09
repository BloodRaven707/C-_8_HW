namespace Console_Program
{
    class Project
    {
        /// <summary>Выводит сообщение в консоль, проверяет и преобразует пользовательский ввод.</summary>
        /// <param name="message">Выводимое в консоль сообщение</param>
        /// <returns>Число типа Int32</returns>
        public static int ConsoleInputInt32( string message="Введите целое число: " ) {
            int result = 0; 

            while ( true ) {
                Console.Write( message );

                if ( int.TryParse( Console.ReadLine() ?? "", out result ) )
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
            // Задача 56. Задайте прямоугольный двумерный массив.
            Console.Write( "\nЗадача 56: Задайте прямоугольный двумерный массив. " );
            // Напишите программу, которая будет находить строку с наименьшей суммой элементов.
            Console.WriteLine( "Напишите программу, которая будет находить строку с наименьшей суммой элементов." );

            Console.WriteLine( "\nДля генерации прямогольного массива, пожалуйста введите целое число." );
            int array_size = ConsoleInputInt32( "Введите размер прямоугольного массива = " );

            int min_range = -99;
            int max_range = 100;

            Console.WriteLine( "\nСлучайно сформированный прямоугольный массив:");
            int[,] some_array = RandomInt2dArry( array_size, array_size, min_range, max_range );

            // Выводим в консоль массив
            ConsoleWrite2dArray( some_array );

            // Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
            int min_sum = max_range * array_size;
            int row_sum;
            int min_row = 0;

            for ( int i = 0; i < array_size; i++ ) {
                row_sum = 0;

                for ( int j = 0; j < array_size; j++ )
                    row_sum += some_array[i, j];

                if ( min_sum > row_sum ) {
                    min_sum = row_sum;
                    min_row = i + 1;
                }
            }
 
            Console.WriteLine( $"\nНомер строки(не индекс), с наименьшей суммой элементов: { min_row }\n" );
        }
    }
}
