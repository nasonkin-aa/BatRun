using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    ScoreManager scoreManager;
    Text text;

    public string textFormat;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        text = GetComponent<Text>();

        ScoreInit();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreInit();
    }
    void ScoreInit()
    {
    }
}
