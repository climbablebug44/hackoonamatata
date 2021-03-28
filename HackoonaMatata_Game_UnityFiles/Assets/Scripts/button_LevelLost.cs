using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_LevelLost : MonoBehaviour
{
    public levelLoader level;
    public void GameButton()
    {
        level.LoadNextLevel(1);
    }
}
