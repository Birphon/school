package nz.ac.ara.jai0095.helloworldmvc;
// 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
import java.util.Scanner;

public class ConsoleView implements IView {
	Scanner in = new Scanner(System.in);

	@Override
	public String get(String prompt) {
		this.say(prompt);
		String input;
		input = in.nextLine();
		return input;
	}

	@Override
	public String get() {
		return this.get("> ");
	}

	@Override
	public <T> void say(T message) {
		System.out.println(message);

	}

	@Override
	public void start() {
		this.say("STARTING");

	}

	@Override
	public void stop() {
		this.say("STOPPED");

	}

}
