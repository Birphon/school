package calculatorTest;

public class Calculator {
	
	public int sum(int start, int stop) {
		int total = 0;
		for (int n = start; n <= stop; n++) {
			total += n;
		}
		return total;		
	}

}
