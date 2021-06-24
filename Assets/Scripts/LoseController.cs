using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{
    public GameObject sceneManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneManager.GetComponent<SceneController>().LoadGameOverScene();
    }
}
