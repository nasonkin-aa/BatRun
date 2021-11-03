using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    DataStorageManager dataStorage;
    SpeedManager speedManager;

    void Start()
    {
        dataStorage = GameObject.FindObjectOfType<DataStorageManager>();
        speedManager = GameObject.FindObjectOfType<SpeedManager>();
    }

    private void FixedUpdate()
    {
        ScoreIncrement();
    }

    private void ScoreIncrement()
    {
        dataStorage.score += (int)(5 * speedManager.gameSpeed);
    }
}
