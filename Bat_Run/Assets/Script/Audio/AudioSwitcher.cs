using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    //List<GameObject> buttons = new List<GameObject>();
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
        //GameObject[] buttonsArray = GameObject.FindGameObjectsWithTag("buttom");
        //foreach (GameObject button in buttonsArray)
        //{
        //    buttons.Add(button);
        //}
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
    public void ButtonSound()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play(0);
    }
    void Update()
    {
       
    }

}
