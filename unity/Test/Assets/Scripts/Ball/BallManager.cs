using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public GameObject NormalBall;
    private GameObject normalBall;

    private bool activeBall = false;
    private Vector3 startTouchedPos;
    private Vector3 endTouchedPos;

    void Awake() {
        normalBall = GameObject.Instantiate(NormalBall, Vector3.zero, Quaternion.identity) as GameObject;
        normalBall.SetActive(false);
    }

    void Update() {
        if (!activeBall) {
            if (Input.GetMouseButtonDown(0)) {
                startTouchedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("위치 : " + startTouchedPos);
            } else if (Input.GetMouseButtonUp(0)) {
                endTouchedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("위치 : " + endTouchedPos);
                ActiveBall();
            }
        }
    }

    Vector2 direcVector;

    void ActiveBall() {
        if (Vector3.Distance(startTouchedPos, endTouchedPos) > 1f) {
            direcVector.x = endTouchedPos.x - startTouchedPos.x;
            direcVector.y = endTouchedPos.y - startTouchedPos.y;

            Debug.Log("direcVec : " + direcVector);
            direcVector.Normalize();
            Debug.Log("direcVec : " + direcVector);

            normalBall.SetActive(true);
            startTouchedPos.z = 0;
            normalBall.transform.position = startTouchedPos;
            normalBall.GetComponent<MoveBall>().SetDirecMoveValue(direcVector);

            activeBall = true;
        } else {
            Debug.Log("생성x");
        }
    }
}