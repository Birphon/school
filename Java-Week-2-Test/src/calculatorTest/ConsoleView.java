package calculatorTest;

public class ConsoleView implements IView {

	@Override
	public <T> void show(T data) {
		System.out.println(data);
	}

	@Override
	public void start() {
		this.show("STARTING");

	}

	@Override
	public void stop() {
		this.show("STOPPED");

	}

}
