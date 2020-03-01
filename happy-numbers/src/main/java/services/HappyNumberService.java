package services;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class HappyNumberService implements IHappyNumberService {
    @Override
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

    private boolean isHappyNumber(int number) {
        HashSet<Integer> seenNumbers = new HashSet<>();

        while (true) {
            number = getSquaredDigitSum(number);

            if (number == 1) {
                return true;
            } else if (seenNumbers.contains(number)) {
                return false;
            }

            seenNumbers.add(number);
        }
    }

    private int getSquaredDigitSum(int number) {
        return String.valueOf(number)
                .chars()
                .mapToObj(character -> (char) character)
                .map(Character::getNumericValue)
                .map(digit -> (int) Math.pow(digit, 2))
                .reduce(Integer::sum)
                .orElse(-1);
    }
}
