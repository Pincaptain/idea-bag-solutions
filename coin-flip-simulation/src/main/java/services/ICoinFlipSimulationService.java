package services;

import models.CoinFlipSimulation;

public interface ICoinFlipSimulationService {
    CoinFlipSimulation getCoinFlipSimulation(int iterations);
}
