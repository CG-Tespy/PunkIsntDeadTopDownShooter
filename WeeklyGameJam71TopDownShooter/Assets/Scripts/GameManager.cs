using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour {

    public static GameManager manager;
    public int character;

	void Start () {

        // Singleton
		if (manager != this) {
            Destroy(gameObject);
        } else if (manager == null) {
            manager = this;
            DontDestroyOnLoad(manager);
        }


	}
	
    public void SetCharacter(string c) {
        character = int.Parse(c);
    }
}
