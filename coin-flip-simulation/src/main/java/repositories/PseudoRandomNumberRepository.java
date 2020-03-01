package repositories;

import models.RandomNumber;

import java.util.Random;

public class PseudoRandomNumberRepository implements IRandomNumberRepository {
    @Override
    public RandomNumber getRandomNumber() {
        return new RandomNumber(new Random().nextInt(2));
    }
}
