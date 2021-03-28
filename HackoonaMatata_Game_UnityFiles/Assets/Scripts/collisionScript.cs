using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    //public PrototypeHeroDemo player;
    public GameObject player;
    public toSaveAttributeHandler state;
    public SpriteRenderer explosion;
    public levelLoader level;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Finish")
        {
            level.LoadNextLevel();
        }

        if(collision.gameObject.tag == "deadly")
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<PrototypeHeroDemo>().enabled = false;
            explosion.enabled = true;
            state.state = "lost";
        }
        else if(collision.gameObject.tag == "trap")
        {
            player.GetComponent<PrototypeHeroDemo>().stop();
        }
        else if (collision.isTrigger)
        {
            collisionConsole temp = collision.gameObject.GetComponentInParent<collisionConsole>();
            if(temp!=null)
                temp.should_display = true;
        }
    }
    
}
