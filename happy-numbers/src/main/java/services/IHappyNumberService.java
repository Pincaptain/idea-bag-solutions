package services;

import java.util.List;

public interface IHappyNumberService {
    public List<Integer> getHappyNumbers(int offset, final int limit);
}
