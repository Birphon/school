package syntaxTest3;

import java.lang.reflect.Array;

public class ReverseArray {

	public void reverse (int[] intArray) {
        int tempValue;
		for(int i = 0; i< intArray.length/2; i++){
			tempValue = intArray[i];
			intArray[i] = intArray[intArray.length-(i+1)];
			intArray[intArray.length-(i+1)] = tempValue;
        }
	}
}
