using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    public float TurnRate = 1f;

    public float MaxTurn = 30;

    public float BaseTurnX = 90;

    private float currentTurn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTurn += TurnRate*Time.deltaTime;
        if (currentTurn > MaxTurn || currentTurn < -MaxTurn) TurnRate = -TurnRate;

        transform.rotation = Quaternion.Euler(BaseTurnX+currentTurn, 80, 80);
    }
}
