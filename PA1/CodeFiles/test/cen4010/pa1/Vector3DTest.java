// packages
package test.cen4010.pa1;

// imports
import org.junit.jupiter.api.Test;
import src.cen4010.pa1.Vector3D;

import static org.junit.jupiter.api.Assertions.*;

class Vector3DTest {
	
	@Test
	public void testToString() {
		
	}
	
	@Test
	public void testEquals() {  // very basic equality test, self-equality, equality to a different object, tests varying only one coordinate at a time.
		
	}
	
	/*
	 * very similar to testEquals, and needs a working equals to test it. checking the unit scale as 
	 * returning (a copy of) the same vector, and scaling by some value to make test multiplying each coordinate
	 * 
	 */
	@Test
	public void testScale() {
		
	}
	
	@Test
	public void testAdd() {  // simple tests
		
	}
	
	@Test
	public void testSubtract() {  // simple tests
		
	}
	
	@Test
	public void testNegate() {  // simple tests
		
	}
	
	@Test
	public void testMagnitute() {  // simple tests
		
	}
	
	
    // WILL BE DELETED - just testing
    @Test
    public void testSampleMethod() {
        Vector3D testing = new Vector3D();
        int result = testing.sampleMethod();

        assertEquals(5, result);
    }

}
