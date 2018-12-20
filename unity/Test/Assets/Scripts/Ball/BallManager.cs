using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public GameObject NormalBall;
    public GameObject EmptyNormalBall;
    private GameObject normalBall;
    private GameObject emptyNormalBall;

    private bool activeBall = false;
    private Vector3 startTouchedPos;
    private Vector3 endTouchedPos;

    void Awake() {
        normalBall = GameObject.Instantiate(NormalBall, Vector3.zero, Quaternion.identity) as GameObject;
        normalBall.SetActive(false);
        emptyNormalBall = GameObject.Instantiate(EmptyNormalBall, Vector3.zero, Quaternion.identity) as GameObject;
        emptyNormalBall.SetActive(false);

    }

    void Update() {
        if (!activeBall) {
            if (Input.GetMouseButtonDown(0)) {
                startTouchedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                startTouchedPos.z = 0;
                emptyNormalBall.SetActive(true);
                emptyNormalBall.transform.position = startTouchedPos;
                Debug.Log("위치 : " + startTouchedPos);
            } else if (Input.GetMouseButtonUp(0)) {
                endTouchedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                endTouchedPos.z = 0;
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
            //startTouchedPos.z = 0;
            normalBall.transform.position = startTouchedPos;
            normalBall.GetComponent<MoveBall>().SetDirecMoveValue(direcVector);

            activeBall = true;
        } else {
            Debug.Log("생성x");
        }
        emptyNormalBall.SetActive(false);
    }
}