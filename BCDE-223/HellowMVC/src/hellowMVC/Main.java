package hellowMVC;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		GreetingController greetingcontroller = new GreetingController(new ConsoleView());
		greetingcontroller.go();
	}

}
