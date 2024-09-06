package shapesSokoban;

import java.util.*;

public class Level {
	protected Shapes shape;
	protected int row;
	protected int col;
	
	public Level(Shapes shape, int row, int col) {
		this.shape = shape;
		this.row = row;
		this.col = col;
	}
	
	public String toString() {
		return "There is a " + this.shape +  
				" at grid location "	+ this.row + "/" + this.col + ".";
	}
}
