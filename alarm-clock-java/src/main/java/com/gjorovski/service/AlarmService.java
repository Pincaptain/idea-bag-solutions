package com.gjorovski.service;

import com.gjorovski.exception.AlarmNotFoundException;
import com.gjorovski.model.Alarm;
import com.gjorovski.model.AlarmTask;
import lombok.SneakyThrows;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;
import java.util.stream.Collectors;

public class AlarmService {
    private static AlarmService instance;

    public static AlarmService getInstance() {
        if (instance == null) {
            instance = new AlarmService();
        }

        return instance;
    }

    private final List<AlarmTask> alarmTasks;

    public AlarmService() {
        alarmTasks = new ArrayList<>();
    }

    public void addAlarm(Alarm alarm, Consumer<Alarm> onAlarm) {
        AlarmTask alarmTaskToAdd = new AlarmTask(alarm);
        alarmTaskToAdd.setOnAlarm(onAlarm);
        alarmTaskToAdd.schedule();

        alarmTasks.add(alarmTaskToAdd);
    }

    @SneakyThrows
    public void removeAlarm(Alarm alarm) {
        AlarmTask alarmTaskToRemove = alarmTasks.stream()
                .filter(alarmTask -> alarmTask.getAlarm().equals(alarm))
                .findFirst()
                .orElseThrow(AlarmNotFoundException::new);
        alarmTaskToRemove.dispose();

        alarmTasks.remove(alarmTaskToRemove);
    }

    public List<Alarm> getAlarms() {
        return alarmTasks.stream()
                .map(AlarmTask::getAlarm)
                .collect(Collectors.toList());
    }
}
