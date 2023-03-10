using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dataManager : MonoBehaviour
{
    public int deleteTime = 0;
    public TMP_Text continue_levelint;
    public Button continueLvl;
    void Start()
    {
        StartCoroutine(DeleteData());

       if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            continue_levelint.text = "Continue   " + "Level ( " + PlayerPrefs.GetInt("CurrentLevel") + " )";
            continueLvl.gameObject.SetActive(true);
        }
    }

    
      
           
        
    IEnumerator DeleteData()
     {
       while (true)
       {
            if(Input.GetKey(KeyCode.Delete))
            {
            yield return new WaitForSeconds(1);
            deleteTime = deleteTime + 1;
            }
           

          if(deleteTime == 7)
            {
             PlayerPrefs.DeleteAll();
            Application.Quit();
            }          
       } 
            
     }
}
