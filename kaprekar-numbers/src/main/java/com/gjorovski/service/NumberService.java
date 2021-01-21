package com.gjorovski.service;

public class NumberService {
    public int digitsCount(int number) {
        return (int) (Math.log10(number) + 1);
    }
}
