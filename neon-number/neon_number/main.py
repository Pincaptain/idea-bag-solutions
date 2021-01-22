import click

from neon_number.use_cases.neon_numbers import NeonNumbers


@click.command()
@click.option('--start', default=0, help='The beginning of the range.')
@click.option('--end', default=10, help='The end of the range.')
def main(start: int, end: int):
    neon_numbers = NeonNumbers.find_range(start, end)

    for neon_number in neon_numbers:
        print(neon_number)


if __name__ == '__main__':
    main()
