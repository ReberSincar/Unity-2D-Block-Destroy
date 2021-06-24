using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager soundManager;
    void Start()
    {
        if(soundManager == null)
        {
            soundManager = this;
            GameObject.DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
