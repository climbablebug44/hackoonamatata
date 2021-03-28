using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundmovementScript : MonoBehaviour
{
    public float offset;
    public float speed;
    public bool horizontal;
    // true for horizontal
    Vector3 middle;
    // Start is called before the first frame update
    void Start()
    {
        middle = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
            transform.position = middle + (offset * new Vector3(Mathf.Sin(Time.time * speed), 0f, 0f));
        else
            transform.position = middle + (offset * new Vector3(0f, Mathf.Sin(Time.time * speed), 0f));
    }
}
