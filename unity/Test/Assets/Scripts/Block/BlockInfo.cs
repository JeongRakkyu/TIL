using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInfo : MonoBehaviour {
    public int healthPoint;
    float xHalfSize;
    float yHalfSize;
    Vector3 thisBlockPos;
    Vector3 tempBallPos;
    Vector3 tempBallScale;
    static float ballRadius = 0.09f;

    void Awake() {
        BoxCollider2D tempCol = gameObject.GetComponent<BoxCollider2D>();
        xHalfSize = transform.localScale.x * (tempCol.size.x*0.05f);
        yHalfSize = transform.localScale.y * (tempCol.size.y*0.05f);
        tempCol = null;
    }


    float shortestDist;
    int shortestSide = 0;
    float tempDist;

    void CheckCollisionSide() {
        shortestDist = Mathf.Abs(tempBallPos.x + (tempBallScale.x * ballRadius) - thisBlockPos.x - xHalfSize);
        shortestSide = 1;

        tempDist = Mathf.Abs(tempBallPos.x - (tempBallScale.x * ballRadius) - thisBlockPos.x * xHalfSize);
        if (shortestDist > tempDist) {
            shortestDist = tempDist;
            shortestSide = 2;
        }

        tempDist = Mathf.Abs(tempBallPos.y - (tempBallScale.y * ballRadius) - thisBlockPos.y + yHalfSize);
        if (shortestDist > tempDist) {
            shortestDist = tempDist;
            shortestSide = 3;
        }

        tempDist = Mathf.Abs(tempBallPos.y + (tempBallScale.y * ballRadius) - thisBlockPos.y - yHalfSize);
        if (shortestDist > tempDist) {
            shortestDist = tempDist;
            shortestSide = 4;
        }
    }

    void GetDamage(int dam) {
        healthPoint -= dam;

        if (healthPoint < 1) {
            healthPoint = 0;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Ball")) {
            Debug.Log("충돌");
            tempBallPos = col.transform.position;
            tempBallScale = col.transform.localScale;

            CheckCollisionSide();

            MoveBall tempMoveBall = col.gameObject.GetComponent<MoveBall>();
            if (!tempMoveBall.frameCollisionCheck) {
                if (shortestSide < 3) {
                    tempMoveBall.TrunTheBall(2);
                } else {
                    tempMoveBall.TrunTheBall(1);
                }

                tempMoveBall.frameCollisionCheck = true;
                tempMoveBall = null;

                //gameObject.SetActive(false);
                GetDamage(col.gameObject.GetComponent<BallInfo>().damage);
            } else {
                tempMoveBall = null;
            }

            shortestSide = 0;
        }
    }

    public void SetBlockInfo() {
        thisBlockPos = transform.position;
    }
}
