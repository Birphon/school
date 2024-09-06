package homeworkExercises;
//package homeworkExercises;

import java.util.ArrayList; 

public class Homework {

	private static int number; //This is so I can just use "number = X" in my code instead of always saying "int number = X"
	private static int squareNumber; //Used in the SumOfSquares task
	private static int start; //Helpfully in exercises like Ex.4 where I can have this as the first number
	private static int end; //Helpfully in exercises like Ex.4 where I can have this as the end number
	private static int sum; //Use in exercises like Ex.4 when the Sum is needed both as a display and a calculation in the Avgerage
	private static String Output; //Same reason as Number
	private static String OutputTest; //Used for testing reasons
	private static float Avg; //used to call the calculation of Avg 
	private static ArrayList<Integer> arry = new ArrayList<Integer>(); //Used in Averages calculation for the .size() 
	
	public static String Testing() { //This here is a way for me to test my different outputs, helps to check if arrays are working nicely
		return OutputTest;
	}
	
	private static float getAvg() { //This is used in many of the homework tasks so I made it its own thing and call it when need be
		float fSum = sum;
		Avg = fSum/arry.size();
		return Avg;
	}
	
	public static String CheckMark() { //Simple If Else statement to check if its above or equal to 50 or not
		number = 90;
		
		if(number >= 50) {
			Output = "PASS";
		} else {
			Output = "FAIL";
		}
		
		return Output;
		
	}

	public static String CheckNumber() { //Simple If Else statement (number%2)==0 is the way to check if its even
		number = 6438756;
		if((number%2) == 0) {
			Output = "Even Number";
		} else {
			Output = "Odd Number";
		}
		
		return Output;
		
	}
	
	public static String PrintWord() { //Simple Switch Case - I find switch cases annoying because there is no way to make it >=X i.e. if I have 11 in the switch case below nothing will happen cause there is no output for 11
		number = 8;
		switch (number) {
		case 1:
			Output = ("ONE");
			break;
		case 2:
			Output = ("TWO");
			break;
		case 3:
			Output = ("THREE");
			break;
		
		case 4:
			Output = ("FOUR");
			break;
		
		case 5:
			Output = ("FIVE");
			break;
		
		case 6:
			Output = ("SIX");
			break;
		
		case 7:
			Output = ("SEVEN");
			break;
		
		case 8:
			Output = ("EIGHT");
			break;
		
		case 9:
			Output = ("NINE");
			break;
			
		case 10:
			Output = ("OTHER");
			break;
		}
		
		return Output;
	}
	
	public static String SumAndAverage() { //Populates array and gets a sum. Turns Sum and Avg into strings for easier output.
		
		start = 1;
		end = 101;
		
		for(int i = start; i < end; i++)
		{
			arry.add(i);
			sum += i;
		}
		
		String Sum = String.valueOf(sum);
		String Avgs = String.valueOf(getAvg());
		
		Output = "The Sum is " + Sum + " and The Average is " + Avgs;
		//OutputTest = "Test: " + arry;
		
		return Output;
		
	}

	public static String DoWhile() {
		return Output = "This asks for a Do-While loop which is not possible as the WHILE always has to come before the DO";
	}
	
	public static String WhileDo() { //Not working correctly. For some reason the Sum will be 5051 and the average will be 50.00999 - Should work the same as SumAndAverage but doesn't
		sum = 0;
		start = 0;
		end = 100;
		
		do {
			start += sum;
			sum++;
			arry.add(sum);
			
		} while ( start <= end );
		
		String Sum = String.valueOf(sum);
		String Avgs = String.valueOf(getAvg());
		
		Output = "The Sum is " + Sum + " and The Average is " + Avgs;
		
		return Output;
		
	}

	public static String OnlyOdd(){
		start = 1;
		end = 101;
		
		for(int i = start; i < end; i++) {
			if((i%2)==0) {
				break;
			} else {
				arry.add(i);
				sum +=i;
			}
		}
		
		String Sum = String.valueOf(sum);
		String Avgs = String.valueOf(getAvg());
		
		Output = "The Sum is " + Sum + " and the average is " + Avgs;
		//OutputTest = "Test: " + arry;
		
		return Output;
	}

	public static String DivideSevens() {
		start = 1;
		end = 101;
		
		for(int i = start; i < end; i++)
		{
			if ((i%7)==0) {
			arry.add(i);
			sum += i;
			}
		}
		
		String Sum = String.valueOf(sum);
		String Avgs = String.valueOf(getAvg());
		
		Output = "The Sum is " + Sum + " and The Average is " + Avgs;
		//OutputTest = "Test: " + arry;
		
		return Output;
		
	}

	public static String SumOfSquares() {
		start = 1;
		end = 101;
		
		while (start <= 101) {
			squareNumber = (start*start);
			sum += squareNumber;
			arry.add(start);
			start++;
		}
		
		return OutputTest;
	}

	//This marks the end of Questions 1 to 10
	
	//This marks the beginning of Questions 11 to 20
	public static String Product1toN() {
		start = 1;
		end = 11;
		int product = 1;
		
		for (int i = start; i <= end; i++) {
			product *= i;
			arry.add(product);
		}
		
		return null;
		
	}
	
	
}