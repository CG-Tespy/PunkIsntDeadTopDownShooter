using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public GameObject background;

    private List<GameObject> bgList = new List<GameObject>();
    private float distance;
    private bool spawn = false;

    void Start() {
        distance = background.GetComponent<SpriteRenderer>().bounds.size.y - 0.05f;
        GameObject bg = Instantiate(background, Vector3.zero, Quaternion.identity);
        bgList.Add(bg);
        Spawn();
    }

    void Update() {
        foreach(GameObject bg in bgList) {
            if (bg.transform.position.y < -distance * 1.5) {
                bgList.Remove(bg);
                Destroy(bg);
                break;
            }
        }

        foreach(GameObject bg in bgList) {
            if (bg.transform.position.y > 0) {
                spawn = false;
                break;
            } else {
                spawn = true;
            }
        }

        if (spawn) {
            Spawn();
        }
    }

    private void Spawn() {
        GameObject bg = Instantiate(background, new Vector3(0, distance, 0), Quaternion.identity);
        bgList.Add(bg);
    }
}
