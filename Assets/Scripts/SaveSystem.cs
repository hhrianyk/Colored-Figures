using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
     

    private void PPrefs()
    {
        int saveValues = 1;
        PlayerPrefs.SetInt("Level", saveValues);///save

        int i = PlayerPrefs.GetInt("Level");
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("Level"))
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}
