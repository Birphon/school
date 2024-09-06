package com.example.jumpingrook;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.TextView;

public class level_one extends AppCompatActivity {

    protected boolean isRunning;
    TextView timerViewL1;
    boolean timerStart = false;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_level_one);

        timerViewL1 = (TextView) findViewById(R.id.timerViewL1);
    }
}