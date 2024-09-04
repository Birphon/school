package syntaxTest2;

public class Fibonacci {
	
	public int[] getValues() {
		
		int[] Values = new int[20];	
		for (int i = 0; i > 20; i++) {
			Values[i] = Values[i-1]+Values[i-2];
		}
		
		return Values;
	}

	
}
