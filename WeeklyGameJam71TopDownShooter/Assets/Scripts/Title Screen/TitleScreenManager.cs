using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {
    [HideInInspector]
    public static TitleScreenManager manager;

    [Header("Positions")]
    public Transform mainMenu;
    public Transform settings;
    public Transform characterSelect;
    [Space]
    public Camera mainCamera;
    public float duration = 1;

	void Awake() {

        // Ensure there can only be one TitleScreenManager
        if (manager == null) {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
            Destroy(gameObject);

        // Prevent autoselect game window to see the game in scene view. QOL remove before deploy
        //#if UNITY_EDITOR
        //    UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        //#endif
    }

    IEnumerator DelayLoadScene(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("StageOne", LoadSceneMode.Single);
    }

    public void LoadMainGame() {
        StartCoroutine(DelayLoadScene(1));
    }

    public void MainMenu() {
        mainCamera.transform.DOMove(mainMenu.position, duration, false);
    }

    public void Settings() {
        mainCamera.transform.DOMove(settings.position, duration, false);
    }

    public void CharacterSelect() {
        mainCamera.transform.DOMove(characterSelect.position, duration, false);
    }

    public void Quit() {
        #if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying == true)
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }
}
