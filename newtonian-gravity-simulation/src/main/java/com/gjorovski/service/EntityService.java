package com.gjorovski.service;

import com.gjorovski.model.Entity;
import com.gjorovski.model.Vector;
import lombok.Getter;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Function;

@Getter
public class EntityService {
    private static EntityService instance;

    public static EntityService getInstance() {
        if (EntityService.instance == null) {
            EntityService.instance = new EntityService();
        }

        return instance;
    }

    private final List<Entity> entities;
    private final List<Function<Entity, Void>> entityListeners;

    private EntityService() {
        entities = new ArrayList<>();
        entityListeners = new ArrayList<>();
    }

    public void addEntity(Entity entity) {
        if (entity != null) {
            entities.add(entity);
            notifyEntityChanged(entity);
        }
    }

    public void moveEntity(Entity entity, Vector velocity) {
        if (entity == null) { return; }

        entity.getVector().add(velocity);
        notifyEntityChanged(entity);
    }

    public void removeEntity(Entity entity) {
        if (entity != null) {
            if (entities.remove(entity)) {
                notifyEntityChanged(entity);
            }
        }
    }

    public void addEntityListener(Function<Entity, Void> onEntitiesChanged) {
        if (onEntitiesChanged != null) {
            entityListeners.add(onEntitiesChanged);
        }
    }

    private void notifyEntityChanged(Entity entity) {
        entityListeners.forEach(function -> function.apply(entity));
    }
}
