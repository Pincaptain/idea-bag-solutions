package com.gjorovski.model;

import java.util.Objects;

public class Pair {
    private int first;
    private int second;

    public Pair(int first, int second) {
        this.first = first;
        this.second = second;
    }

    public int getFirst() {
        return first;
    }

    public void setFirst(int first) {
        this.first = first;
    }

    public int getSecond() {
        return second;
    }

    public void setSecond(int second) {
        this.second = second;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;

        if (first == pair.first) {
            return second == pair.second;
        } else if (first == pair.second) {
            return second == pair.first;
        }

        return false;
    }

    @Override
    public int hashCode() {
        return Objects.hash(first, second);
    }
}
