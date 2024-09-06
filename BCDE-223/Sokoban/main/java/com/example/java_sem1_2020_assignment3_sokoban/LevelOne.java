package com.example.java_sem1_2020_assignment3_sokoban;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.ImageView;

import java.io.Serializable;

public class LevelOne extends AppCompatActivity implements Serializable {

    Button home;
    FrameLayout gameContainer;
    int width;
    int height;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_level_one);

        home = findViewById(R.id.button_Home);
        home.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                home();
            }
        });

        gameDisplay();
    }

    public void home(){
        Intent intent = new Intent(this, Main_Menu.class);
        startActivity(intent);
    }

    protected int[][] stringBreak(String levelMap){
        String[] splitArray = levelMap.split("\n");
        width = splitArray[0].length();
        height = splitArray.length;
        int[][] tileIdArray = new int[width][height];
        for(int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                tileIdArray[x][y] = getTile(splitArray[x].charAt(y));
            }
        }
        return tileIdArray;
    }

    public void gameDisplay(){
        gameContainer = findViewById(R.id.gameFrame);
        
    }

    public int getTile(char map){
        int t = R.drawable.tile_floor;
        switch (map) {
            case '+':
                t = R.drawable.tile_goal;
                break;
            case '#':
                t = R.drawable.tile_wall;
                break;
            case 'x':
                t = R.drawable.tile_crate;
                break;
            case 'X':
                t = R.drawable.tile_crate_on_goal;
                break;
            case 'w':
                t = R.drawable.tile_player;
                break;
            case 'W':
                t = R.drawable.tile_player_on_goal;
                break;
        }
        return t;
    }
}

