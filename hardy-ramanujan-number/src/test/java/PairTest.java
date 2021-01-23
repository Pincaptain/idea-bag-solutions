import com.gjorovski.model.Pair;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class PairTest {
    @Test
    public void pairEqualityShouldReturnTrue() {
        Pair firstPair = new Pair(0, 1);
        Pair secondPair = new Pair(1, 0);

        Pair thirdPair = new Pair(1, 0);
        Pair forthPair = new Pair(1, 0);

        Pair fifthPair = new Pair(1, 2);
        Pair sixthPair = new Pair(5, 1);

        Assertions.assertEquals(firstPair, secondPair);
        Assertions.assertEquals(thirdPair, forthPair);
        Assertions.assertNotEquals(fifthPair, sixthPair);
    }
}
