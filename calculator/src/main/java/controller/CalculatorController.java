package controller;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import service.CalculatorService;

public class CalculatorController {
    // Calculator service
    private CalculatorService calculatorService = new CalculatorService();

    // Boolean to keep track of what is shown in the display
    // Is it a result or is it a current entry
    private boolean isResult = false;

    // Calculator display text field
    public TextField display;

    @FXML
    public void initialize() {
        // Initialize the display value
        display.setText("0");
    }

    // Handles operand button click
    public void onOperandClicked(ActionEvent event) {
        // Get the clicked operand button
        // Get the string operand from the operand button
        // Get the current value from the display
        Button operandButton = (Button) event.getSource();
        String operandString = operandButton.getText();
        String value = display.getText();

        // Modify the value based on the operand pressed
        // by applying the operand to the value
        // If the value shown is result replace it with the new number
        // and flip isResult off
        if (isResult) {
            value = operandString;
            isResult = false;
        }
        else if (value.equals("0")) {
            value = operandString;
        } else {
            value += operandString;
        }

        // Set the display to the updated value
        display.setText(value);
    }

    // // Handles operation button click
    public void onOperationClicked(ActionEvent event) {
        // Get the clicked operation button
        // Get the operation string from the operation button
        Button operationButton = (Button) event.getSource();
        String operationString = operationButton.getText();

        // If the display shows the result
        // do not calculate since no new operand was entered
        if (isResult) {
            calculatorService.setOperation(operationString);
            return;
        }

        // Get the operand string from the display
        int operand = Integer.parseInt(display.getText());

        // Do the calculation using the service
        // Flip the isResult boolean since you are displaying a result
        // from a calculation
        // Display the calculated result
        int calculation = calculatorService.calculate(operationString, operand);
        isResult = true;
        display.setText(String.valueOf(calculation));
    }

    // Handles CE (remove last number) button click
    public void onRemoveClicked(ActionEvent event) {
        // Get the current value from the display
        String value = display.getText();

        // Remove the last character from it
        // Or if it is the last character replace it with zero
        if (value.length() == 1) {
            value = "0";
        } else {
            value = value.substring(0, value.length() - 1);
        }

        // Set the display to the updated value
        display.setText(value);
    }

    // Handles C (clear number) button click
    public void onClearClicked(ActionEvent event) {
        // Reset the service
        calculatorService.reset();

        // Clear the display
        display.setText("0");
    }
}
