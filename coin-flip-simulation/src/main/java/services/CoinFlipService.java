package services;

import models.RandomNumber;
import repositories.IRandomNumberRepository;
import repositories.RandomNumberRepository;

public class CoinFlipService implements ICoinFlipService {
    IRandomNumberRepository randomNumberRepository = new RandomNumberRepository();

    @Override
    public boolean isHeads() {
        RandomNumber randomNumber = randomNumberRepository.getRandomNumber();

        return randomNumber.getRandomNumber() == 1;
    }
}
