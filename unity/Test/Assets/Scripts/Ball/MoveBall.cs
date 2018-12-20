using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {
    public Vector2 minPos;
    public Vector2 maxPos;

    private Transform ballTf;
    private Vector3 ballPos;
    private Vector3 moveValue;
    private float moveSpeed = 0.3f;

    public bool frameCollisionCheck = false;

    void Awake() {
        ballTf = transform;
        //ballPos = ballTf.position;
        moveValue = Vector2.one;
    }

    void FixedUpdate() {
        ballPos.x += moveSpeed * moveValue.x;
        ballPos.y += moveSpeed * moveValue.y;

        if (ballPos.x < minPos.x) {
            moveValue.x *= -1;
            ballPos.x += minPos.x - ballPos.x;
        } else if (ballPos.x > maxPos.x) {
            moveValue.x *= -1;
            ballPos.x += maxPos.x - ballPos.x;
        }

        if (ballPos.y < minPos.y) {
            moveValue.y *= -1;
            ballPos.y += minPos.y - ballPos.y;
        } else if (ballPos.y > maxPos.y) {
            moveValue.y *= -1;
            ballPos.y += maxPos.y - ballPos.y;
        }

        ballTf.position = ballPos;

        if (frameCollisionCheck) {
            frameCollisionCheck = false;
        }
    }

    public void TrunTheBall(int type) {
        if (type == 1) {
            moveValue.x *= -1;
        } else if (type == 2) {
            moveValue.y *= -1;
        }
    }

    public void SetDirecMoveValue(Vector2 dir) {
        moveValue.x = dir.x;
        moveValue.y = dir.y;
        ballPos = ballTf.position;
    }
}
