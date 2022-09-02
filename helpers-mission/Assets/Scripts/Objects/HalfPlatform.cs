using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    void Start() 
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.S)){
            effector.rotationalOffset = 180f;
        }
        if(Input.GetKey(KeyCode.J)){
            effector.rotationalOffset = 0;
        }
    }
}
