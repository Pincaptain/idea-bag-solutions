package controller;

import javafx.event.ActionEvent;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;

public class CalculatorController {
    public TextField display;

    public void onOperandClicked(ActionEvent event) {
        // Get the clicked operand button
        Button operandButton = (Button) event.getSource();
        display.setText("Hey");
    }
}
