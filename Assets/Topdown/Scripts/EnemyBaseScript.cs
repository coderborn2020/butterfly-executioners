using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseScript : MonoBehaviour
{

    GameObject player;
    public bool SeesPlayer { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) SeesPlayer = false;
        else
        {
            // player exists, see if this enemy can see them
            SeesPlayer = false;
            var checkPlayer = Physics2D.Linecast(transform.position, player.transform.position, LayerMask.GetMask("Walls"));
            if (checkPlayer.collider == null)
            {
                // if nothing hit, there is a clear line of sight
                SeesPlayer = true;
            }
        }
    }
}
