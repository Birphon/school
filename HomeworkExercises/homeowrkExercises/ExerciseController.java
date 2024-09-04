package homeworkExercises;

public abstract class ExerciseController {
	protected IView myView;
	private String data;
	
	// the VIEW is injected
	public ExerciseController( IView theView ){
		this.myView = theView;
	}
	
	// must be implemented differently for each exercise
	abstract protected void doStuff();
	
	// general method so can call many exercises
	public void go() {
		this.myView.start();
		this.doStuff();
		this.myView.stop();
	}

}
