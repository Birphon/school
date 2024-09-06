package syntaxTest1;

public class checkNumberController extends ExerciseController {

	checkNumber CheckNumber = new checkNumber();
	
	public checkNumberController(IView theView) {
		super(theView);
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void doStuff() {
		// TODO Auto-generated method stub
		
		for (int i = 0; i < 10; i++) {
			myView.say(i + " is an " + CheckNumber.CheckNumber(i) + " number");
		}
		
	}

}
