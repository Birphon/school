package com.example.java_sem1_2020_assignment3_sokoban;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class Main_Menu extends AppCompatActivity {

    Button startButton;
    Button levelSelect;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main__menu);

        startButton = findViewById(R.id.button_start);
        startButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                startGame();
            }
        });

        levelSelect = findViewById(R.id.button_LevelSelect);
        levelSelect.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                selectLevel();
            }
        });
    }

    public void startGame() {
        Intent intent = new Intent(this, LevelOne.class);
        startActivity(intent);
    }

    public void selectLevel() {
        Intent intent = new Intent(this, Level_Selector.class);
        startActivity(intent);
    }
}
