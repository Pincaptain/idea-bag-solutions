package com.gjorovski.ui;

import com.gjorovski.model.Alarm;
import com.gjorovski.service.AlarmService;
import javafx.application.Application;
import javafx.application.Platform;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.stage.Stage;
import org.joda.time.DateTime;
import tornadofx.control.DateTimePicker;

import java.time.LocalDateTime;

public class AlarmApplication extends Application {
    private BorderPane scaffold;
    private VBox alarmVBox;
    private VBox alarmFormVBox;
    private ListView<Alarm> alarmListView;

    @Override
    public void start(Stage primaryStage) {
        drawAlarmVBox();
        drawAlarmFormVBox();
        drawScaffold();

        Scene scene = new Scene(scaffold, 640, 400);

        primaryStage.setTitle("Alarm Clock");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    private void drawScaffold() {
        scaffold = new BorderPane();
        scaffold.setLeft(alarmVBox);
        scaffold.setCenter(alarmFormVBox);
    }

    private void drawAlarmVBox() {
        alarmVBox = new VBox();
        alarmVBox.setPadding(new Insets(15, 12, 15, 12));
        alarmVBox.setSpacing(10);
        alarmVBox.setStyle("-fx-background-color: #336699;");

        Label alarmListLabel = new Label("Alarms");
        alarmListLabel.setTextFill(Color.WHITE);

        alarmListView = new ListView<>();
        alarmListView.getSelectionModel().setSelectionMode(SelectionMode.MULTIPLE);

        Button alarmListRemoveButton = new Button("Remove");
        alarmListRemoveButton.setOnMouseClicked(event -> {
            alarmListView.getSelectionModel()
                    .getSelectedItems()
                    .forEach(alarm -> AlarmService.getInstance().removeAlarm(alarm));

            redrawAlarmListView();
        });

        alarmVBox.getChildren().addAll(alarmListLabel, alarmListView, alarmListRemoveButton);
    }

    private void drawAlarmFormVBox() {
        alarmFormVBox = new VBox();
        alarmFormVBox.setPadding(new Insets(15, 12, 15, 12));
        alarmFormVBox.setSpacing(10);

        Label alarmLabel = new Label("Add Alarm");

        TextField alarmNameField = new TextField("Name");
        TextField alarmDescriptionField = new TextField("Description");

        DateTimePicker alarmDateTimePicker = new DateTimePicker();
        alarmDateTimePicker.setDateTimeValue(LocalDateTime.now());

        CheckBox alarmIsDailyCheckbox = new CheckBox("Repeat");

        Button alarmButton = new Button("Add");
        alarmButton.setOnMouseClicked(event -> {
            String name = alarmNameField.getText();
            String description = alarmDescriptionField.getText();
            LocalDateTime localDateTime = alarmDateTimePicker.getDateTimeValue();
            DateTime alarmAt = DateTime.parse(localDateTime.toString());
            boolean isDaily = alarmIsDailyCheckbox.isSelected();
            Alarm alarm = new Alarm(name, description, isDaily, alarmAt);

            AlarmService.getInstance().addAlarm(alarm, a -> {
                Platform.runLater(this::redrawAlarmListView);
                Platform.runLater(() -> this.showAlarmDialog(alarm));
            });

            redrawAlarmListView();
        });

        alarmFormVBox.getChildren()
                .addAll(alarmLabel, alarmNameField, alarmDescriptionField, alarmDateTimePicker, alarmIsDailyCheckbox, alarmButton);
    }

    public void redrawAlarmListView() {
        System.out.println("Redrawing");
        alarmListView.getItems().clear();

        AlarmService.getInstance()
                .getAlarms()
                .forEach(a -> alarmListView.getItems().add(a));
    }

    public void showAlarmDialog(Alarm alarm) {
        ButtonType doneButtonType = new ButtonType("Done", ButtonBar.ButtonData.OK_DONE);
        Dialog<String> dialog = new Dialog<>();

        dialog.setTitle(String.format("%s", alarm.getName()));
        dialog.getDialogPane().setContent(new Label(String.format("%s is beeping!", alarm.getName())));
        dialog.getDialogPane().getButtonTypes().add(doneButtonType);
        dialog.showAndWait();
    }
}
