package com.gjorovski;

import com.gjorovski.shape.FrameShape;

import java.util.concurrent.Callable;

public class NewtonianGravitySimulation implements Callable<Integer> {
    @Override
    public Integer call() {
        FrameShape frameShape = new FrameShape();

        return 0;
    }

    public static void main(String[] args) {
        new NewtonianGravitySimulation().call();
    }
}
