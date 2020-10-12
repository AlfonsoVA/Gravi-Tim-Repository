using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour{
    public GameObject PausePanel;
    public KeyCode pauseKey = KeyCode.P;
    public bool pausedGame;

    void Start(){
        PausePanel.SetActive(false);            
    }
    
    void Update(){
        if(Input.GetKeyDown(pauseKey)){  
            if(pausedGame){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }

    public void Resume(){
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }

    public void ShowMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    public void ExitGame(){
        Application.Quit();
    }
}