import math

R = 6371000


def calculate_distance(x_coordinates, y_coordinates, unit):
    x = math.radians(x_coordinates['lat'])
    y = math.radians(y_coordinates['lat'])
    m = math.radians((y_coordinates['lat'] - x_coordinates['lat']))
    n = math.radians((y_coordinates['lng'] - x_coordinates['lng']))
    a = math.sin(m / 2) * math.sin(m / 2) + math.cos(x) * math.cos(y) * math.sin(n / 2) * math.sin(n / 2)
    c = 2 * math.atan2(math.sqrt(a), math.sqrt(1-a))
    distance = R * c

    if unit == 'km':
        return distance * 0.001
    elif unit == 'm':
        return distance * 0.000621371192
    else:
        return distance * 0.000539957
