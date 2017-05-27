using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static bool isCreated = false;

    private void Awake()
    {
        if (isCreated)
        {
            Destroy(gameObject);
        }
        else {
            isCreated = true;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
