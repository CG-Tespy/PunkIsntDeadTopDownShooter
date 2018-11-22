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
            audio.PlayOneShot(clip);
            PauseGame();
            pausable = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy && pausable) {
            audio.PlayOneShot(clip);
            ContinueGame();
            pausable = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
            pausable = true;
	}

    public void PauseGame() {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitToMenu() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }
}
