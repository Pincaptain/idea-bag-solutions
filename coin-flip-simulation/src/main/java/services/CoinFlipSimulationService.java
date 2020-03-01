package services;

import models.CoinFlipSimulation;

public class CoinFlipSimulationService implements ICoinFlipSimulationService {
    ICoinFlipService coinFlipService = new CoinFlipService();

    @Override
    public CoinFlipSimulation getCoinFlipSimulation(int iterations) {
        CoinFlipSimulation coinFlipSimulation = new CoinFlipSimulation();

        for (int i = 0; i < iterations; i++) {
            if (coinFlipService.isHeads()) {
                coinFlipSimulation.incrementHeads();
            } else {
                coinFlipSimulation.incrementTails();
            }
        }

        return coinFlipSimulation;
    }
}
