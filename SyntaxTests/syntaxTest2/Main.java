package syntaxTest2;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IView view = new ConsoleView();
	 
		ExerciseController ec = new FibController( view );
	 
		ec.go();
	 }
}