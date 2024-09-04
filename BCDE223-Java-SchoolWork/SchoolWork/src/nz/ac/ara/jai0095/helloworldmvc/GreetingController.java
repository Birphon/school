package nz.ac.ara.jai0095.helloworldmvc;

public class GreetingController {
	IView view;
	Greeter greeter = new Greeter();

	GreetingController(IView theView) {
		this.view = theView;
	}

	public void go() {
		view.start();
		for (int i = 1; i <= 3; i++) {
			String newName = view.get("What is your name?");
			this.greeter.setName(newName);
			String greeting = greeter.greet();
			view.say(greeting);
		}
		int count = greeter.getCount();
		view.say(count);
		view.stop();
	}
}