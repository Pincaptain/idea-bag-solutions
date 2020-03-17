import sys

from service.e_service import EService

if __name__ == '__main__':
    if len(sys.argv) < 2:
        exit(1)

    try:
        n = int(sys.argv[1])
        e_service = EService()

        print(e_service.get_e_to_n(n))
    except ValueError:
        exit(1)
