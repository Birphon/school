package com.example.java_sem1_2020_assignment3_sokoban;

public enum Direction {
	LEFT(-1, 0),
	RIGHT(1 , 0),
	UP(0, -1),
	DOWN(0, 1)
	;
	
	private int x;
	private int y;
	
	Direction(int dirX, int dirY){
		x = dirX;
		y = dirY;				
	}
	
	public int getX() {
		return x;
	}
	
	public int getY() {
		return y;
	}
}


