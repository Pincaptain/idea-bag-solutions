package com.gjorovski;

import com.gjorovski.service.HardyRamanujanService;
import picocli.CommandLine;

import java.util.concurrent.Callable;

@CommandLine.Command(name = "Hardy Ramanujan Number", mixinStandardHelpOptions = true,
        description = "Find the Hardy Ramanujan numbers in a given range.", version = "1.0.0")
public class HardyRamanujanNumber implements Callable<Integer> {
    @CommandLine.Parameters(index = "0", description = "The starting integer in the range.")
    private int from;

    @CommandLine.Parameters(index = "1", description = "The last integer in the range.")
    private int to;

    @Override
    public Integer call() {
        HardyRamanujanService hardyRamanujanService = new HardyRamanujanService();

        for (int i = from; i <= to; i++) {
            if (hardyRamanujanService.isHardyRamanujanNumber(i)) {
                System.out.printf("%s is a Hardy Ramanujan number%n", i);
            }
        }

        return 0;
    }

    public static void main(String[] args) {
        int exitCode = new CommandLine(new HardyRamanujanNumber()).execute(args);

        System.exit(exitCode);
    }
}
