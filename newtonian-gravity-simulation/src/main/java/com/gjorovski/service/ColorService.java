package com.gjorovski.service;

import java.awt.*;
import java.util.Random;

public class ColorService {
    public static Color generateRandomColor() {
        Random random = new Random();

        int r = random.nextInt(255);
        int g = random.nextInt(255);
        int b = random.nextInt(255);

        return new Color(r, g, b);
    }
}
