using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    public GameObject NormalBlock;

    //private GameObject[] normalBlocks;
    private int normalBlockNum = 20;

    private Vector3 nBlockCenterTopPos;
    private Vector3 nBlockSize;

    struct Block {
        public GameObject obj;
        public BlockInfo info;
    };
    private Block[] normalBlocks;

    void Awake() {
        Transform tempTf = GameObject.Find("NormalBlockCenterTop").transform;
        nBlockCenterTopPos = tempTf.position;
        nBlockSize = tempTf.GetComponent<BoxCollider2D>().size;
        nBlockSize.x *= tempTf.localScale.x;
        nBlockSize.y *= tempTf.localScale.y;
        nBlockSize.z = 1;

        CreateNormalBlock();

        TempMapSetting();
    }

    void CreateNormalBlock() {
        normalBlocks = new Block[normalBlockNum];

        for (int i = 0; i < normalBlockNum; i ++) {
            normalBlocks[i].obj = GameObject.Instantiate(NormalBlock, Vector3.zero, Quaternion.identity) as GameObject;
            normalBlocks[i].info = normalBlocks[i].obj.GetComponent<BlockInfo>();
            normalBlocks[i].obj.SetActive(false);
        }
    }

    void SetNormalBlock(Vector3 pos) {
        for (int i = 0; i < normalBlockNum; i ++) {
            if (!normalBlocks[i].obj.activeSelf) {
                normalBlocks[i].obj.SetActive(true);
                normalBlocks[i].obj.transform.position = pos;
                normalBlocks[i].info.SetBlockInfo();
                break;
            }
        }
    }

    void TempMapSetting() {
        Vector3 tempVec;

        for (int i = 0; i < 4; i ++) {
            for (int j = -2; j < 3; j ++) {
                tempVec = nBlockCenterTopPos;
                tempVec.x += j * nBlockSize.x;
                tempVec.y -= i * nBlockSize.y;
                
                SetNormalBlock(tempVec);
            }
        }
    }
}