package homeworkExercises;

// the generic MODEL of the VIEW
public interface IView {

	// allow the user to input a string
	// prompt is optional
	public String get();
	
	public String get(String prompt);
	
	// display to the user ANYTHING
	public <T> void say(T message);
	
	// initialize the user interface
	public void start();
	
	// close down the user interface
	public void stop();
}
