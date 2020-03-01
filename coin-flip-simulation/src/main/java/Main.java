import services.CoinFlipSimulationService;
import services.ICoinFlipSimulationService;

public class Main {
    public static ICoinFlipSimulationService coinFlipSimulationService = new CoinFlipSimulationService();

    public static void main(String[] args) {
        if (args.length < 1) {
            return;
        }

        int iterations = 0;

        try {
            iterations = Integer.parseInt(args[0]);
        } catch (NumberFormatException exc) {
            return;
        }

        System.out.println(coinFlipSimulationService.getCoinFlipSimulation(iterations));
    }
}
