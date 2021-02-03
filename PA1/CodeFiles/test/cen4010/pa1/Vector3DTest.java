// packages
package test.cen4010.pa1;

// imports
import org.junit.jupiter.api.Test;
import src.cen4010.pa1.Vector3D;
import static org.junit.jupiter.api.Assertions.*;

class Vector3DTest {
	
	@Test
	public void testToString() {
		Vector3D testStringVector = new Vector3D(3.7, 4.5, 5.0);
		String value = "X: 3.700 Y: 4.500 Z: 5.000";
		assertEquals(value, testStringVector.toString());
	}
	
	@Test
	public void testEquals() {  // very basic equality test, self-equality, equality to a different object, tests varying only one coordinate at a time.
		Vector3D testEqualsVector = new Vector3D(3.7, 4.5, 5.0);
		Vector3D testEqualsCheck = new Vector3D(3.7, 4.5, 5.0);
		
		assertEquals(true, testEqualsVector.equals(testEqualsCheck));
	}
	
	/*
	 * very similar to testEquals, and needs a working equals to test it. checking the unit scale as 
	 * returning (a copy of) the same vector, and scaling by some value to make test multiplying each coordinate
	 */
	@Test
	public void testScale() {
		Vector3D testScaleVector = new Vector3D(4.0, 5.0, 6.0);
		assertEquals(new Vector3D(12.0, 15.0, 18.0).toString(), testScaleVector.scale(3.0).toString());
	}
	
	@Test
	public void testAdd() {  // simple tests
		Vector3D testAddVector = new Vector3D(4.0, 5.0, 6.0);
		Vector3D vectorToAdd = new Vector3D(7.0, 8.0, 9.0);
		assertEquals(new Vector3D(11.0, 13.0, 15.0).toString(), testAddVector.add(vectorToAdd).toString());
	}
	
	@Test
	public void testSubtract() {  // simple tests
		Vector3D testSubtractVector = new Vector3D(10.0, 11.0, 12.0);
		Vector3D vectorToSubtract = new Vector3D(6.0, 2.0, 5.0);
		assertEquals(new Vector3D(4.0, 9.0, 7.0).toString(), testSubtractVector.subtract(vectorToSubtract).toString());
	}
	
	@Test
	public void testNegate() {  // simple tests
		
	}
	
	@Test
	public void testMagnitude() {  // simple tests
		
	}

	@Test
	public void testDot() {  // simple tests

	}

}
