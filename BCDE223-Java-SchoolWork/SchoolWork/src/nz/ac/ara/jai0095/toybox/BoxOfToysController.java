package nz.ac.ara.jai0095.toybox;

import java.math.BigDecimal;

public class BoxOfToysController {
	private IView view;

	BoxOfToysController(IView theView) {
		this.view = theView;
	}

	public void go() {
		view.start();

		Box box = new Box();

		box.addToy("Teddy", "DARK_GRAY", new BigDecimal("11.99"));
		box.addToy("Pencil", "RED", new BigDecimal("5.50"));
		box.addToy("Teddy", "GREEN", new BigDecimal("111.99"));
		box.addToy("Pencil", "BLACK", new BigDecimal(".30"));

		for (int i = 0; i < box.getToyCount(); i++) {
			view.say(box.getToy(i));
		}
		view.say("");

		for (Toy toy : box.allMyToys) {
			view.say(toy);
		}

		view.stop();
	}
}
