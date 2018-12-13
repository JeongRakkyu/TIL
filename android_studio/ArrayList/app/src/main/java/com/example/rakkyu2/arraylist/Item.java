package com.example.rakkyu2.arraylist;

import android.graphics.drawable.Drawable;

public class Item {

    private Drawable icon;
    private String subject;
    private String contents;

    public Drawable getIcon() {
        return icon;
    }
    public void setIcon(Drawable icon) {
        this.icon = icon;
    }

    public String getSubject() {
        return subject;
    }
    public void setSubject(String subject) {
        this.subject = subject;
    }

    public String getContents() {
        return contents;
    }
    public void setContents(String contents) {
        this.contents = contents;
    }
}
