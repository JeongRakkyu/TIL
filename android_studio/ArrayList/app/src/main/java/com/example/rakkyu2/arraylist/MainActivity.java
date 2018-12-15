package com.example.rakkyu2.arraylist;

import android.content.Intent;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;

public class MainActivity extends AppCompatActivity {

    private ListView listView;
    private MyAdapter myAdapter= new MyAdapter();
    private String subject;
    private String contents;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listView = (ListView)findViewById(R.id.listView);
        listView.setClickable(true);
        Button button = (Button)findViewById(R.id.button);

        button.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, WriteActivity.class);
                startActivity(intent);
            }
        });

        Intent intent2 = new Intent(this.getIntent());
        subject = intent2.getStringExtra("subject");
        contents = intent2.getStringExtra("contents");
        if (subject ==  "html") {
            myAdapter.addItem(ContextCompat.getDrawable(getApplicationContext(), R.drawable.html), subject, contents);
        } else if (subject == "javascript"){
            myAdapter.addItem(ContextCompat.getDrawable(getApplicationContext(), R.drawable.javascript), subject, contents);
        } else {}
        myAdapter.addItem(ContextCompat.getDrawable(getApplicationContext(), R.drawable.html), subject, contents);
        Log.v(String.valueOf(subject == "html"), "subject");

        listView.setAdapter(myAdapter);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String [] text = {subject, contents};

                Intent intent3 = new Intent(MainActivity.this, ViewActivity.class);
                intent3.putExtra("text", text);

                startActivity(intent3);
            }
        });
    }
}
