package com.gjorovski.model;

import lombok.Getter;
import lombok.Setter;

import java.awt.*;
import java.util.Objects;
import java.util.UUID;

@Getter
@Setter
public class Entity {
    private String id;
    private int mass;
    private Vector vector;
    private Color color;

    public Entity(int mass, Vector vector, Color color) {
        id = UUID.randomUUID().toString();
        this.mass = mass;
        this.vector = vector;
        this.color = color;
    }

    public int getSize() {
        return ((int) Math.log(mass)) * 10;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Entity entity = (Entity) o;
        return id.equals(entity.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }
}
