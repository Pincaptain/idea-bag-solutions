import sys

from use_cases.get_city_coordinates import get_city_coordinates
from use_cases.calculate_distance import calculate_distance

if __name__ == '__main__':
    x = None
    y = None
    unit = 'km'

    try:
        x = sys.argv[1]
        y = sys.argv[2]
        unit = sys.argv[3]
    except IndexError:
        exit(1)

    x_coordinates = get_city_coordinates(x)
    y_coordinates = get_city_coordinates(y)

    print(calculate_distance(x_coordinates, y_coordinates, unit))
