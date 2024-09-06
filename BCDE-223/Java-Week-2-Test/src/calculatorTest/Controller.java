package calculatorTest;

public class Controller {
	IView view;
	Calculator calculator = new Calculator();

	public Controller( IView theView) {
		this.view = theView;
	}
	
	public void go () {
		view.start();
		int first = 1;
		int last = 3;
		int n = calculator.sum(first, last);
		view.show("sum of " + first + " to " + last + " is " + n );
		view.stop();
	}
	
}
