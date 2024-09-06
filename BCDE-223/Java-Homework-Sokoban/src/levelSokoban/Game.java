package levelSokoban;

import java.util.*;
import java.math.*;
public class Game {
	
	List<Level> allMyLevels = new ArrayList<Level>();
	
	public void addLevel(int lvlNum, String description, int width, int height) {
		Level level = new Level(lvlNum, description, width, height);
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
