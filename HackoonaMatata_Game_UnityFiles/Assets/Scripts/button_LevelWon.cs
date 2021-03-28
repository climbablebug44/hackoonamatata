using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_LevelWon : MonoBehaviour
{
    public levelLoader level;
   public void MainMenuButton()
    {
        level.loadMainMenu();
    }
}
