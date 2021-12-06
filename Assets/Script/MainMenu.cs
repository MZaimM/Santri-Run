using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public string namaScene;
    // Start is called before the first frame update
    public void PlayGame(){
        Scene sceneIni = SceneManager.GetActiveScene();
        
        if(sceneIni.name != namaScene)
        {
            SceneManager.LoadScene(namaScene);
        }
       
   }
   public void ContinueGame(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
       
   }

   public void QuitGame(){
       Debug.Log("Quit!"); 
       Application.Quit();
   }
}
