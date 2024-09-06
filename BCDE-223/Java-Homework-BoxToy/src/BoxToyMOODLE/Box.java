package BoxToyMOODLE;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class Box {
	protected List<Toy> allMyToys = new ArrayList<Toy>();
	
	public void addToy(String name, String color, BigDecimal cost) {
		Toy toy = new Toy(name, color, cost);
		this.allMyToys.add(toy);
	}
	
	public String toString() {
		String result = "";
		for (Toy toy : this.allMyToys) {
			result += toy + "\n";
		}
		return result;
	}
}
