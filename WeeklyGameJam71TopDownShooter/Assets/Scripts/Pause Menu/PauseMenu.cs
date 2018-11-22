using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public AudioSource audio;
    public AudioClip clip;



    private bool pausable = true;

    void Start() {
        pauseMenu.SetActive(false);
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy && pausable) {
            PauseGame();
            pausable = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy && pausable) {
            ContinueGame();
            pausable = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
            pausable = true;
	}

    public void PauseGame() {

        // Prevent player shooting
        pauseMenu.SetActive(true);
        audio.PlayOneShot(clip);
        Time.timeScale = 0.0f;
    }

    public void ContinueGame() {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void QuitToMenu() {
        ContinueGame();
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }
}
