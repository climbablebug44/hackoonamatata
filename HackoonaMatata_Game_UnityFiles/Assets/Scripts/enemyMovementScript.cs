using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementScript : MonoBehaviour
{
    public levelLoader level;
    public Transform player;
    public CharacterController self;
    Vector3 moveTowards;
    public float enemySpeed;
    bool should_wait;
    public toSaveAttributeHandler state;
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 1f;
    }

    IEnumerator wait(float waitTime_)
    {
        this.enabled = false;
        yield return new WaitForSeconds(waitTime_);
        this.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
            level.LoadNextLevel(3);

    }

    public void shouldWait(float waitTime)
    {
        Debug.Log("pressed");
        should_wait = true;
        this.waitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        moveTowards =  player.position - transform.position;
        self.Move(moveTowards.normalized * enemySpeed * Time.deltaTime);

        /*if (Input.GetKeyDown(KeyCode.M)) // <------------------------- remove
            shouldWait();*/
        
        if(should_wait)
        {
            StartCoroutine(wait(waitTime));
            should_wait = false;
        }

        if(transform.position.x >= 178.0f)
        {
            state.state = "lost";
            //level.LoadNextLevel(3);
        }
    }
}
