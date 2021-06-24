using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int blockCount;
    void Start()
    {
        GetBlockCount();
    }

    // Update is called once per frame
    void Update()
    {
        ControlGameStatus();
    }

    void ControlGameStatus() {
        GetBlockCount();
        if(blockCount == 0)
        {
            GameObject.Find("SceneManager").GetComponent<SceneController>().LoadNextScene();
        }
    }

    void GetBlockCount()
    {
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
    }
}
