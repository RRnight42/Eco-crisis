using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour
{

    public int lvl;
  
    public void ShowStagePoints()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }

  
    public void StartBoss()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }
    public void Credits()
    {
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Single);
    }

    public void CreditsEnd()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
  public void ContinueLevel()
    {

        if (lvl == 4)
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        }
       

       
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
