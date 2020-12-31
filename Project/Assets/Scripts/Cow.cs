using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cow : MonoBehaviour
{
    [SerializeField] Transform cowPosition;

    private float currentTime = 0f;
    private const float highPos = 0.5f;
    private const float lowPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(1f <= currentTime)
        {
            currentTime = 0f;
            var pos = cowPosition.position;
            cowPosition.position = new Vector3(pos.x, pos.y == highPos ? lowPos : highPos, pos.z );
        }
        
    }
}
