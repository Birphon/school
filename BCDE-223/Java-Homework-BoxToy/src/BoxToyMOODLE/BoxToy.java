package BoxToyMOODLE;

import java.math.BigDecimal;

public class BoxToy {

	public static void main(String[] args) {
		// Toy toy = new Toy("Wombat", "Brown", new BigDecimal("11.99"));
		// System.out.println(toy);
		Box box = new Box();
		box.addToy("Wombat", "Brown", new BigDecimal("11.99"));
		box.addToy("Kangaroo", "Brown", new BigDecimal("9999.99"));
		System.out.println(box);

	}

}
