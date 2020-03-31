import math


class FactorizationService(object):
    def prime_factorization(self, number: int) -> list:
        if number < 2:
            return []

        factors = []

        while number % 2 == 0:
            factors.append(2)
            number /= 2

        for i in range(3, int(math.sqrt(number)) + 1, 2):
            while number % i == 0:
                factors.append(i)
                number /= i

        if number > 2:
            factors.append(int(number))

        return factors
