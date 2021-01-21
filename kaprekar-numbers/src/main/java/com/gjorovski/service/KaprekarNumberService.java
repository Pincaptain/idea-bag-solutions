package com.gjorovski.service;

import java.util.ArrayList;
import java.util.List;

public class KaprekarNumberService {
    private final NumberService numberService;

    public KaprekarNumberService() {
        this.numberService = new NumberService();
    }

    public boolean isKaprekarNumber(int number) {
        if (number == 1) {
            return true;
        }

        int squaredNumber = (int) Math.pow(number, 2);
        int digitsCount = numberService.digitsCount(squaredNumber);

        for (int i = digitsCount - 1; i > 0; i--) {
            int firstPart = squaredNumber / (int) Math.pow(10, i);
            int secondPart = squaredNumber % (int) Math.pow(10, i);

            if (firstPart == 0 || secondPart == 0) {
                continue;
            }

            int sum = firstPart + secondPart;

            if (sum == number) {
                return true;
            }
        }

        return false;
    }

    public List<Integer> inRange(int start, int end) {
        ArrayList<Integer> kaprekarNumbers = new ArrayList<>();

        for (int i = start; i <= end; i++) {
            if (isKaprekarNumber(i)) {
                kaprekarNumbers.add(i);
            }
        }

        return kaprekarNumbers;
    }
}
