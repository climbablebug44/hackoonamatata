using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toSaveAttributeHandler : MonoBehaviour
{
    public ProgressBar attribute1;
    public levelLoader level;
    public enemyMovementScript enemy;
    public float baseEnemySpeed;

    // Start is called before the first frame update

    public string state;
    collisionConsole[] consoles;
    public int compromised;
    public int totalConsoles;

    void Start()
    {
        consoles = GameObject.FindObjectsOfType<collisionConsole>();
        totalConsoles = consoles.Length;
        attribute1.BarValue = 100f;
        state = "";
        baseEnemySpeed = enemy.enemySpeed;
    }

    int checkConsoles()
    {
        int total_ = 0;
        foreach (collisionConsole g in consoles)
        {
            if (g.compromised)
                total_ += 1;
        }
        return total_;
    }

    // Update is called once per frame
    void Update()
    {
        // decreasing with time
        /*if (attribute2.BarValue > 0)
        {
            attribute2.BarValue -= decreaseVal * Time.deltaTime;
            attribute2.BarValue = Mathf.Max(0, attribute2.BarValue);
        }
        if (attribute1.BarValue > 0)
        { 
            attribute1.BarValue -= decreaseVal * Time.deltaTime; 
            attribute1.BarValue = Mathf.Max(0, attribute1.BarValue);
        }*/

        compromised = checkConsoles();
        attribute1.BarValue = 100 - ((float)compromised * 100f / totalConsoles);
        float enemySpeed = 100 + (attribute1.BarValue / 2);
        enemy.enemySpeed = baseEnemySpeed * enemySpeed / 100.0f;
        
        

        
        if(state=="won")
        {
            level.LoadNextLevel(2);
        }
        else if(state == "lost")
        {
            level.LoadNextLevel(3);
        }
        //other works
    }
}
