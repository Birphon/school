package syntaxTest3;

public abstract class ExerciseController {
	
	protected IView myView;
	public ExerciseController( IView theView ){
		this.myView = theView;
	}
	
	 abstract protected void doStuff();
	 
	 public void go() {
		this.myView.start();
	 	this.doStuff();
	 	this.myView.stop();
	 }
}

