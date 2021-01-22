from typing import List
import math


class NeonNumbers(object):
    @staticmethod
    def __get_digits_list(num: int) -> List[int]:
        arr = str(num)
        digits_list = []

        for char in arr:
            digits_list.append(int(char))

        return digits_list

    @staticmethod
    def __is_neon(num: int) -> bool:
        square = int(math.pow(num, 2))
        square_sum = 0
        square_digits = NeonNumbers.__get_digits_list(square)

        for digit in square_digits:
            square_sum += digit

        return square_sum == num

    @staticmethod
    def find_range(start: int, end: int) -> List[int]:
        neon_numbers = []

        for i in range(start, end):
            if NeonNumbers.__is_neon(i):
                neon_numbers.append(i)

        return neon_numbers
