package com.example.rakkyu2.arraylist;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.ImageView;
import android.widget.TextView;

public class ViewActivity extends AppCompatActivity {
    @Override
    protected void onCreate (Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view);

        Intent intent = new Intent(this.getIntent());
        String [] text = intent.getStringArrayExtra("text");

        ImageView icon = (ImageView)findViewById(R.id.icon);
        icon.setImageResource(R.drawable.html);

        TextView subject = (TextView)findViewById(R.id.subject);
        subject.setText(text[0]);


        TextView contents = (TextView)findViewById(R.id.contents);
        contents.setText(text[1]);
    }
}
