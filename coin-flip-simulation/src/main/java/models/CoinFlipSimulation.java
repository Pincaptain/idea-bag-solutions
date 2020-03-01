package models;

public class CoinFlipSimulation {
    private int heads;
    private int tails;

    public CoinFlipSimulation() {
        heads = 0;
        tails = 0;
    }

    public int getHeads() {
        return heads;
    }

    public int getTails() {
        return tails;
    }

    public int getTotal() {
        return heads + tails;
    }

    public void incrementHeads() {
        heads++;
    }

    public void incrementTails() {
        tails++;
    }

    @Override
    public String toString() {
        return "CoinFlipSimulation{" +
                "heads=" + heads +
                ", tails=" + tails +
                ", total=" + getTotal() +
                '}';
    }
}
