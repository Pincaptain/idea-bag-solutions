import services.HappyNumberService;
import services.IHappyNumberService;

import java.util.List;

public class Main {
    public static IHappyNumberService happyNumberService = new HappyNumberService();

    public static void main(String[] args) {
        if (args.length != 1) {
            return;
        }

        int offset;
        int limit = 8;

        try {
            offset = Integer.parseInt(args[0]);
        } catch (NumberFormatException exc) {
            return;
        }

        List<Integer> happyNumbers = happyNumberService.getHappyNumbers(offset, limit);

        for (int happyNumber : happyNumbers) {
            System.out.println(happyNumber);
        }
    }
}
