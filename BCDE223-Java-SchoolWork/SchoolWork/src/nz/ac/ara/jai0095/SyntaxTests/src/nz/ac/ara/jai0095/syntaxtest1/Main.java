package nz.ac.ara.jai0095.syntaxtest1;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
				IView view = new ConsoleView();
				CheckNumberController Controller = new CheckNumberController(view);
				
				Controller.go();

			}

		}
