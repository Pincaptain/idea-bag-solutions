import sys

from use_cases.factorial import factorial_loop, factorial_recursion

if __name__ == '__main__':
    number = 0

    try:
        number = int(sys.argv[1])
    except (IndexError, ValueError):
        exit(1)

    print(factorial_loop(number))

    try:
        print(factorial_recursion(number))
    except RecursionError:
        print('Maximum recursion depth exceeded.')
        exit(1)
