package com.gjorovski.model;

import lombok.AllArgsConstructor;
import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import org.joda.time.DateTime;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class Alarm {
    private String name;
    private String description;

    private boolean isDaily;

    private DateTime alarmAt;

    @Override
    public String toString() {
        return String.format("%s - %s", name, alarmAt.toString("dd-M-yyyy hh:mm:ss"));
    }
}
