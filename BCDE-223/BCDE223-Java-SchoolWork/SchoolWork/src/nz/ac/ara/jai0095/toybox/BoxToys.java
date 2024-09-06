package nz.ac.ara.jai0095.toybox;

public class BoxToys {
	public static void main(String[] args) {
		IView view = new ConsoleView();
		BoxOfToysController boxOfToysController = new BoxOfToysController(view);
		boxOfToysController.go();
	}
}
