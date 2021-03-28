using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehaviour : MonoBehaviour
{
    public levelLoader level;
    public void StartButton()
    {
        level.LoadNextLevel();        
    }

    public void CreditsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
