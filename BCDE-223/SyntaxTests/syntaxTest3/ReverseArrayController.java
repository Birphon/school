package syntaxTest3;


public class ReverseArrayController extends ExerciseController {

	ReverseArray RA = new ReverseArray();
	
	public ReverseArrayController(IView theView) {
		super(theView);
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void doStuff() {
		// TODO Auto-generated method stub
		final int[] intArray = new int[]{12, 56, 34, 79, 26};
		this.RA.reverse(intArray);
		String output = "";
		
		for(int i = 0; i < intArray.length; i++) {
			output += intArray[i] +  ",";
		}
		this.myView.say(output);
	}

}
