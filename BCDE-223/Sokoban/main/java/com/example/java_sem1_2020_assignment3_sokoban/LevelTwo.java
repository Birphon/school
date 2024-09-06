package com.example.java_sem1_2020_assignment3_sokoban;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import java.io.Serializable;

public class LevelTwo extends AppCompatActivity implements Serializable {

    Button home;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_level_two);

        home = findViewById(R.id.button_Home);
        home.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                home();
            }
        });
    }

    public void home(){
        Intent intent = new Intent(this, Main_Menu.class);
        startActivity(intent);
    }
}
