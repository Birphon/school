package shapesSokoban;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		// int lvlNum, String desc, int width, int height
		Game game = new Game();
		System.out.println("This is assuming that a level has already been selected");
		System.out.println("A note: The grid in this level is 10x10");
		System.out.println("Starts at 0/0 and ends at 9/9 - 1/1 means 1 down and 1 right");
		
		game.addLevel(Shapes.CIRCLE, 5, 9);
		game.addLevel(Shapes.SQUARE, 0, 0);
		game.addLevel(Shapes.STAR, 9, 9);
		game.addLevel(Shapes.TRIANGLE, 8, 2);
		
		System.out.println(game);
	}

}