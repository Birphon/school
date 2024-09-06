package BoxToyFRI;

import java.util.*;
import java.math.*;

public class Toy {

	protected String name;
	protected Colors color;
	protected BigDecimal cost;
	
	public Toy(String name, Colors color, BigDecimal cost) {
		this.name = name;
		this.color = color;
		this.cost = cost;
	}
	public void setCost(BigDecimal cost) {
		this.cost = cost;
	}
	
	public String toString() {
		return "The toy is a " + this.name + 
				", which its color is: " + this.color.toString() + 
				" with a cost of $"	+ this.cost.toPlainString();
	}
}