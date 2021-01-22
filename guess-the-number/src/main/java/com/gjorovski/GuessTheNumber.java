package com.gjorovski;

import picocli.CommandLine;

import java.util.Scanner;
import java.util.concurrent.Callable;

@CommandLine.Command(name = "Guess The Number", mixinStandardHelpOptions = true, version = "1.0.0",
        description = "See how quickly the computer can guess your number!")
public class GuessTheNumber implements Callable<Integer> {
    @CommandLine.Parameters(index = "0", description = "The beginning of the guess range.")
    private int from;

    @CommandLine.Parameters(index = "1", description = "The end of the guess range.")
    private int to;

    @Override
    public Integer call() {
        Scanner scanner = new Scanner(System.in);
        int min = from;
        int max = to;

        while (true) {
            int guess = (int) (Math.random() * (max - min + 1) + min);

            System.out.printf("Your number is %s%n", guess);
            System.out.println("greater/smaller/correct");

            String answer = scanner.nextLine();

            if (answer.equals("greater")) {
                min = guess;
            } else if (answer.equals("smaller")) {
                max = guess;
            } else {
                break;
            }
        }

        System.out.println("Slow but determined!");

        return 0;
    }

    public static void main(String[] args) {
        int exitCode = new CommandLine(new GuessTheNumber()).execute(args);

        System.exit(exitCode);
    }
}
