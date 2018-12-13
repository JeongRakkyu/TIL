package com.example.rakkyu2.arraylist;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.RequiresPermission;
import android.support.v4.content.ContextCompat;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class WriteActivity extends MainActivity {

    private MyAdapter adapter2 = super.myAdapter;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_write);

        final EditText editText1 = (EditText)findViewById(R.id.subject);
        final EditText editText2 = (EditText)findViewById(R.id.contents);

        Button button = (Button)findViewById(R.id.button2);

        button.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent2 = new Intent(WriteActivity.this, MainActivity.class);

                adapter2.addItem(editText1.getText().toString() == "html" ? ContextCompat.getDrawable(getApplicationContext(), R.drawable.html) : ContextCompat.getDrawable(getApplicationContext(), R.drawable.javascript),
                        editText1.getText().toString(), editText2.getText().toString());
                startActivity(intent2);
            }
        });
    }
}
