package com.example.java_sem1_2020_assignment3_sokoban;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;


public class Level_Selector extends AppCompatActivity{

    private Context mContext;
    Button levelSelect;
    Button home;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        mContext = this;


        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_level__selector);

        home = findViewById(R.id.button_Home);
        home.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                home();
            }
        });

        levelSelect = findViewById(R.id.levelOneSelect);
        levelSelect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(v.getId() == R.id.levelOneSelect){
                    oneSelect();

                }
                if(v.getId() == R.id.levelTwoSelect){
                    twoSelect();
                }


            }
        });
    }

    public void oneSelect() {
        Intent intent = new Intent(this, LevelOne.class);
        startActivity(intent);
    }

    public void twoSelect() {
        Intent intent = new Intent(this, LevelTwo.class);
        startActivity(intent);
    }

    public void home(){
        Intent intent = new Intent(this, Main_Menu.class);
        startActivity(intent);
    }

}
