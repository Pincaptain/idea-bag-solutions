import sys

from provider.fibonacci_provider import FibonacciContainer

if __name__ == '__main__':
    if len(sys.argv) != 2:
        exit(1)

    limit = 0
    try:
        limit = int(sys.argv[1])
    except ValueError:
        exit(1)

    fibonacci = FibonacciContainer.fibonacci_provider()

    print(fibonacci.calculate(limit))
