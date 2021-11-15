using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lab1script : MonoBehaviour
{
    bool jerryDoorOpened = false;
    bool bobDoorOpened = false;
    bool berpyDoorOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(!jerryDoorOpened && allEnemies.Where((en) => {return en.name.Contains("Jerry");}).Count() < 2)
        {
            // if only one jerry
            var jerryDoor = GameObject.Find("JerryDoor");
            if (jerryDoor)
            {
                Destroy(jerryDoor);
                jerryDoorOpened = true;
            }
        }

        if(!bobDoorOpened && allEnemies.Where((en) => {return en.name.Contains("Bob");}).Count() < 2)
        {
            // if only one jerry
            var bobDoor = GameObject.Find("BobDoor");
            if (bobDoor)
            {
                Destroy(bobDoor);
                bobDoorOpened = true;
            }
        }

        if(!berpyDoorOpened && allEnemies.Where((en) => {return en.name.Contains("Berpy");}).Count() < 1)
        {
            // if only one berpy
            var berpyDoor = GameObject.Find("BerpyDoor");
            if (berpyDoor)
            {
                Destroy(berpyDoor);
                berpyDoorOpened = true;
            }
        }

    }
}
