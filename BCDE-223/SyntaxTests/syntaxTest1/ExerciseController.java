package syntaxTest1;

public abstract class ExerciseController {
	protected IView myView;
	private String data;
	
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

