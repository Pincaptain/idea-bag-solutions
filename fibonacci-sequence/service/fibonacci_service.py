class FibonacciService(object):
    def calculate(self, limit: int):
        if limit <= 0:
            return []

        if limit == 1:
            return [1]

        if limit == 2:
            return [1, 1]

        sequence = [1, 1]

        for i in range(limit - 2):
            sequence.append(sequence[i] + sequence[i+1])

        return sequence
