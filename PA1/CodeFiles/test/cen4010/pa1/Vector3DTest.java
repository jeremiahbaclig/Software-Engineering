// packages
package test.cen4010.pa1;

// imports
import org.junit.jupiter.api.Test;
import src.cen4010.pa1.Vector3D;

import static org.junit.jupiter.api.Assertions.*;

class Vector3DTest {

    @Test
    public void testSampleMethod() {
        Vector3D testing = new Vector3D();
        int result = testing.sampleMethod();

        assertEquals(5, result);
    }

}