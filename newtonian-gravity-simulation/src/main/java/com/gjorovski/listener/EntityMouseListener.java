package com.gjorovski.listener;

import com.gjorovski.model.Entity;
import com.gjorovski.model.Vector;
import com.gjorovski.service.ColorService;
import com.gjorovski.service.EntityService;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class EntityMouseListener implements MouseListener {
    @Override
    public void mouseClicked(MouseEvent e) { }

    @Override
    public void mousePressed(MouseEvent e) {
        Entity entity = new Entity(4, new Vector(e.getX(), e.getY()), ColorService.generateRandomColor());

        EntityService.getInstance().addEntity(entity);
    }

    @Override
    public void mouseReleased(MouseEvent e) { }

    @Override
    public void mouseEntered(MouseEvent e) { }

    @Override
    public void mouseExited(MouseEvent e) { }
}
