def factorial_loop(number):
    if number < 0:
        return -1

    if number == 0:
        return 1

    factorial = 1
    while number > 0:
        factorial *= number
        number -= 1

    return factorial


def factorial_recursion(number):
    if number == 1:
        return 1

    return number * factorial_recursion(number - 1)
