using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowTextScript : MonoBehaviour
{
    Text text;
    float color = 0f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        color += .5f * Time.deltaTime;
        text.color = Color.HSVToRGB(color, 1, 1);
        if (color > 1) color = 0;
    }
}
