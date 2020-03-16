package controller;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import service.CalculatorService;

public class CalculatorController {
    private CalculatorService calculatorService = new CalculatorService();

    private boolean isResult = false;

    public TextField display;

    @FXML
    public void initialize() {
        display.setText("0");
    }

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

    public void onOperationClicked(ActionEvent event) {
        Button operationButton = (Button) event.getSource();
        String operationString = operationButton.getText();

        if (isResult) {
            calculatorService.setOperation(operationString);
            return;
        }

        int operand = Integer.parseInt(display.getText());
        int calculation = calculatorService.calculate(operationString, operand);

        isResult = true;
        display.setText(String.valueOf(calculation));
    }

    public void onRemoveClicked(ActionEvent event) {
        String value = display.getText();
        if (value.length() == 1) {
            value = "0";
        } else {
            value = value.substring(0, value.length() - 1);
        }

        display.setText(value);
    }

    public void onClearClicked(ActionEvent event) {
        calculatorService.reset();
        display.setText("0");
    }
}
