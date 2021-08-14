using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObstacleManager : MonoBehaviour
{
    public GameObject wallPref;
    public GameObject piecePref;
    public Collider2D[] colliders;
    public float gameSpeed = 1f;
    public float spawnPeriod = 3f;


    public float radius = 1f;
    private int spawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeSetup();
    }

    void ObstacleSpawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-3f, 3f), 6f);

        colliders = Physics2D.OverlapCircleAll(spawnPosition, radius);

        Debug.Log(!colliders.Any(n => n.gameObject.tag == "Obstacle"));

        if (spawnCounter < 6)
        {
            Instantiate(wallPref, spawnPosition, Quaternion.identity);
            spawnCounter += 1;
        }
        else
        {
            spawnPosition = new Vector2(0, 6f);
            Instantiate(piecePref, spawnPosition, Quaternion.identity);
            spawnCounter = 0;
        }
    }

    void GameSpeedChange()
    {
        gameSpeed += 0.05f;
        radius = 1f - (gameSpeed - 1);
        CancelInvoke("ObstacleSpawn");
        CancelInvoke("GameSpeedChange");
        InvokeSetup();
    }

    void InvokeSetup()
    {
        InvokeRepeating("ObstacleSpawn", 2f, spawnPeriod * (1f - (gameSpeed - 1)));
        Invoke("GameSpeedChange", spawnPeriod * 5);
    }

    private void Update()
    {

    }
}
