import com.gjorovski.service.HardyRamanujanService;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class HardyRamanujanNumberTest {
    @Test
    public void isHardyRamanujanNumberEquality() {
        HardyRamanujanService hardyRamanujanService = new HardyRamanujanService();

        Assertions.assertTrue(hardyRamanujanService.isHardyRamanujanNumber(1729));
        Assertions.assertTrue(hardyRamanujanService.isHardyRamanujanNumber(4104));
        Assertions.assertTrue(hardyRamanujanService.isHardyRamanujanNumber(327763));
    }
}
