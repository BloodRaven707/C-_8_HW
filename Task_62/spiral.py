# Мой код 2021 год - пока решал на C# нашлась ошибка)))

print("Введите два целых числа через пробел: ", end="")
n, m = [int(i) for i in input().split()]
print()

matrix = [['_' for j in range(m)] for i in range(n)]
count = 0

for i in range(min(n, m) // 2 + 1):
    if matrix[i][i] == '_':
        for j in range(i, m - i):
            count += 1
            matrix[i][j] = str(count)

    if n > i + 1 and matrix[-1 -i][i] == '_':
        for k in range(i + 1, n - i):
            count += 1
            matrix[k][-i - 1] = str(count)

        # if m > i + 1: тут ошибка...
        if m > i + 1 and matrix[-i - 1][-i - 2] == '_':
            for j in range(-i - 2, -m - 1 + i, -1):
                count += 1
                matrix[-i - 1][j] = str(count)

            if n > i + 2:
                for k in range(-i - 2, -n + i, -1):
                    count += 1
                    matrix[k][i] = str(count)

[print(*[matrix[i][j].rjust(4) for j in range(m)]) for i in range(n)]
