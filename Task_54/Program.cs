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


        private static void Main( string[] args ) {
            // Задача 54. Задайте двумерный массив.
            Console.Write( "\nЗадача 54: Задайте двумерный массив. " ); 
            // Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
            Console.WriteLine( "Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива." );

            Console.WriteLine("\nДля генерации массива, пожалуйста введите целые числа.");

            int array_rows = ConsoleInputInt32( "Введите количество строк массива = " );
            int array_cols = ConsoleInputInt32( "Введите количество столбцов массива = " );

            int min_range = -100;
            int max_range = 100;

            Console.WriteLine( "\nСлучайно сформированный двумерный массив:");
            int[,] some_array = RandomInt2dArry( array_rows, array_cols, min_range, max_range );

            // Печатаем сформированный массив
            for ( int i = 0; i < array_rows; i++ ) {
                for ( int j = 0; j < array_cols; j++ )
                    Console.Write( $"{some_array[i, j], 6:g}" );
                Console.WriteLine();
            }

            int count_1 = 0; 
            int count_2 = 0; 
            Console.WriteLine( "\nМассив с отсортированными по убыванию элементами в строке:" );

            // Сортируем массив и выводим результаты и статистику сортировки
            for ( int i = 0; i < array_rows; i++ ) {
                for ( int j = 0; j < array_cols; j++ ) {
                    for ( int k = array_cols - 1; k > j; k-- ) {
                        // Проверяем элементы начиная с конца строки
                        if ( some_array[i, j] < some_array[i, k] ) {
                            ( some_array[i, k], some_array[i, j] ) = ( some_array[i, j], some_array[i, k] );
                            count_2++; 
                        }

                        count_1++; 
                    }

                    Console.Write( $"{some_array[i, j], 6:g}" ); 
                }

                Console.WriteLine(); 
            }

            Console.WriteLine( $"\nЧисло шагов: { count_1 }" );                
            Console.WriteLine( $"Число замен: { count_2 }" );                
        }
    }
}
