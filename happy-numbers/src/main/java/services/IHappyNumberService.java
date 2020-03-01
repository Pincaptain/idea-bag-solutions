package services;

import java.util.List;

public interface IHappyNumberService {
    List<Integer> getHappyNumbers(int offset, final int limit);
}
