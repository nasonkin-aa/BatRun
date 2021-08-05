using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorageManager : MonoBehaviour
{
    public bool AudioOn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(GameObject.Find("DataStorage"));
    }
}
