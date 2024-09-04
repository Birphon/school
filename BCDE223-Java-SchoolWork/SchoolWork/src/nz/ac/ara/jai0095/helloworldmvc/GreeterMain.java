package nz.ac.ara.jai0095.helloworldmvc;

public class GreeterMain {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IView view = new ConsoleView();
		GreetingController greetingController = new GreetingController(view);
		greetingController.go();

	}

}
