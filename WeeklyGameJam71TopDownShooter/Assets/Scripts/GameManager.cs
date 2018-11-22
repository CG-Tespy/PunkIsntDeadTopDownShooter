using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public Animator anim;
    public AnimatorOverrideController char1;
    public AnimatorOverrideController char2;
    public AnimatorOverrideController char3;
    public AnimatorOverrideController char4;

	void Start () {
		if (manager != this) {
            Destroy(gameObject);
        } else if (manager == null) {
            manager = this;
            DontDestroyOnLoad(manager);
        }
	}
	
	void Update () {
		
	}
}
