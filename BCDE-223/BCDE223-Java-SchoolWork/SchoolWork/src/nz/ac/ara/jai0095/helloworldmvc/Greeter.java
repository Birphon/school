package nz.ac.ara.jai0095.helloworldmvc;

public class Greeter {
	protected String name = "unknown";
	protected String greeting = "Hello";
	protected int greetingCount = 0;

	public void setName(String newName) {
		this.name = newName;
	}

	public int getCount() {
		return this.greetingCount;
	}

	public String greet() {
		this.greetingCount++;
		return this.greeting + " " + this.name;

	}
}