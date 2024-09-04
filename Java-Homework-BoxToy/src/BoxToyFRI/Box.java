package BoxToyFRI;

import java.util.*;
import java.math.*;
public class Box {
	
	List<Toy> allMyToys = new ArrayList<Toy>();
	
	public void addToy(String name, Colors color, BigDecimal cost) {
		Toy toy = new Toy(name,color,cost);
		this.allMyToys.add(toy);
	}
	
	@Override
	public String toString() {
		String result = "";
		for (Toy toy : this.allMyToys) {
			result += toy + "\n";
		}
		return result;
	}
}
