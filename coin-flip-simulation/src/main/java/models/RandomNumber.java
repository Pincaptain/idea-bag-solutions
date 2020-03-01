package models;

public class RandomNumber {
    private int randomNumber;

    public RandomNumber(int randomNumber) {
        this.randomNumber = randomNumber;
    }

    public int getRandomNumber() {
        return randomNumber;
    }

    public static RandomNumber fromString(String randomNumber) {
        return new RandomNumber(Integer.parseInt(randomNumber));
    }
}
