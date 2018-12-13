package com.example.rakkyu2.arraylist;

import android.content.Intent;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

public class MainActivity extends AppCompatActivity {

    private ListView listView;
    protected Item item = new Item();
    protected MyAdapter myAdapter= new MyAdapter();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listView = (ListView)findViewById(R.id.listView);

        Button button = (Button)findViewById(R.id.button);

        button.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View v) {
                /*myAdapter.addItem(ContextCompat.getDrawable(getApplicationContext(), R.drawable.html), item.getSubject(), item.getContents());
                listView.setAdapter((myAdapter));*/

                Intent intent = new Intent(MainActivity.this, WriteActivity.class);
                startActivity(intent);
            }
        });

        listView.setAdapter(myAdapter);
    }
}
