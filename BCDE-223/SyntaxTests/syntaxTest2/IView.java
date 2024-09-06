package syntaxTest2;

public interface IView {
	public String get(String prompt);

	public String get();

	public <T> void say(T message);

	public void start();

	public void stop();
}