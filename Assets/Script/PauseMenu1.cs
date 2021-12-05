using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu1 : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject a;
    public AudioSource audioSource;
    public string namaScene;

    public void BackToMenu()
    {
        Scene sceneIni = SceneManager.GetActiveScene();

        if (sceneIni.name != namaScene)
        {
            SceneManager.LoadScene(namaScene);
            Resume();
        }

    }

    public void Resume(){
        a.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        audioSource.Play();
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
        audioSource.Stop();
    }


    }
