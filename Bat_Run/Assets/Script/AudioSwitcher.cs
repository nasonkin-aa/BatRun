using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    //DataStorageManager dataStorageManager = GameObject.Find("DataStorage").GetComponent<DataStorageManager>();
    //AudioListener audioListener = Camera.main.GetComponent<AudioListener>();
    // Start is called before the first frame update
    void Start()
    {
        DataStorageManager dataStorageManager = GameObject.Find("DataStorage").GetComponent<DataStorageManager>();
        AudioListener audioListener = Camera.main.GetComponent<AudioListener>();
        if (!dataStorageManager.AudioOn)
        {
            audioListener.enabled = false;
        }
        else
        {
            audioListener.enabled = true;
        }
    }

    public void SwitchAudio()
    {
        DataStorageManager dataStorageManager = GameObject.Find("DataStorage").GetComponent<DataStorageManager>();
        AudioListener audioListener = Camera.main.GetComponent<AudioListener>();
        dataStorageManager.AudioOn = !dataStorageManager.AudioOn;
        if (!dataStorageManager.AudioOn)
        {
            audioListener.enabled = false;
        }
        else
        {
            audioListener.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
