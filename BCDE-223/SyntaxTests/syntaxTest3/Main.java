package syntaxTest3;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IView view = new ConsoleView();
		 
		ExerciseController ec = new ReverseArrayController( view );
	 
		ec.go();
	}

}
