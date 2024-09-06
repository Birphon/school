package shapesSokoban;

import java.util.*;
import java.math.*;
public class Game {
	
	List<Level> allMyLevels = new ArrayList<Level>();
	
	public void addLevel(Shapes shape, int row, int col) {
		Level level = new Level(shape, col, col);
		this.allMyLevels.add(level);
	}
	
	@Override
	public String toString() {
		String result = "";
		for (Level level : this.allMyLevels) {
			result += level + "\n";
		}
		return result;
	}
}
