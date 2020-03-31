import sys

from provider.factorization_provider import FactorizationProvider

if __name__ == '__main__':
    if len(sys.argv) != 2:
        exit(1)

    number = 0
    try:
        number = int(sys.argv[1])
    except ValueError:
        exit(1)

    factorization_service = FactorizationProvider.factorization_service()

    print(factorization_service.prime_factorization(number))
