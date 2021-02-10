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
	public void testScale() { // test to see if method properly scales the given vector by a value
		Vector3D testScaleVector = new Vector3D(4.0, 5.0, 6.0);
		assertEquals(new Vector3D(12.0, 15.0, 18.0).toString(), testScaleVector.scale(3.0).toString());
	}
	
	@Test
	public void testAdd() {  // test to see if method properly adds two given vectors
		Vector3D testAddVector = new Vector3D(4.0, 5.0, 6.0);
		Vector3D vectorToAdd = new Vector3D(7.0, 8.0, 9.0);
		assertEquals(new Vector3D(11.0, 13.0, 15.0).toString(), testAddVector.add(vectorToAdd).toString());
	}
	
	@Test
	public void testSubtract() {  // test to see if method properly subtracts two given vectors
		Vector3D testSubtractVector = new Vector3D(10.0, 11.0, 12.0);
		Vector3D vectorToSubtract = new Vector3D(6.0, 2.0, 5.0);
		assertEquals(new Vector3D(4.0, 9.0, 7.0).toString(), testSubtractVector.subtract(vectorToSubtract).toString());
	}
	
	@Test
	public void testNegate() {  // test to see if method properly changes the qualities of the vectors to negatives
		Vector3D testNegateVector = new Vector3D(-3.0, -3.0, -3.0);
		Vector3D vectortoNegate = new Vector3D(3.0, 3.0, 3.0);
		assertEquals(testNegateVector.toString(), vectortoNegate.negate().toString());
	}
	
	@Test
	public void testMagnitude() {  // test to see if the magnitude can properly be extracted from vector
		Vector3D testMagnitudeVector = new Vector3D(2.0, 2.0, 2.0);
		// I could hard code the answer but I didn't want to risk messing up floats since they can be fussy
		double testMagnitudeVal = Math.sqrt((2 * 2) + (2 * 2) + (2 * 2));
		assertEquals(testMagnitudeVal, testMagnitudeVector.magnitude());
	}

	@Test
	public void testDot() {  // test to see if the magnitude can properly be extracted from two different vectors
		Vector3D testDotVector1 = new Vector3D(2.0, 2.0, 2.0);
		Vector3D testDotVector2 = new Vector3D(4.0, 4.0, 4.0);
		// Same reasoning behind the testMagnitude.
		double testDotVal = ((2 * 4) + (2 * 4) + (2 * 4));
		assertEquals(testDotVal, testDotVector1.dot(testDotVector2));
	}
}
