using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    public Button startBtn;
    public Button restartBtn;
    public RawImage gameOverTxt;
    public RawImage youWonTxt;
    public Canvas UICanvas;
    public Canvas PlayerHealthCanvas;
    public Camera mainCam;
    public AudioClip menuClip;
    public AudioClip mainGameplayClip;
	public AudioClip templeMusic;

    

    // Use this for initialization
    void Start () {

        Time.timeScale = 0.0f;                          // freeze game time when you start the game
        UICanvas.GetComponent<Canvas>().enabled = false;
        PlayerHealthCanvas.GetComponent<Canvas>().enabled = false;
        mainCam.GetComponent<AudioSource>().clip = menuClip;
        mainCam.GetComponent<AudioSource>().Play();

    }

    public void StartGame()
    {
        // start the game when the player presses 
        // the start button

        Time.timeScale = 1.0f;                          // unfreeze game time
        GameObject.Find("MenuCanvas").SetActive(false);      // make the menu canvas disappear
        UICanvas.GetComponent<Canvas>().enabled = true;
        PlayerHealthCanvas.GetComponent<Canvas>().enabled = true;
        mainCam.GetComponent<AudioSource>().clip = mainGameplayClip;
        mainCam.GetComponent<AudioSource>().Play();
    }

	public void playTempleMusic(){

		mainCam.GetComponent<AudioSource>().clip = templeMusic;
		mainCam.GetComponent<AudioSource>().Play();
	}

    public void ShowRestart()
    {
        // give player the option to restart the game

        gameOverTxt.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        // give player the option to restart the game

        youWonTxt.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
    }

    public void LoadScene()
    {
        // load the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {

    }
}
