package syntaxTest1;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IView view = new ConsoleView();
		checkNumberController Controller = new checkNumberController(view);
		
		Controller.go();

	}

}
