using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab2script : MonoBehaviour {
    bool doorOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(!doorOpened && allEnemies.Length < 2)
        {
            // if only one jerry
            var door = GameObject.Find("BossDoor");
            if (door)
            {
                Destroy(door);
                doorOpened = true;
            }
        }

    }
}
