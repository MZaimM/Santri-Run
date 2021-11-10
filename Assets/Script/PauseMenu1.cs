using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu1 : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject a;
    
    public void Resume(){
        a.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
     
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }    
    }

    public void Pause(){
        a.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    
}
