package rookjumping;
import java.util.ArrayList;
import java.util.Random;

public class Map {
	private String name;
	private int width;
	private int[][] squareArray;
	private int shortestPathIndex;
	private int iterationNum = 0;
	private int preShortestPathCount = 0;
	private int newShortestPathCount = 0;
	private ArrayList<PathNode> SolvableNodes = new ArrayList<PathNode>();
	
	protected Map(String name, int width) {
		this.name = name;
		this.width = width;
		createMap();
	}
	
	protected String getName() {
		return name;
	}
	
	protected int getWidth() {
		return width;
	}
	
	protected ArrayList<PathNode> getSolvableNodes() {
		return SolvableNodes;
	}

	protected int[][] getSquareArray() {
		return squareArray;
	}
	
	protected void setSquareArray(int[][] squareArray) {
		this.squareArray = squareArray;
	}

	protected int getIterationNum() {
		return iterationNum;
	}

	protected int getShortestPathMoveCount() {
		return SolvableNodes.get(shortestPathIndex).moveCount;
	}
	
	protected String printShortestPathMove() {
		return printPathNode(SolvableNodes.get(shortestPathIndex));
	}
	
	private void createMap() {
		// generate squares
		squareArray = new int[width][width];
		for(int i = 0;i < width; i++)
        {
            for(int j = 0; j < width; j++)
            {	
            	// put random numbers in each square of the maze
            	Random rand = new Random();
            	int low = 1;
            	int high = width;
            	int squareValue = rand.nextInt(high-low) + low;
            	squareArray[i][j] = squareValue;
            }
        }
		
		// Set the goal
		squareArray[width-1][width-1] = 0;
		iterationNum += 1;
		
		breadthFirstSearch();
		if(shortestPathIndex == -1) {
			createMap();
		}
	}
	
		
	protected void increaseDifficulty() {
		preShortestPathCount =  getShortestPathMoveCount();
		createMap();
		newShortestPathCount = getShortestPathMoveCount();
		
		while (newShortestPathCount <= preShortestPathCount) {
			createMap();
			newShortestPathCount = getShortestPathMoveCount();
		} 
	}
	
	protected void breadthFirstSearch()
	{
		SolvableNodes.clear();
		// start number
		int startNum = squareArray[0][0];
		PathNode n = new PathNode();
		n.value = startNum;
		n.position[0] = 0;
		n.position[1] = 0;
		
		moveForBFS(n, 0, 0);
		
		shortestPathIndex = -1;
		int shortestCount = Integer.MAX_VALUE;
		
		for(int i = 0; i <SolvableNodes.size(); i++){
			PathNode node = SolvableNodes.get(i);
			if(shortestCount > node.moveCount)
			{
				shortestCount = node.moveCount;
				shortestPathIndex = i;
			}
		}
	}
	
	
	private void moveForBFS(PathNode node, int posX, int posY)
	{
		// check if it is the goal
		if(node.position[0] == width-1 && node.position[1] == width-1) {
			SolvableNodes.add(node);
			return;
		}
		// As the Goal set to 0 in the map
		if(node.value == 0) {
			return;
		}
		// checks if it is visited
		PathNode p = node.parent;
		while(p != null) {
			if(p.position[0] == node.position[0] && p.position[1] == node.position[1]) {
				return;
			} else {
				p = p.parent;
			}
		}

		int plusX = posX + node.value;
		int plusY = posY + node.value;
		int minusX = posX - node.value;
		int minusY = posY - node.value;
		
		if(plusX < width) {
			PathNode next = new PathNode();
			next.value = squareArray[plusX][posY];
			next.position[0] = plusX;
			next.position[1] = posY;
			next.parent = node;
			next.moveCount = node.moveCount+1;
			node.nextNodes.add(next);
			moveForBFS(next, plusX, posY);
		}
		if(minusX >= 0) {
			PathNode next = new PathNode();
			next.value = squareArray[minusX][posY];
			next.position[0] = minusX;
			next.position[1] = posY;
			next.parent = node;
			next.moveCount = node.moveCount+1;
			node.nextNodes.add(next);
			moveForBFS(next, minusX, posY);
		}
		if(plusY < width) {
			PathNode next = new PathNode();
			next.value = squareArray[posX][plusY];
			next.position[0] = posX;
			next.position[1] = plusY;
			next.parent = node;
			next.moveCount = node.moveCount+1;
			node.nextNodes.add(next);
			moveForBFS(next, posX, plusY);
		}
		if(minusY >= 0) {
			PathNode next = new PathNode();
			next.value = squareArray[posX][minusY];
			next.position[0] = posX;
			next.position[1] = minusY;
			next.parent = node;
			next.moveCount = node.moveCount+1;
			node.nextNodes.add(next);
			moveForBFS(next, posX, minusY);
		}
	}
	
	private String printPathNode(PathNode n)
	{
		String result = "";
		PathNode p = n.parent;
		result += n;
		while(p != null) {
			result += p;
			p = p.parent;
		}
		return result;
	}			
}
