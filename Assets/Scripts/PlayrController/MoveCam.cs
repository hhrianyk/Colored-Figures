using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveCam : MonoBehaviour
{
    
    [Header("GameObject")]
    [SerializeField] private GameObject player;
    [SerializeField] private Text TextLevel;

    public float StartY = 20;

    float speed;
    CharacterController characterController;

    // Start is called before the first frame update
    private void Start()
    {

        if (PlayerPrefs.HasKey("Level") && SystemInfo.deviceType == DeviceType.Handheld) 
        {
            int Level = PlayerPrefs.GetInt("Level");

            if (Level != SceneManager.GetActiveScene().buildIndex) 
            SceneManager.LoadScene(Level);
        }

        if (TextLevel != null)
            TextLevel.text = $"<--- {SceneManager.GetActiveScene().buildIndex + 1} --->";

        transform.position = new Vector3(
               0, StartY,
               // Положение камеры z должно изменным 
               player.transform.position.z - 7f
             );

        speed = 5;

        characterController = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted) return;
        if (PlayerManager.gameOver) speed = 1;
        if (PlayerManager.isGameFinished) speed = 0;

        characterController.Move(Vector3.forward * speed * Time.fixedDeltaTime);
    }

  

 
}
