package Sokoban;

public class Enterable extends Placeable{

	Placeable onTopObject;
	
	public Enterable(int y, int x) {
		super(y, x);
		// TODO Auto-generated constructor stub
	}
	
	
	public void addWorker(Worker worker) {
		// TODO Auto-generated method stub
		onTopObject = worker;
	}
	
	public void addCrate(Crate crate) {
		// TODO Auto-generated method stub
		onTopObject = crate;
	}
	
	public boolean isEmpty() {
		return onTopObject == null;
	}
	
	public void clearTile() {
		onTopObject = null;
	}
}
