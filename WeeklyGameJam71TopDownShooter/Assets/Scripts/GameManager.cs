using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

	void Start () {
		if (manager != this) {
            Destroy(gameObject);
        } else if (manager == null) {
            manager = this;
            DontDestroyOnLoad(manager);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
