import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class Main extends Application {
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        // Get root fxml view (stage)
        Parent root = FXMLLoader.load(getClass().getResource("fxml/calculator.fxml"));

        // Update the window with a title and a scene
        // Show the window after updating
        primaryStage.setTitle("Calculator");
        primaryStage.setScene(new Scene(root));
        primaryStage.show();
    }
}
