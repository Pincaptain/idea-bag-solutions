package com.gjorovski.shape;

import javax.swing.*;

public class FrameShape extends JFrame {
    public FrameShape() {
        setSize(640, 400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("Newtonian Gravity Simulation");
        add(new CanvasShape());
        setVisible(true);
    }
}
