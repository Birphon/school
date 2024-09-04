ackage Sokoban;

public class Level {
	
	protected Placeable[] [] allPlaceables;
	
	private int height;
	private int width;
	private String name;
	private int moveCount = 0;
	
	public int targetCount = 0;
					 
	public Level(String name, int height, int width, String level) {
		this.height = height;
		this.width = width;
		this.name = name;
		allPlaceables = new Placeable[height][width];
		Reader(level);
		
	}
	
	public void Reader(String level) {
		char[] allPecies = level.toCharArray();
		Placeable place = null; 
		int row = 0;
		int col = 0;
				
		for(int i = 0; i < allPecies.length; i++) {
			
			
			if(i%width == 0 && !(i == 0)) {
				row++;
				col = 0;
			}
			
			switch(allPecies[i]) {
			case '.' : 
				place = new Empty(row, col);
				break;
				
			case '#' : 
				place = new Wall(row, col);
				break;
				
			case '+' : 
				place = new Target(row, col);
				targetCount++;
				break;
				
			case 'W' : 
				place = new Target(row, col);
				((Enterable)place).addWorker(new Worker(row, col));
				targetCount++;
				break;
				
			case 'X' : 
				place = new Target(row, col);
				((Enterable)place).addCrate(new Crate(row, col));
				targetCount++;
				break;
				
			
			case 'x' : 
				place = new Empty(row, col);
				((Enterable)place).addCrate(new Crate(row, col));
				break;
			
			case 'w' : 
				place = new Empty(row, col);
				((Enterable)place).addWorker(new Worker(row, col));
				break;
							
			}
			
			allPlaceables[row][col] = place;
			col++;
		}
	}

	public void incrementMoveCount() {
		moveCount++;
	}
	public int getWidth() {
		return width;
	}

	public int getHeight() {
		return height;
	}

	public int getMoveCount() {
		return moveCount;
	}

	public String getName() {
		return name;
	}
	
	public Placeable getTile(int x, int y) {
		return allPlaceables[y][x];
	}

	public int getCompletedCount() {
		
		int count = 0;
		for(Placeable[] row : allPlaceables) {
			for(Placeable tile : row) {
				if(tile instanceof Target) {
					if(((Target)tile).isCompleted()) {
						count++;
					}
				}
			}
		};
		return count;
	}
	
	public Worker getWorker() {
		
		Worker worker = null;
		for(Placeable[] row : allPlaceables) {
			for(Placeable tile : row) {				
				if(tile instanceof Enterable) {
					if(((Enterable)tile).onTopObject instanceof Worker)
						worker = (Worker)((Enterable)tile).onTopObject;
				}
			}
		};
		return worker;
	}
	
	public String toString() {
		String string = name + "\n";
		for(Placeable[] rolCol : allPlaceables ) {
			for(Placeable tile : rolCol ) {
				string += tile.toString();
			}
			
			string += "\n";
			
		}
		
		string += "move " + moveCount + "\n";
		string += "completed " + getCompletedCount() + " of " + targetCount + "\n";
		
		return string;

	}
}
