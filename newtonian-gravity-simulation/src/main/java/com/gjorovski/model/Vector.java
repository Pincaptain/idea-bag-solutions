package com.gjorovski.model;

import lombok.*;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class Vector {
    private int x;
    private int y;

    public void add(Vector vector) {
        this.x += vector.x;
        this.y += vector.y;
    }
}
