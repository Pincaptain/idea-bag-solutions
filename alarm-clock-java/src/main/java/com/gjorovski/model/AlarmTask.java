package com.gjorovski.model;

import com.gjorovski.service.AlarmService;
import lombok.Getter;
import lombok.Setter;
import lombok.SneakyThrows;

import java.util.Timer;
import java.util.TimerTask;
import java.util.function.Consumer;

@Getter
@Setter
public class AlarmTask extends TimerTask {
    private Alarm alarm;
    private Timer timer;

    private Consumer<Alarm> onAlarm;

    public AlarmTask(Alarm alarm) {
        this.alarm = alarm;
    }

    public void setOnAlarm(Consumer<Alarm> onAlarm) {
        this.onAlarm = onAlarm;
    }

    public void schedule() {
        Timer timer = new Timer();
        timer.schedule(this, alarm.getAlarmAt().toDate());

        this.timer = timer;
    }

    @SneakyThrows
    @Override
    public void run() {
        AlarmService.getInstance().removeAlarm(alarm);

        if (alarm.isDaily()) {
            alarm.setAlarmAt(alarm.getAlarmAt().plusDays(1));
            AlarmService.getInstance().addAlarm(alarm, onAlarm);
        }

        if (this.onAlarm != null) {
            this.onAlarm.accept(alarm);
        }
    }

    public void dispose() {
        timer.cancel();
        cancel();
    }
}
