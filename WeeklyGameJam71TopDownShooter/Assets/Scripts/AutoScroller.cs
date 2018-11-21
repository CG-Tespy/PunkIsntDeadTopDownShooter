using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour {

    public float speed = 3;

    void FixedUpdate() {
        transform.position -= new Vector3(0, speed / 100, -0.01f);
    }
}
