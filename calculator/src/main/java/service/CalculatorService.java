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
        if (previousOperand == null) {
            previousOperation = getOperation(operation);
            previousOperand = operand;

            return operand;
        }

        int calculation = 0;
        switch (previousOperation) {
            case ADDITION:
                calculation = previousOperand + operand;
                break;
            case SUBTRACTION:
                calculation = previousOperand - operand;
                break;
            case MULTIPLICATION:
                calculation = previousOperand * operand;
                break;
            case DIVISION:
                calculation = previousOperand / operand;
        }

        previousOperation = getOperation(operation);
        previousOperand = calculation;

        return calculation;
    }

    public void reset() {
        previousOperation = null;
        previousOperand = null;
    }

    public void setOperation(String operationString) {
        previousOperation = getOperation(operationString);
    }

    private Operation getOperation(String operationString) {
        switch (operationString) {
            case "+":
                return Operation.ADDITION;
            case "-":
                return Operation.SUBTRACTION;
            case "*":
                return Operation.MULTIPLICATION;
            default:
                return Operation.DIVISION;
        }
    }
}
