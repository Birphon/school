package hellowMVC;

public class Greeter {
	protected String name = "stranger";
	public void setName(String setName) {
		this.name = setName;
	};
	public String greet() {
		return "hello " + this.name;
	};
}
