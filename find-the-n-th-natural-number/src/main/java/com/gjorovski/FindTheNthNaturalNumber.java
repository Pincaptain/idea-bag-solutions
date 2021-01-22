package com.gjorovski;

import java.util.concurrent.Callable;

public class FindTheNthNaturalNumber implements Callable<Integer> {
    static final int DESIRED_POSITION = 1986;

    private int digitsCount(int number) {
        return (int) Math.log10(number) + 1;
    }

    @Override
    public Integer call() {
        int digitsCount = 0;

        for (int i = 1; i <= 1000; i++) {
            if (digitsCount + digitsCount(i) >= DESIRED_POSITION) {
                String[] digitArray = String.valueOf(i).split("");
                int digit = Integer.parseInt(digitArray[(digitsCount + digitsCount(i)) - DESIRED_POSITION]);

                System.out.printf("The digit on the %s position in the range 1-1000 is %s%n", DESIRED_POSITION, digit);
                System.out.printf("This digit is part of the number %s%n", i);

                return 0;
            }

            digitsCount += digitsCount(i);
        }

        return 1;
    }

    public static void main(String[] args) {
        System.exit(new FindTheNthNaturalNumber().call());
    }
}
