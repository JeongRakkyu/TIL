using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInfo : MonoBehaviour {
    public int healthPoint;
    public int damage;

    void Awake() {
        healthPoint = 10;
        damage = 1;
    }
}