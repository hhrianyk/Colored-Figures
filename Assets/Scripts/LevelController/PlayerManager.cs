using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool isGameStarted;
    public static bool isGameFinished;
    public static bool isGamePaused;

    public GameObject PanelToStart;
    public GameObject PanelFinish;


    void Start()
    {
        if (PanelToStart != null)
            PanelToStart.SetActive(true);
        PanelFinish.SetActive(false);

        Time.timeScale = 1;
        gameOver = isGameStarted = isGameFinished = false;
 
    }

    void Update()
    {

        //Start Game
        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            isGameStarted = true;

            if(PanelToStart!=null)
            Destroy(PanelToStart);
        }
        if(gameOver)
        {
            StartCoroutine(RestartLevel(5));
        }
        if(isGameFinished)
        {
            PanelFinish.SetActive(true);
        }

    }

    private IEnumerator RestartLevel(float time)
    {
        // Do something before
       
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);


    }
}
