package levelSokoban;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		// int lvlNum, String desc, int width, int height
		Game game = new Game();
		game.addLevel(1, "The first level ", 100, 100);
		game.addLevel(2, "The second level", 200, 200);
		game.addLevel(3, "The third level ", 300, 300);
		game.addLevel(4, "The forth level ", 400, 400);
		game.addLevel(5, "The fith level  ", 500, 500);
		
		System.out.println(game);
	}

}