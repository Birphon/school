package rookjumping;
import java.util.ArrayList;

public class PathNode {
	protected PathNode parent;
	protected int value;
	protected int moveCount = 0;
	protected int[] position = new int[2];
	protected ArrayList<PathNode> nextNodes = new ArrayList<PathNode>();
	
	@Override
	public String toString() {
		String result = value + "["+position[0]+","+position[1]+"]"+"(Move Count: "+moveCount+")  ";
		return result;
	}
}
