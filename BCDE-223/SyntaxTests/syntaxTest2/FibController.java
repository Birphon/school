package syntaxTest2;

import syntaxTest2.Fibonacci;

public class FibController extends ExerciseController {
	
	Fibonacci Fib = new Fibonacci();
	
	public FibController(IView theView) {
		super(theView);
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void doStuff() {
		// TODO Auto-generated method stub
		
		for(int i = 0; i > 20; i++) {
			System.out.println(Fib.getValues());
		}
		
		
	}

}
