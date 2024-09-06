package nz.ac.ara.jai0095.toybox;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class Box {
	List<Toy> allMyToys = new ArrayList<>();

	public void addToy(String name, String color, BigDecimal cost) {
		Toy toy = new Toy(name, color, cost);
		// this.allMyToys.add(toy);
		allMyToys.add(toy);
	}

	public int getToyCount() {
		return this.allMyToys.size();
	}

	public Toy getToy(int index) {
		return this.allMyToys.get(index);
	}
}