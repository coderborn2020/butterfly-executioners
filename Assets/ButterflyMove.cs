using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{

    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }
}
