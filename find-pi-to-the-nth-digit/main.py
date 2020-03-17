import sys

from service.pi_service import PiService

if __name__ == '__main__':
    if len(sys.argv) < 2:
        exit(1)

    try:
        n = int(sys.argv[1])
        pi_service = PiService()

        print(pi_service.get_pi_to_n(n))
    except ValueError:
        exit(1)