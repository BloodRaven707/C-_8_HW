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
            // Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
            Console.WriteLine( "\nЗадача 62. Напишите программу, которая заполнит спирально массив 4 на 4." );

            Console.WriteLine( "\nДля генерации массива, пожалуйста введите целые число от 2." );
            int array_rows = ConsoleInputInt32( min_value: 2, message: "Введите количество строк массива = " );
            int array_cols = ConsoleInputInt32( min_value: 2, message: "Введите количество столбцов массива = " );
            int[,] some_array = new int[array_rows, array_cols];

            int count = 0;


            for ( int i = 0; i < ( Math.Min( array_rows, array_cols ) / 2 + 1 ); i++ ) {

                // Линия >>>
                if ( some_array[i, i] == 0 )
                    for ( int j = i; j < ( array_cols - i ); j++ ) {
                        count++;
                        some_array[i, j] = count;
                    }

                // Линия \/\/\/
                if ( array_rows > (i + 1) && some_array[( array_rows - 1 - i ), i] == 0 ) {
                    for ( int k = i + 1; k < ( array_rows - i ); k++ ) {
                        count++;
                        some_array[k, ( array_cols - i - 1 )] = count;
                    }

                    // Линия <<<
                    if ( array_cols > i + 1 && some_array[( array_rows - 1 - i ), ( array_cols - 2 - i )] == 0 ) {
                        for ( int j = ( array_cols - 2 - i ); j >= i; j-- ) {
                            count++;
                            some_array[( array_rows - 1 - i ), j] = count;
                        }

                        // Линия /\/\/\
                        if ( array_rows > i + 2 )
                            for ( int k = ( array_rows - 2 - i ); k > i; k-- ) {
                                count++;
                                some_array[k, i] = count;
                            }
                    }
                }

            }

            Console.WriteLine( $"\nЗаполнение массива, размером {array_cols} х {array_rows}, по спирали:\n" );

            // Выводим в консоль наш массив
            ConsoleWrite2dArray( some_array );
            Console.WriteLine();
        }
    }
}