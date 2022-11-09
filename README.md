# Команды для терминала

## С# Создание и запуск приложения

- dotnet new console
- dotnet run

## GIT Создание и выгрузка на сервер GitHub локального репозитория

- git init
- git add .
- git commit -m "Initial commit"
- git remote add origin https://github.com/BloodRaven707/<название_репозитория>.git
- git branch -M main
- git push -u origin main

<br>

# Заметки

## Описание функции C# 

- ``/// <summary>Описание функции</summary>``
- ``/// <param name="имя_переменной">Описание аргумента</param>``
- ``/// <returns>Описание вывода</returns>``

<br>

## Шаблон C# для Program.cs

```
namespace Console_Program
{
    class Project
    {
        /// <summary>Описание функции</summary>
        /// <param name="имя_переменной">Описание аргумента</param>
        /// <returns>Описание вывода</returns>

        private static void Main( string[] args ) {
            // Описание программы
        }
    }
}
```

<br>


## Шаблон C# для .gitignore

```
### Языки программирования
# C#
[Bb][Ii][Nn]/
[Oo][Bb][Jj]/


### Среда разработки
# VS Code
.vscode/

# Microsoft Visual Studio
.vs/
```

<br>

<br>

<br>

# Проверки ввода

```
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


/// <returns>Число типа Double</returns>
public static double ConsoleInputDouble( string message="Введите вещественное число: " ) {
    double result = 0; 

    while ( true ) {
        Console.Write( message );

        if ( double.TryParse( Console.ReadLine() ?? "", out result ) )
            break;

        Console.WriteLine( "[!] Вы ввели не верные данные!\n" );
    }
    return result; 
}
```

<br>

# Генераторы

```
/// <summary>Генерирует и возвращиет случайное число</summary>
/// <param name="random">Объект класса Random</param>
/// <param name="min_range">Нижняя граница диапазона чисел</param>
/// <param name="max_range">Верхняя граница диапазона чисел</param>
/// <returns>Случайное число типа Int32</returns>
public static int RandomInt( Random rand, int min_range=100, int max_range=100 ) {
    return random.Next( min_range, max_range );
}

/// <returns>Случайное число типа Double</returns>
public static double RandomDouble( Random rand, int min_range=100, int max_range=100 ) {
    return ( rand.NextDouble() * (max_range - min_range) + min_range );
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
```

## Работа с 2D Array

```
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
```