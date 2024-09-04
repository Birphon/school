package homeworkExercises;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IView view = new ConsoleView();
		HomeworkController Controller = new HomeworkController(view);
		
		Controller.go();

	}

}
