package rookjumping;
import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;

import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

public class TestRookJumping {
	Game game;

	@BeforeAll
	static void testStart() {
		System.out.println("Testing start");
	}
	
	@BeforeEach
	public void makeEmptyGame() {
		game = new Game();
	}
	
	@AfterEach
	public void eachTestDone() {
		System.out.println("Test done");
	}
	
	@AfterAll
	static void testFinish() {
		System.out.println("Testing finished");
	}
	
// Create random 4*4 map
	public void createWidth4Map() {
		game.addMap("4 by 4 Map", 4);
	}
	
// Create random 5*5 map
	public void createWidth5Map() {
		game.addMap("5 by 5 Map", 5);
	}
	
// Generate a 4*4 map for test purpose.
	public void createTestMapWidth4() {
		game.currentMap = new Map("4*4 Map", 4);
		int[][] test = {{3, 2, 2, 4}, 
						{3, 2, 2, 3}, 
						{3, 2, 1, 3},
						{3, 1, 2, 0}};
		game.currentMap.setSquareArray(test);
		game.currentMap.breadthFirstSearch();
		game.moveHistory.add(new int[] {0,0});
	}
	
// Generate a 5*5 map for test purpose.
	public void createTestMapWidth5() {
		game.currentMap = new Map("5*5 Map", 5);
		int[][] test = {{3, 3, 2, 4, 4}, 
						{4, 2, 3, 2, 1}, 
						{1, 3, 2, 1, 3},
						{2, 3, 2, 1, 2},
						{3, 2, 3, 3, 0}};
		game.currentMap.setSquareArray(test);
		game.currentMap.breadthFirstSearch();
		game.moveHistory.add(new int[] {0,0});
	}
	
// Must 1. create an empty game
	@DisplayName("Empty game has name of 'no maps loaded'")
	@Test
	public void emptyGameHasNameOfNoMapsLoaded() {
		final String EXPECTED_NAME = "No maps loaded";
		final String ERROR_MESSAGE = "'no maps loaded'is expected";
	
		String actualName = game.getMapName();
		assertEquals(EXPECTED_NAME, actualName, ERROR_MESSAGE);
	}
	
	@DisplayName("Empty game has width of 0")
	@Test
	public void emptyGameHasWidth0() {
		final int EXPECTED_WiDTH = 0;
		final String ERROR_MESSAGE = "0 is expected";
		
		int actualWidth = game.getMapWidth();
		assertEquals(EXPECTED_WiDTH, actualWidth, ERROR_MESSAGE);
	}
	
	@DisplayName("Empty game has empty square array values")
	@Test
	public void emptyGameHasEmptySquareArrayValues() {
		final ArrayList<Integer> EXPECTED_VALUE = null;
		final String ERROR_MESSAGE = "null is expected";
		
		ArrayList<Integer> actualValue = game.getSquareArrayValues();
		assertEquals(EXPECTED_VALUE, actualValue, ERROR_MESSAGE);
	}
	
// Must 2. Create a map with random number when width is provided. 
	@DisplayName("4*4 map has name of '4 by 4 Map'")
	@Test 
	public void width4MapHasNameOf4by4Map() {
		createWidth4Map();
		final String EXPECTED_NAME = "4 by 4 Map";
		final String ERROR_MESSAGE = "'4 by 4 Map' is expected";
		
		String actualName = game.getMapName();
		assertEquals(EXPECTED_NAME, actualName, ERROR_MESSAGE);
	}
	
	@DisplayName("4*4 map has width of 4")
	@Test 
	public void width4MapHasWidth4() {
		createWidth4Map();
		final int EXPECTED_WiDTH = 4;
		final String ERROR_MESSAGE = "4 is expected";
		
		int actualWidth = game.getMapWidth();
		assertEquals(EXPECTED_WiDTH, actualWidth, ERROR_MESSAGE);
	}
		
	@DisplayName("4*4 map has values from 1 to 3 except the goal(0)")
	@Test
	public void width4MaphasValuesFrom1To3ExceptGoal() {
		createWidth4Map();
		final boolean EXPECTED = true;
		final String ERROR_MESSAGE = "ture is expected";
		
		// The goal is set 0, the other values should be from 1 to 3
		for(int i = 0; i < game.currentMap.getSquareArray().length-1; i++) {
			boolean actual1 = game.getSquareArrayValues().get(i) > 0;
			boolean actual2 = game.getSquareArrayValues().get(i) < 4;
			
			assertEquals(EXPECTED, actual1, ERROR_MESSAGE);
			assertEquals(EXPECTED, actual2, ERROR_MESSAGE);
		}
	}
	
	@DisplayName("When 3 maps are added, the size of the list is 3")
	@Test
	public void hasSizeThreeWhenThreeMapsAreAdded() {
		game.addMap("4 by 4 Map", 4);
		game.addMap("5 by 5 Map", 5);
		game.addMap("6 by 6 Map", 6);
		
		final int EXPECTED_SIZE = 3;
		final String ERROR_MESSAGE = "3is expected";
		
		int actualSize = game.allMyMaps.size();
		assertEquals(EXPECTED_SIZE, actualSize, ERROR_MESSAGE);	
	}

// Must 3. Created solvable maps
	@DisplayName("4*4 map is solvable")
	@Test
	public void isSolvableMapWidth4() {
		createWidth4Map();
		
		final boolean EXPECTED = true;
		final String ERROR_MESSAGE = "True is expected";
		
		// check if there is more than 0 solvable node.
		boolean actual = game.currentMap.getSolvableNodes().size() > 0;
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
// Must 4. Count the iterations to generate a solvable map.
	@DisplayName("Iteration has been counted to generate 4*4 map")
	@Test
	public void hasIterationCountMapWidth4() {
		createWidth4Map();
		
		final boolean EXPECTED = true;
		final String ERROR_MESSAGE = "True is expected";
		
		// check if there is more than 0 attempts to create a solvable map
		boolean actual = game.currentMap.getIterationNum() > 0;
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
// Must 5. Calculate the move count for the shortest path correctly.
	@DisplayName("Shortest path count is 2 for the 4*4 test map")
	@Test
	public void shortestPathCountForTestMapWidth4() {
		createTestMapWidth4();
		
		final int EXPECTED_COUNT = 2;
		final String ERROR_MESSAGE = "2 is expected";
		
		int actualCount = game.currentMap.getShortestPathMoveCount();
		assertEquals(EXPECTED_COUNT, actualCount, ERROR_MESSAGE);
	}
	
	@DisplayName("Shortest path count is 5 for the 5*5 test map")
	@Test
	public void shortestPathCountForTestMapWidth5() {
		createTestMapWidth5();
		
		final int EXPECTED_COUNT = 5;
		final String ERROR_MESSAGE = "5 is expected";
		
		int actualCount = game.currentMap.getShortestPathMoveCount();
		assertEquals(EXPECTED_COUNT, actualCount, ERROR_MESSAGE);
	}
			
// Must 6. Show the shortest path correctly.
	@DisplayName("Show the shortest path correctly on the 4*4 test map")
	@Test
	public void shortestPathForTestMapWidth4() {
		createTestMapWidth4();
		
		final String EXPECTED = "0[3,3](Move Count: 2)  3[3,0](Move Count: 1)  3[0,0](Move Count: 0)  ";
		final String ERROR_MESSAGE = "'0[3,3](Move Count: 2)  3[3,0](Move Count: 1)  3[0,0](Move Count: 0)  ' is expected";
		
		String actual = game.currentMap.printShortestPathMove();
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
	@DisplayName("Show the shortest path correctly on the 5*5 test map")
	@Test
	public void shortestPathForTestMapWidth5() {
		createTestMapWidth5();
		
		final String EXPECTED = "0[4,4](Move Count: 5)  4[0,4](Move Count: 4)  1[1,4](Move Count: 3)  "
								+ "4[1,0](Move Count: 2)  2[3,0](Move Count: 1)  3[0,0](Move Count: 0)  ";
		final String ERROR_MESSAGE = "'0[4,4](Move Count: 5)  4[0,4](Move Count: 4)  1[1,4](Move Count: 3)  "
								+ "4[1,0](Move Count: 2)  2[3,0](Move Count: 1)  3[0,0](Move Count: 0)  ' is expected";
		
		String actual = game.currentMap.printShortestPathMove();
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
// Must 7. Set the start point to [0,0]
	@DisplayName("start point is [0, 0] on 4*4 map")
	@Test
	public void hasCorrectStartPointForMapWidth4() {
		createWidth4Map();
		
		final String EXPECTED = "[0,0]";
		final String ERROR_MESSAGE = "[0,0] is expected";
		
		String actual = game.getStartPoint();
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
	@DisplayName("start point is [0, 0] on 5*5 map")
	@Test
	public void hasCorrectStartPointForMapWidth5() {
		createWidth5Map();
		
		final String EXPECTED = "[0,0]";
		final String ERROR_MESSAGE = "[0,0] is expected";
		
		String actual = game.getStartPoint();
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
// Must 8. Set the ending point to [width-1, width-1] (check has value 0)
	@DisplayName("4*4 map has goal at (3, 3)")
	@Test
	public void width4MaphasGoalatRow3Col3() {
		createWidth4Map();
		// Only goal value is set 0
		final int EXPECTED_VALUE = 0;
		final String ERROR_MESSAGE = "0 is expected";
		
		int actualValue = game.getSquareArrayEachValue(3, 3);
		assertEquals(EXPECTED_VALUE, actualValue, ERROR_MESSAGE);
	}
	
	@DisplayName("5*5 map has goal at (4, 4)")
	@Test
	public void width4MaphasGoalatRow4Col4() {
		createWidth5Map();
		// Only goal value is set 0
		final int EXPECTED_VALUE = 0;
		final String ERROR_MESSAGE = "0 is expected";
		
		int actualValue = game.getSquareArrayEachValue(4, 4);
		assertEquals(EXPECTED_VALUE, actualValue, ERROR_MESSAGE);
	}
	
// Must 9. Move up correctly
	@DisplayName("Cannot move up when less squares on top")
	@Test
	public void cannotMoveUpWhenLessSquaresOnTop() {
		createTestMapWidth5();
		// expected to stay at 3[0,0]
		game.move(Moves.UP);
		
		final int EXPECTED_CURRENT_ROW = 0;
		final int EXPECTED_CURRENT_COL = 0;
		final String ERROR_MESSAGE1 = "0 is expected";
		final String ERROR_MESSAGE2 = "0 is expected";
		
		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
	@DisplayName("Can move up when enough squares on top")
	@Test
	public void canMoveUpWhenEnoughSquaresOnTop() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 2[3,0] first
		game.move(Moves.DOWN);
		// expected move up from 2[3,0] to 4[1,0]
		game.move(Moves.UP);
		
		final int EXPECTED_CURRENT_ROW = 1;
		final int EXPECTED_CURRENT_COL = 0;
		final String ERROR_MESSAGE1 = "1 is expected";
		final String ERROR_MESSAGE2 = "0 is expected";
		
		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);	
	}
	
// Must 10. Move down correctly
	@DisplayName("Cannot move down when less squares below")
	@Test
	public void cannotMoveDownWhenLessSquaresBelow() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 2[3,0] first
		game.move(Moves.DOWN);
		// expected to stay at 2[3,0] 
		game.move(Moves.DOWN);
		
		
		final int EXPECTED_CURRENT_ROW = 3;
		final int EXPECTED_CURRENT_COL = 0;
		final String ERROR_MESSAGE1 = "3 is expected";
		final String ERROR_MESSAGE2 = "0 is expected";
		
		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
	@DisplayName("Can move down when enough squares below")
	@Test
	public void canMoveDownWhenEnoughSquaresBelow() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 4[0,3] first
		game.move(Moves.RIGHT);
		// expected move down from 4[0,3] to 4[4,3]
		game.move(Moves.DOWN);
		
		final int EXPECTED_CURRENT_ROW = 4;
		final int EXPECTED_CURRENT_COL = 3;
		final String ERROR_MESSAGE1 = "4 is expected";
		final String ERROR_MESSAGE2 = "3 is expected";

		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
// Must 11. Move Right correctly
	@DisplayName("Cannot move right when less squares on right")
	@Test
	public void cannotMoveRightWhenLessSquaresOnRight() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 4[0,3] first
		game.move(Moves.RIGHT);
		// expected to stay at 4[0,3] 
		game.move(Moves.RIGHT);
		
		final int EXPECTED_CURRENT_ROW = 0;
		final int EXPECTED_CURRENT_COL = 3;
		final String ERROR_MESSAGE1 = "0 is expected";
		final String ERROR_MESSAGE2 = "3 is expected";
		

		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
	@DisplayName("Can move right when enough squares on right")
	@Test
	public void canMoveRightWhenEnoughSquaresOnRight() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 2[3,0] first
		game.move(Moves.DOWN);
		// expected move down from 2[3,0] to 4[3,2]
		game.move(Moves.RIGHT);
		
		final int EXPECTED_CURRENT_ROW = 3;
		final int EXPECTED_CURRENT_COL = 2;
		final String ERROR_MESSAGE1 = "3 is expected";
		final String ERROR_MESSAGE2 = "2 is expected";

		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
// Must 12. Move Left correctly
	@DisplayName("Cannot move left when less squares on left")
	@Test
	public void cannotMoveLeftWhenLessSquaresOnLeft() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 4[0,3] first
		game.move(Moves.RIGHT);
		// expected to stay at 4[0,3] 
		game.move(Moves.LEFT);
		
		final int EXPECTED_CURRENT_ROW = 0;
		final int EXPECTED_CURRENT_COL = 3;
		final String ERROR_MESSAGE1 = "0 is expected";
		final String ERROR_MESSAGE2 = "3 is expected";

		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
	@DisplayName("Can move left when enough squares on left")
	@Test
	public void canMoveLeftWhenEnoughSquaresOnLeft() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 4[0,3] first
		game.move(Moves.RIGHT);
		// then change the current point from 4[0,3] to 3[4,3] 
		game.move(Moves.DOWN);
		// expected to move left from 3[4,3] to 3[4,0]
		game.move(Moves.LEFT);
		
		final int EXPECTED_CURRENT_ROW = 4;
		final int EXPECTED_CURRENT_COL = 0;
		final String ERROR_MESSAGE1 = "4 is expected";
		final String ERROR_MESSAGE2 = "0 is expected";
	
		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
// Must 13. Undo the latest move
	@DisplayName("Cannot undo when there is no previous move")
	@Test
	public void cannotUndoWhenNoPreviousMove() {
		createTestMapWidth5();
		// expected to stay at 3[0,0]
		game.moveBack();
		
		
		final int EXPECTED_CURRENT_ROW = 0;
		final int EXPECTED_CURRENT_COL = 0;
		final String ERROR_MESSAGE1 = "0 is expected";
		final String ERROR_MESSAGE2 = "0 is expected";
		
		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
	@DisplayName("Can undo when there is previous move")
	@Test
	public void canUndoWhenPreviousMoveExists() {
		createTestMapWidth5();
		// change the current point from 3[0,0] to 4[0,3] first
		game.move(Moves.RIGHT);
		// then change the current point from 4[0,3] to 3[4,3] 
		game.move(Moves.DOWN);
		// expected to go back to 4[0,3]
		game.moveBack();
		
		final int EXPECTED_CURRENT_ROW = 0;
		final int EXPECTED_CURRENT_COL = 3;
		final String ERROR_MESSAGE1 = "0 is expected";
		final String ERROR_MESSAGE2 = "3 is expected";

		int actualCurrentRow = game.currentRow;
		int actualCurrentCol = game.currentCol;
		assertEquals(EXPECTED_CURRENT_ROW, actualCurrentRow, ERROR_MESSAGE1);
		assertEquals(EXPECTED_CURRENT_COL, actualCurrentCol, ERROR_MESSAGE2);
	}
	
// Must 14. Correctly count the moves made
	@DisplayName("Move count is plus one for each move")
	@Test
	public void moveCountPlusOneForEachMove() {
		createTestMapWidth5();
		game.move(Moves.DOWN);
		game.move(Moves.UP);
		game.move(Moves.RIGHT);
		game.move(Moves.UP);
		game.move(Moves.DOWN);
		
		final int EXPECTED_MOVE_COUNT = 5;
		final String ERROR_MESSAGE = "5 is expected";
		
		int actualMoveCount = game.moveCount;
		assertEquals(EXPECTED_MOVE_COUNT, actualMoveCount, ERROR_MESSAGE);
	}
	
// Must 15. Be able to see move history
	@DisplayName("Move history is correct")
	@Test
	public void hasCorrectMoveHistory() {
		createTestMapWidth5();
		game.move(Moves.DOWN);
		game.move(Moves.UP);
		game.move(Moves.RIGHT);
		game.move(Moves.UP);
		game.move(Moves.DOWN);
		
		
		final String EXPECTED_MOVE_HISTORY = "[0,0][3,0][1,0][1,4][0,4][4,4]";
		final String ERROR_MESSAGE = "[0,0][3,0][1,0][1,4][0,4][4,4] is expected";
		String actualMoveHistory = game.showMoveHistory();
		assertEquals(EXPECTED_MOVE_HISTORY, actualMoveHistory, ERROR_MESSAGE);
	}
	
// Must 16. Win when reach the ending point
	@DisplayName("Have winning message when reach the goal at 4*4 map")
	@Test
	public void winningWhenReachTheGoalWidth4Map() {
		createTestMapWidth4();
		game.move(Moves.DOWN);
		
		
		final String EXPECTED_MESSAAGE = "Win";
		final String ERROR_MESSAGE = "Win is expected";
		
		String actualMessage = game.move(Moves.RIGHT);
		assertEquals(EXPECTED_MESSAAGE, actualMessage, ERROR_MESSAGE);	
	}
	
	@DisplayName("Have winning message when reach the goal at 5*5 map")
	@Test
	public void winningWhenReachTheGoalWidth5Map() {
		createTestMapWidth5();
		game.move(Moves.DOWN);
		game.move(Moves.UP);
		game.move(Moves.RIGHT);
		game.move(Moves.UP);
		
		final String EXPECTED_MESSAAGE = "Win";
		final String ERROR_MESSAGE = "Win is expected";
		
		String actualMessage = game.move(Moves.DOWN);
		assertEquals(EXPECTED_MESSAAGE, actualMessage, ERROR_MESSAGE);
	}
	
// Must 17. Reset the map
	@DisplayName("Reset map has move history of [0,0] only")
	@Test
	public void resetMapHasStartingPointOnlyAtMoveHistory() {
		createTestMapWidth5();
		game.move(Moves.DOWN);
		game.move(Moves.UP);
		game.move(Moves.RIGHT);
		game.resetMoveHistory();
		
		final String EXPECTED_MOVE_HISTORY = "[0,0]";
		final String ERROR_MESSAGE = "[0,0] is expected";
		
		String actualMoveHistory = "";
		for(int i=0; i < game.moveHistory.size(); i++) {
			int[] arr = game.moveHistory.get(i);
			actualMoveHistory+="["+arr[0]+","+arr[1]+"]";
		}
		assertEquals(EXPECTED_MOVE_HISTORY, actualMoveHistory, ERROR_MESSAGE);
	}
	
	@DisplayName("Reset map has move count 0")
	@Test
	public void resetMapHasMoveCount0() {
		createTestMapWidth5();
		game.move(Moves.DOWN);
		game.move(Moves.UP);
		game.resetMoveHistory();
		
		final int EXPECTED_MOVE_COUNT = 0;
		final String ERROR_MESSAGE = "0 is expected";
		
		int actualMoveCount = game.moveCount;
		assertEquals(EXPECTED_MOVE_COUNT, actualMoveCount, ERROR_MESSAGE);
	}
	
// Must 18. Increase difficulty in the same size of the map. (Higher move count for the shortest path)	
	@DisplayName("More difficult map has higher shortest path move count on the test 4*4 map")
	@Test
	public void moreDifficultMapHasHigherShortestPathMoveCountOnWidth4Map() {
		// The shortest move count for the testing map is 2
		createTestMapWidth4();
		int previousMapShortestMoveCount = 2;
		game.currentMap.increaseDifficulty();
		int currentShortestMoveCount = game.currentMap.getShortestPathMoveCount();
		
		final boolean EXPECTED = true;
		final String ERROR_MESSAGE = "True is expected";
		
		// check if the more difficult map has shortest move count higher than 2
		boolean actual = currentShortestMoveCount > previousMapShortestMoveCount;
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}
	
	@DisplayName("More difficult map has higher shortest path move count on the test 5*5 map")
	@Test
	public void moreDifficultMapHasHigherShortestPathMoveCountOnWidth5Map() {
		// The shortest move count for the testing map is 2
		createTestMapWidth5();
		int previousMapShortestMoveCount = game.currentMap.getShortestPathMoveCount();
		game.currentMap.increaseDifficulty();
		int currentShortestMoveCount = game.currentMap.getShortestPathMoveCount();
		
		final boolean EXPECTED = true;
		final String ERROR_MESSAGE = "True is expected";
		
		// check if the more difficult map has shortest move count higher than 2
		boolean actual = currentShortestMoveCount > previousMapShortestMoveCount;
		assertEquals(EXPECTED, actual, ERROR_MESSAGE);
	}

}