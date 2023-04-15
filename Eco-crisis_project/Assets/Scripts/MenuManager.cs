using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    int lvl;
    GameObject btn_continue;
    public float deleteTime = 0;
    float completed = 7;
    public TMP_Text continue_levelint;
    public Button continueLvl;
    public Image delImage;
    void Start()
    {

        btn_continue = GameObject.FindGameObjectWithTag("Continue");
        btn_continue.gameObject.SetActive(false);

        if (lvl > 0)
        {
            btn_continue.gameObject.SetActive(true);
        }

        StartCoroutine(DeleteData());

        if (PlayerPrefs.HasKey("LevelSaved"))
        {
            continue_levelint.text = "Continue   " + "Level ( " + PlayerPrefs.GetInt("CurrentLevel") + " )";
            continueLvl.gameObject.SetActive(true);
        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Delete))
        {

            deleteTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Delete))
        {

            deleteTime = 0;

        }
    }

    public void StartLevel()
    {
        PlayerPrefs.DeleteKey("LevelSaved");
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    public void ContinueLevel()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator DeleteData()
    {
        while (true)
        {
            float time = (float)deleteTime / completed;
            delImage.fillAmount = time;


            if (deleteTime > 7)
            {
                PlayerPrefs.DeleteAll();
                Application.Quit();
            }
            yield return null;
        }

    }
}
