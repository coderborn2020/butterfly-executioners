using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyDieController : MonoBehaviour
{
    public int health;
    public int BaseHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = BaseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1) {
            if (gameObject.name=="BerpyEX")
            {
                SceneManager.LoadScene("WinScene");
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PlrBullet"))
        {
            health--;
        }
    }
}
