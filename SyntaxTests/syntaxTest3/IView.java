package syntaxTest3;

public interface IView {
	public String get(String prompt);

	public String get();

	public <T> void say(T message);
	
	public <T> void add(T message);

	public void start();

	public void stop();
}
