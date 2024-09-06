package com.example.java_sem1_2020_assignment3_sokoban;

public class Empty extends Enterable{

	public Empty(int y, int x) {
		// TODO Auto-generated constructor stub
		super(y, x);
	}

	public String toString() {
		if(onTopObject != null) {
			return onTopObject.toString();
		} else {
			return ".";
		}
	}

	
}



