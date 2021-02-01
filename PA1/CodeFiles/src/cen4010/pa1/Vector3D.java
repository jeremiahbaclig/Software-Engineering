// packages
package src.cen4010.pa1;

public class Vector3D {

	private double x;
	private double y;
	private double z;
	private final double HUNDREDTHS = 0.001;
	
	/* 
	 * Double wrapper class is immutable.
	 * constructor that takes the x, y, and z coordinates, which should be doubles 
	 */
	public Vector3D(Double x, Double y, Double z) {  
		this.x = x;
		this.y = y;
		this.z = z;
	}
	
	// should multiply x, y, and z by a common factor f.
	public Vector3D scale(double f) { 
		return new Vector3D(this.x*f, this.y*f, this.z*f);
	}
	
	// takes one Vector3D as an argument adds the corresponding coordinates to its own and produces a new Vector3D
	public Vector3D add(Vector3D v) {
		return new Vector3D(this.x+v.x, this.y+v.y, this.z+v.z);
	}
	
	// subtract argument v's coordinates from the corresponding coordinates in "this" producing a new Vector3D object
	public Vector3D subtract(Vector3D v) {
		return new Vector3D(this.x-v.x, this.y-v.y, this.z-v.z);
	}
	
	// shorthand for scale by -1
	public Vector3D negate() {
		return new Vector3D(this.x*-1, this.y*-1, this.z*-1);
	}
	
	// Produce the dot product of "this" Vector3D and argument Vector3D v
	public double dot(Vector3D v) {
		return this.x*v.x + this.y*v.y + this.z*v.z;
	}
	
	// returns the magnitude of a Vector3D
	public double magnitude() {
		return Math.sqrt(x*x + y*y + z*z);
	}
	
	public String toString() {
		return String.format(null, null);  // "for reasonable output"?
	}
	
	// implementation of equals - float and double arithmetic is not exact, thus, must allow for a tolerance
	public boolean equals(Vector3D v) {
		if(Math.abs(v.x-this.x) < HUNDREDTHS){
			return true;  
		}
		if(Math.abs(v.y-this.y) < HUNDREDTHS){
			return true; 
		}
		if(Math.abs(v.z-this.z) < HUNDREDTHS){
			return true; 
		}
		return false;
	}
	
    // WILL BE DELETED - just testing
    public int sampleMethod() {
        System.out.println("5");
        return 5;
    }

    public static void main(String args[]) {
        System.out.println("hello");
    }
}
