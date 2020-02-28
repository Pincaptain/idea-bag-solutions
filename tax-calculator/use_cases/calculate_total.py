def calculate_total(amount: float, tax: float):
    if amount <= 0:
        return 0

    if tax > 100:
        tax = 100.0

    return (amount * (tax / 100)) + amount
