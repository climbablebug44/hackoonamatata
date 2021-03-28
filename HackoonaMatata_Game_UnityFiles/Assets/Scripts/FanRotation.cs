using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{

    private float rotationZ;
    public float rotationSpeed;
    public bool clockwiseRotation;

    // Update is called once per frame
    void Update()
    {
        if(clockwiseRotation == false)
        {
            rotationZ += Time.deltaTime * rotationSpeed;
        }
        else
        {
            rotationZ += -Time.deltaTime * rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        
    }
}
