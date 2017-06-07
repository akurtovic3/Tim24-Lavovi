using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovaIgraSkripta : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void NextLevelButton(string levelName)
    {
        //Inišijalajz nova scena
        SceneManager.LoadScene(levelName);
    }
}
