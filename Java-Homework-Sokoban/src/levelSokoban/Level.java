package levelSokoban;

import java.util.*;

public class Level {
	protected int lvlNum;
	protected String description;
	protected int width;
	protected int height;
	
	public Level(int lvlNum, String desc, int width, int height) {
		this.lvlNum = lvlNum;
		this.description = desc;
		this.width = width;
		this.height = height;
	}
	
	public String toString() {
		return "The level number is a " + this.lvlNum + 
				". The level is about: " + this.description + 
				". The level has a width of "	+ this.width +
				" pixels and a height of " + this.height + " pixels.";
	}
}
