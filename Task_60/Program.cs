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


        private static void Main( string[] args ) {
            // Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
            Console.Write( "\nЗадача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. ");
            // Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
            Console.WriteLine( "Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента. ");

            Console.WriteLine( "\nДля генерации прямогольного терхмерного массива, пожалуйста введите целое число от 2 до 4." );
            int array_size = ConsoleInputInt32( 2, 4, "Введите размер прямоугольного трехмерного массива = " );
            int[,,] some_3d_array = new int[array_size, array_size, array_size];

            List<int> some_list = new List<int>();
            int some_number;
            Random random = new Random();

            Console.WriteLine( $"\nТрехмерный массив из неповторяющихся двузначных чисел, размером {array_size} х {array_size} х {array_size}:\n" );
            for ( int i = 0; i < array_size; i++ ) {
                
                for( int j = 0; j < array_size; j++ ) {

                    for ( int k = 0; k < array_size; k += 0 ) {

                        some_number = random.Next( 10, 100 );
                        if ( !some_list.Contains( some_number ) ) {
                            some_list.Add( some_number );

                            // Не вижу смысла это выделять в отдельный метод, если не планируем переиспользовать...
                            some_3d_array[i, j, k] = some_number;
                            Console.Write( $"{some_3d_array[i, j, k]}({i},{j},{k})   " );
                            k++;
                        }

                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            
            some_list.Clear();
        }
    }
}