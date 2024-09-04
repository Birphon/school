package homeworkExercises;
//package homeworkExercises;
import java.util.Scanner;

public class ConsoleView implements IView {

	Scanner in = new Scanner(System.in);

	@Override
	public String get(String prompt) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String get() {
		// TODO Auto-generated method stub
		return null;
	}

	 @Override
	 public <T> void say(T message) {
	 System.out.println(message + " ");
	 }

	 @Override
	 public void start() {
	 say("STARTING");
	 }
	 
	 @Override
	 public void stop() {
	 say("\nBYE!");
	

	 }
}