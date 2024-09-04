package com.example.painandsuffering.model_code;
import java.util.ArrayList;
import java.util.List;

public class Game {
	protected List<Map> allMyMaps = new ArrayList<>();
	protected ArrayList<Integer> squareArrayValues = new ArrayList<Integer>();
	protected ArrayList<int[]> moveHistory = new ArrayList<int[]>();
	protected int[] latestMoveHistory;
	protected int[] previousMoveHistory;
	protected int moveValue;
	protected int currentRow;
	protected int currentCol;
	protected int moveCount = 0;
	protected Map currentMap;
	
	public String getMapName() {
		if (currentMap == null)
            return "No maps loaded";
        else
            return currentMap.getName();
	}

	public int getMapWidth() {
		if (currentMap == null)
            return 0;
        else
            return currentMap.getWidth(); 
	}
	
	public void addMap(String name, int width) {
		Map aMap = new Map(name, width);
		allMyMaps.add(aMap);
		currentMap = aMap;
		
		// When level is added set the start point to {0,0}
		moveHistory.add(new int[] {0,0});
	}
	
	// get the values of squares
	public ArrayList<Integer> getSquareArrayValues() {
		if (currentMap == null)
			return null;
		else
			for(int i = 0;i < currentMap.getWidth(); i++)
	        {
	            for(int j = 0; j < currentMap.getWidth(); j++)
	            {	
	            	int value = currentMap.getSquareArray()[i][j];
	            	squareArrayValues.add(value);
	            	
	            }
	        }
			return squareArrayValues;
	}
	
	public int getSquareArrayEachValue(int row, int col) {
		int value = currentMap.getSquareArray()[row][col];
		return value;
	}
	
	public void resetMoveHistory() {
		if (moveHistory != null) 
			moveHistory.clear();
		
		moveHistory.add(new int[] {0,0});
		moveCount = 0;
	}
	
	public String getStartPoint() {
		int row = moveHistory.get(0)[0];
		int col = moveHistory.get(0)[1];
		String startPoint = "[" + row + "," + col + "]";
		return startPoint;
	}
	
	public String move(Moves moves) {
		if (moveHistory != null) 
			latestMoveHistory = moveHistory.get(moveHistory.size()-1);
			currentRow = latestMoveHistory[0];
			currentCol = latestMoveHistory[1];
			moveValue = currentMap.getSquareArray()[currentRow][currentCol];
			
			if (moves == Moves.UP && currentRow - moveValue >= 0) {
				currentRow -= moveValue;
				moveHistory.add(new int[] {currentRow, currentCol});
				moveCount++;
				if(currentRow == currentMap.getWidth()-1 && currentCol == currentMap.getWidth()-1) {
					return "Win";
				}else {
					return "Move successfully made";
				}
			}

			if (moves == Moves.DOWN && currentRow + moveValue < currentMap.getWidth()) {
				currentRow += moveValue;
				moveHistory.add(new int[] {currentRow, currentCol});
				moveCount++;
				if(currentRow == currentMap.getWidth()-1 && currentCol == currentMap.getWidth()-1) {
					return "Win";
				}else {
					return "Move successfully made";
				}
			}
			if (moves == Moves.RIGHT && currentCol + moveValue < currentMap.getWidth()) {
				currentCol += moveValue;
				moveHistory.add(new int[] {currentRow, currentCol});
				moveCount++;
				if(currentRow == currentMap.getWidth()-1 && currentCol == currentMap.getWidth()-1) {
					return "Win";
				}else {
					return "Move successfully made";
				}
			} 
					
				
			if (moves == Moves.LEFT && currentCol - moveValue >= 0) {
				currentCol -= moveValue;
				moveHistory.add(new int[] {currentRow, currentCol});
				moveCount++;
				if(currentRow == currentMap.getWidth()-1 && currentCol == currentMap.getWidth()-1) {
					return "Win";
				}else {
					return "Move successfully made";
				}
			}
			
			return "Move failed";
	}
	
	public void moveBack() {
		if (moveHistory.size() >= 2) {
			previousMoveHistory = moveHistory.get(moveHistory.size()-2);
			latestMoveHistory[0] = previousMoveHistory[0];
			latestMoveHistory[1] = previousMoveHistory[1];
			currentRow = latestMoveHistory[0];
			currentCol = latestMoveHistory[1];
			
			// Calculate index of last element and delete the last history
	        int index = moveHistory.size() - 1;
			moveHistory.remove(index);
			moveCount-- ;
		}
	}
	
	public String showMoveHistory() {
		String showMoveHistory = "";
		for(int i=0; i < moveHistory.size(); i++) {
			int[] arr = moveHistory.get(i);
			showMoveHistory +="["+arr[0]+","+arr[1]+"]";
		}
		
		return showMoveHistory;
	}
}
	
	