package com.example.rakkyu2.arraylist;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.Serializable;
import java.util.ArrayList;

public class MyAdapter extends BaseAdapter implements Serializable {
    private ArrayList<Item> items = new ArrayList<>();
    private Item item = new Item();

    @Override
    public int getCount() {
        return items.size();
    }

    @Override
    public Item getItem(int position) {
        return items.get(position);
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        Context context = parent.getContext();

        if(convertView == null) {
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.listview_custom, parent, false);
        }

        ImageView img = (ImageView) convertView.findViewById(R.id.icon);
        TextView subject = (TextView) convertView.findViewById(R.id.subject);
        TextView contents = (TextView) convertView.findViewById(R.id.contents);

        Item item = getItem(position);

        img.setImageDrawable(item.getIcon());
        subject.setText(item.getSubject());
        contents.setText(item.getContents());

        return convertView;
    }

    public void addItem(Drawable img, String subject, String contents) {

        item.setIcon(img);
        item.setSubject(subject);
        item.setContents(contents);

        items.add(item);
    }
}
