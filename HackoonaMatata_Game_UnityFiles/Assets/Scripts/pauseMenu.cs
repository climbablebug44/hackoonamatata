using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject;
    public levelLoader mainMenuTransition;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuObject.SetActive(false);
    }

    public void ResumeButtton()
    {
        Time.timeScale = 1;
        pauseMenuObject.SetActive(false);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        mainMenuTransition.loadMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuObject.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
