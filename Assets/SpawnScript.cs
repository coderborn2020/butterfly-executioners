using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    string currentScene;
    string nextScene;
    Text respawnText;
    bool waitingForRespawn = false;
    public MonoBehaviour moveScript;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        nextScene = GetNextScene();
        respawnText = GameObject.Find("RespawnText").GetComponent<Text>();
    }

    string GetNextScene()
    {
        switch (currentScene)
        {
            case "Laboratory":
                return "Platformer2";
            case "Platformer2":
                return "Platformer3";
            case "Platformer3":
                return "Lab2";
            case "Lab2":
                return "WinScene";
            default:
                Debug.LogError($"MISSING NEXT LEVEL AFTER LEVEL {currentScene}");
                return "MainMenu";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForRespawn && Input.GetKey(KeyCode.Space))
        {
            OnRespawn();
        }
    }

    public void OnDeath()
    {
        // called by player health script on player death
        respawnText.enabled = true;
        GetComponent<SpriteRenderer>().color = Color.black;
        GetComponent<Rigidbody2D>().velocity = new Vector2();
        moveScript.enabled = false;
        waitingForRespawn = true;
    }

    void OnRespawn()
    {
        respawnText.enabled = false;
        waitingForRespawn = false;
        SceneManager.LoadScene(currentScene);
        GetComponent<SpriteRenderer>().color = Color.white;
        moveScript.enabled = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "YouWin") NextLevel();
    }
}
