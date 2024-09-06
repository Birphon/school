package hellowMVC;

public class ConsoleView implements IView {

	@Override
	public <T> void say(T msg) {
		// TODO Auto-generated method stub
		System.out.println(msg);
	}

}
