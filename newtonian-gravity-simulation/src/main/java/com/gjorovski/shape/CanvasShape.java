package com.gjorovski.shape;

import com.gjorovski.listener.EntityMouseListener;
import com.gjorovski.model.Entity;
import com.gjorovski.model.Vector;
import com.gjorovski.service.EntityService;

import javax.swing.*;
import java.awt.*;
import java.util.Timer;
import java.util.TimerTask;

public class CanvasShape extends JPanel {
    public CanvasShape() {
        addMouseListener(new EntityMouseListener());

        EntityService.getInstance().addEntityListener(entity -> {
            repaint();
            return null;
        });

        Timer timer = new Timer();

        timer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                if (EntityService.getInstance().getEntities().size() == 0) { return; }

                EntityService.getInstance().moveEntity(EntityService.getInstance().getEntities().get(0),
                        new Vector(1, 1));
                repaint();
            }
        }, 0, 17);
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        setBackground(Color.BLACK);

        EntityService entityService = EntityService.getInstance();
        entityService.addEntity(new Entity(2, new Vector(100, 100), Color.RED));
        entityService.addEntity(new Entity(4, new Vector(200, 200), Color.BLUE));
        entityService.addEntity(new Entity(32, new Vector(300, 300), Color.GREEN));

        Graphics2D graphics2D = (Graphics2D) g;
        graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

        entityService.getEntities().forEach(entity -> {
            graphics2D.setColor(entity.getColor());
            graphics2D.fillOval(entity.getVector().getX(), entity.getVector().getY(), entity.getSize(),
                    entity.getSize());
        });
    }
}
