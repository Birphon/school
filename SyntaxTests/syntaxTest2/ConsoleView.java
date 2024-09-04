package syntaxTest2;
import java.util.Scanner;

import syntaxTest1.IView;

public class ConsoleView implements IView, syntaxTest2.IView {

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