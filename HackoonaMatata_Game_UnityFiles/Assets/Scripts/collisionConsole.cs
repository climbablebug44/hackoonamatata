using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class collisionConsole : MonoBehaviour
{
    public Light2D light_;
    public SpriteRenderer self;
    public bool should_display;
    public Transform player;
    public GameObject typingScreen;
    bool interacting = false;
    public float enemyStopScale = 1f;
    float score;
    public enemyMovementScript enemy;
    bool activated;
    public bool compromised;
    
    

    // Start is called before the first frame update
    void Start()
    {
        self.enabled = false;
        activated = false;
        compromised = false;
        typingScreen.GetComponent<typingComponent>().ResetText();
    }

    public void Interact()
    {
        //Debug.Log("Interacting");

        typingScreen.SetActive(true);

        player.GetComponent<PrototypeHeroDemo>().enabled = false;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            interacting = false;
            typingScreen.SetActive(false);
            player.GetComponent<PrototypeHeroDemo>().enabled = true;

            score = typingScreen.GetComponent<typingComponent>().calculateScore() * enemyStopScale;
            enemy.shouldWait(score);
            activated = true;
            typingScreen.GetComponent<typingComponent>().ResetText();
        }

    }

    public void Display()
    {
        
        if (should_display)
        {
            self.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                typingScreen.GetComponent<typingComponent>().ResetText();
                interacting = true;
            }
        }
        else
            self.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (compromised)
        {
            should_display = false;
            self.enabled = false;
            interacting = false;
            typingScreen.SetActive(false);
            player.GetComponent<PrototypeHeroDemo>().enabled = true;
            activated = true;
            //typingScreen.GetComponent<typingComponent>().ResetText();
            return;
        }
        Display();
        if (should_display && (player.transform.position.x > transform.position.x + 1 || player.transform.position.x < transform.position.x - 1))
            should_display = false;

        if(interacting)
        {
            self.enabled = false;
            Interact();
        }

        if(!compromised && !activated && enemy.transform.position.x > transform.position.x)
        {
            compromised = true;
        }
        
    }
}
