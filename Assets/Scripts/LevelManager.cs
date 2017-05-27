using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Level: " + name);
        Application.LoadLevel(name);
        Brick.breakableCount = 0;
    }
     
    public void QuitRequest()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
        Brick.breakableCount = 0;
    }

    public void BrickDestroyed() {
        if (Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }
}
