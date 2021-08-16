using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObstacleManager : MonoBehaviour
{
    public GameObject wallPref;
    public GameObject[] piecePref;
    public GameObject bonusPref;
    public Collider2D[] colliders;
    public float spawnPeriod = 3f;
    public SpeedManager speedManager;

    private float gameSpeed;
    private float radius = 1f;
    private int spawnCounter = 0;

    private void Awake()
    {
        speedManager = GameObject.FindObjectOfType<SpeedManager>();
        gameSpeed = speedManager.gameSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeSetup();
    }

    void ObstacleSpawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-3f, 3f), 6f);

        colliders = Physics2D.OverlapCircleAll(spawnPosition, radius);

        //Debug.Log(!colliders.Any(n => n.gameObject.tag == "Obstacle"));

        if (spawnCounter < 6)
        {
            Instantiate(wallPref, spawnPosition, Quaternion.identity);
            if (spawnCounter == 4) Invoke("BonusSpawn", 0f);
            spawnCounter += 1;
        }
        else
        {
            spawnPosition = new Vector2(0, 6f);
            Instantiate(piecePref[Random.Range(0, piecePref.Length - 1)], spawnPosition, Quaternion.identity);
            spawnCounter = 0;
        }
    }

    void BonusSpawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-3f, 3f), 6f);

        if (!colliders.Any(n => n.gameObject.tag == "Obstacle"))
        {
            Instantiate(bonusPref, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(bonusPref, new Vector2(-spawnPosition.x, spawnPosition.y + 0.75f), Quaternion.identity);
        }
    }

    void GameSpeedChange()
    {
        speedManager.gameSpeed += 0.05f;
        gameSpeed = speedManager.gameSpeed;
        radius = 1f - (gameSpeed - 1);
        CancelInvoke("ObstacleSpawn");
        CancelInvoke("GameSpeedChange");
        InvokeSetup();
    }

    void InvokeSetup()
    {
        Debug.Log(spawnPeriod * (1f - (gameSpeed - 1)));
        InvokeRepeating("ObstacleSpawn", 2f, spawnPeriod * (1f - (gameSpeed - 1)));
        Invoke("GameSpeedChange", spawnPeriod * 5);
    }

    private void Update()
    {

    }
}
