import sys

from use_cases.calculate_total import calculate_total

if __name__ == '__main__':
    amount = 0
    tax = 0

    try:
        amount = float(sys.argv[1])
        tax = float(sys.argv[2])
    except (IndexError, ValueError):
        exit(1)

    total = calculate_total(amount, tax)

    print(total)
