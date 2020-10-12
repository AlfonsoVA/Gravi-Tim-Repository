using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{
    public void ShowDemo(){
        SceneManager.LoadScene("DemoScene");
    }    

    public void ShowInfo(){
        SceneManager.LoadScene("AboutScene");
    }

    public void ShowControls(){
        SceneManager.LoadScene("ControlScene");
    }

    public void ShowMenu(){
        SceneManager.LoadScene("TitleScene");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
