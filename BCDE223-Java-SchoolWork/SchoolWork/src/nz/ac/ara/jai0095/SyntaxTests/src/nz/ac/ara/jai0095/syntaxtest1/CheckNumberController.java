package nz.ac.ara.jai0095.syntaxtest1;

public class CheckNumberController extends ExerciseController {
	
	CheckNumber checkNumber = new CheckNumber();
	
	public CheckNumberController(IView theView) {
		super(theView);
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void doStuff() {
			// TODO Auto-generated method stub
			for (int i = 0 ; i <= 10 ; i++) {
				myView.say(i + " is an " + checkNumber.CheckNumber(i) + " number");
			}
		
		}
		 
}

