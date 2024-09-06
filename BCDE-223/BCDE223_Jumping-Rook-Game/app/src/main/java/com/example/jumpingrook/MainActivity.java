package com.example.jumpingrook;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {
    // This is the main Menu

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void goToLevelOne (View view){
        Intent intent = new Intent (this, level_one.class);
        startActivity(intent);
    }

    public void goToLevelTwo (View view){
        Intent intent = new Intent (this, level_two.class);
        startActivity(intent);
    }
}