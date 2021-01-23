package com.gjorovski.service;

import com.gjorovski.model.Pair;

import java.util.ArrayList;

public class HardyRamanujanService {
    public boolean isHardyRamanujanNumber(int number) {
        int ways = 0;
        ArrayList<Pair> knownPairs = new ArrayList<>();

        for (int i = 1; i < number; i++) {
            for (int j = 1; j < number; j++) {
                int iCubed = (int) Math.pow(i, 3);
                int jCubed = (int) Math.pow(j, 3);

                if (iCubed + jCubed == number) {
                    Pair pair = new Pair(iCubed, jCubed);

                    if (knownPairs.contains(pair)) {
                        continue;
                    }

                    knownPairs.add(pair);
                    ways++;

                    if (ways == 2) {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
