package nz.ac.ara.jai0095.toybox;

// <<PART>>
//https://docs.oracle.com/javase/7/docs/api/java/math/BigDecimal.html
import java.math.BigDecimal;

public class Toy {
	private String name;
	private String color;
	private BigDecimal cost;

	public Toy(String name, String color, BigDecimal cost) {
		set(name, color, cost);
	}

	public void set(String newName, String newColor, BigDecimal newCost) {
		this.name = newName;
		this.color = newColor;
		this.cost = newCost;
	}

	@Override
	public String toString() {
		return String.format("%s (%s) @ $%s", this.name, this.color, this.cost.toPlainString());
	}

	// https://dzone.com/articles/java-string-format-examples
	// https://www.javatpoint.com/java-string-format
	// https://docs.oracle.com/javase/7/docs/api/java/lang/String.html#format(java.util.Locale,%20java.lang.String,%20java.lang.Object...)
}