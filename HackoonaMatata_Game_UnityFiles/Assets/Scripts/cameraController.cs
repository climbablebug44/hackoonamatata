using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos.x = player.position.x;
        cameraPos.y = player.position.y;
        transform.position = cameraPos;
    }
}
