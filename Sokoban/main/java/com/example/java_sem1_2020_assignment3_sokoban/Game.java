package com.example.java_sem1_2020_assignment3_sokoban;

import java.util.ArrayList;
import java.util.List;

public class Game {

	public List<Level>Levels = new ArrayList<Level>();
	
	private Level currentLevel;
	
	public int getLevelCount() {
		return Levels.size();
	}

	public String getCurrentLevelName() {
		
		String levelName = "";
		
		if (Levels.isEmpty()) {
			levelName = "no levels";
		} else {
			levelName = currentLevel.getName();
		}
		
		return levelName;
	}

	public List<String> getLevelNames() {
		// TODO Auto-generated method stub
		List<String> levelNames = new ArrayList<String>();
		for(Level lvl : Levels) {
			levelNames.add(lvl.getName());
		}
		return levelNames;
	}

	public void addLevel(String name, int height, int width, String level) {
		currentLevel = new Level(name, height, width, level);
		Levels.add(currentLevel);
	}

	public void move(Direction direct) {
		Worker worker = currentLevel.getWorker();
		Point nextTileXY = new Point(worker.pos.x() + direct.getX(), worker.pos.y() + direct.getY());
		Placeable nextTile = currentLevel.getTile(nextTileXY.x(), nextTileXY.y());
		
		Placeable oldTile = currentLevel.getTile(worker.pos.x(), worker.pos.y());
		if(nextTile instanceof Enterable && ((Enterable)nextTile).isEmpty()) {
			((Enterable)oldTile).clearTile();
			((Enterable)nextTile).addWorker(worker);
			worker.pos = nextTileXY;
			currentLevel.incrementMoveCount();
		} 
		else if (nextTile instanceof Enterable && ((Enterable)nextTile).onTopObject instanceof Crate) {
			Placeable nextNextTile = currentLevel.getTile(nextTileXY.x() + direct.getX(), nextTileXY.y() + direct.getY());
			if (nextNextTile instanceof Enterable && ((Enterable)nextNextTile).isEmpty()) {
				((Enterable)oldTile).clearTile();
				((Enterable)nextNextTile).addCrate((Crate)((Enterable)nextTile).onTopObject);
				((Enterable)nextTile).addWorker(worker);
				worker.pos = nextTileXY;
				currentLevel.incrementMoveCount();
			}			
		}
		
	}
	
	public String toString() {
		
		String noLevels = "no levels";
		
		if (!Levels.isEmpty()) {
			noLevels = currentLevel.toString();
		}
		
		return noLevels;
	}
}
