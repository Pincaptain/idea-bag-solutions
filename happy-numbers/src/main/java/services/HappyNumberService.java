package services;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class HappyNumberService {
    public List<Integer> getHappyNumbers(int offset, final int limit) {
        ArrayList<Integer> happyNumbers = new ArrayList<>();

        if (offset <= 0) {
            return happyNumbers;
        }

        while (happyNumbers.size() != limit) {
            if (isHappyNumber(offset)) {
                happyNumbers.add(offset);
            }

            offset++;
        }

        return happyNumbers;
    }

    public boolean isHappyNumber(int number) {
        int temporary = number;
        HashSet<Integer> seenNumbers = new HashSet<>();

        while (true) {
            temporary = getSquaredDigitSum(temporary);

            if (temporary == 1) {
                return true;
            } else if (seenNumbers.contains(temporary)) {
                return false;
            }

            seenNumbers.add(temporary);
        }
    }

    private int getSquaredDigitSum(int number) {
        char[] charArray = String.valueOf(number).toCharArray();
        int[] digitArray = new int[charArray.length];
        int squaredDigitSum = 0;

        for (int i = 0; i < charArray.length; i++) {
            digitArray[i] = Character.getNumericValue(charArray[i]);
            digitArray[i] *= digitArray[i];
            squaredDigitSum += digitArray[i];
        }

        return squaredDigitSum;
    }
}
