using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    SpeedManager speedManager;

    public int totalScore = 0;
    public int scoreModifier;

    private void Awake()
    {
        speedManager = GameObject.FindObjectOfType<SpeedManager>();
    }

    private void FixedUpdate()
    {
        totalScore += (int)(scoreModifier * speedManager.gameSpeed);
    }
}
