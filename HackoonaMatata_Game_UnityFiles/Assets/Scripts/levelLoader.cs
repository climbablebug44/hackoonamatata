using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelLoader : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadNextLevel(int level)
    {
        StartCoroutine(loadLevel(level));
    }

    public void loadMainMenu()
    {
        StartCoroutine(loadLevel(0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            LoadNextLevel();
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
