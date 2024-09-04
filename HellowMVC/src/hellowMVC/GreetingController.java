package hellowMVC;

public class GreetingController {
	IView view;
	Greeter greeter = new Greeter();
	
	public GreetingController(IView newView){
		this.view = newView;
	}
	
	public void go() {
		this.view.say("ping");
	}
}
