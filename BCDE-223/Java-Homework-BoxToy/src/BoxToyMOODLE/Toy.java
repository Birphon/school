package BoxToyMOODLE;

import java.math.BigDecimal;

public class Toy {
	protected String name;
	protected String color;
	protected BigDecimal cost;
	
	public Toy(String name, String color, BigDecimal cost) {
		this.name = name;
		this.color = color;
		this.cost = cost;
	}
	public void setCost(BigDecimal cost) {
		this.cost = cost;
	}
	public String toString() {
		return String.format("%s (%s) @ $%s", this.name, this.color, this.cost.toPlainString());
	}
}
