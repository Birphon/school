package nz.ac.ara.jai0095.toybox;

public interface IView {
	public String get(String prompt);

	public String get();

	public <T> void say(T message);

	public void start();

	public void stop();
}
