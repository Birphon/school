package Sokoban;

public class Target extends Enterable{
	
	public Target(int y, int x) {
		// TODO Auto-generated constructor stub
		super(y, x);
	}

	public boolean isCompleted() {
		return onTopObject instanceof Crate;
	}
	
	public String toString() {
		if(onTopObject != null) {
			return onTopObject.toString().toUpperCase();
		} else {
			return "+";
		}
	}
	
}
