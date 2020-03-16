package service;

public class CalculatorService {
    public enum Operation {
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION
    }

    private Operation previousOperation;
    private Integer previousOperand;

    public int calculate(String operation, int operand) {
        // Check if a previous operand exists
        // If it does not set it to the current operand
        // Also set the previous operation to the current operation
        // Return 0 since no calculation took place
        if (previousOperand == null) {
            previousOperation = getOperation(operation);
            previousOperand = operand;

            return operand;
        }

        // Store the calculated value in calculation
        // based on the previous operation
        int calculation = 0;
        switch (previousOperation) {
            case ADDITION:
                calculation = add(operand);
                break;
            case SUBTRACTION:
                calculation = subtract(operand);
                break;
            case MULTIPLICATION:
                calculation = multiply(operand);
                break;
            case DIVISION:
                calculation = divide(operand);
        }

        // Modify the previous operation
        // Modify the previous operand
        previousOperation = getOperation(operation);
        previousOperand = calculation;

        return calculation;
    }

    public void reset() {
        // Reset the previous operation
        // Reset the previous operand
        previousOperation = null;
        previousOperand = null;
    }

    public void setOperation(String operationString) {
        // Modify the previous operator
        // based on the new operator passed
        previousOperation = getOperation(operationString);
    }

    private int add(int operand) {
        return previousOperand + operand;
    }

    private int subtract(int operand) {
        return previousOperand - operand;
    }

    private int multiply(int operand) {
        return previousOperand * operand;
    }

    private int divide(int operand) {
        return previousOperand / operand;
    }

    private Operation getOperation(String operationString) {
        switch (operationString) {
            case "+": return Operation.ADDITION;
            case "-": return Operation.SUBTRACTION;
            case "*": return Operation.MULTIPLICATION;
            default: return Operation.DIVISION;
        }
    }
}
