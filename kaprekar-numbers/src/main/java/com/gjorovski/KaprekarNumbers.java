package com.gjorovski;

import com.gjorovski.service.KaprekarNumberService;
import picocli.CommandLine;

import java.util.List;
import java.util.concurrent.Callable;

@CommandLine.Command(name = "kaprekar", mixinStandardHelpOptions = true, version = "1.0.0",
        description = "Print all kaprekar numbers in the given range.")
public class KaprekarNumbers implements Callable<Integer> {
    @CommandLine.Parameters(index = "0", description = "The first number in the range.")
    private int start;

    @CommandLine.Parameters(index = "1", description = "The last number in the range.")
    private int end;

    public static void main(String[] args) {
        int exitCode = new CommandLine(new KaprekarNumbers()).execute(args);

        System.exit(exitCode);
    }

    @Override
    public Integer call() {
        KaprekarNumberService kaprekarService = new KaprekarNumberService();

        List<Integer> kaprekarNumbers = kaprekarService.inRange(start, end);

        for (int kaprekarNumber : kaprekarNumbers) {
            System.out.println(kaprekarNumber);
        }

        return 0;
    }
}
