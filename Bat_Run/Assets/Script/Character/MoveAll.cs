using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAll : MonoBehaviour
{
    public int CounterBat;
    public GameObject[] _bat;
    private float _speedBat = 5f;
    private bool _oneCall = true;

    [SerializeField]
    private GameObject _prefabSmokeExplosion;
    [SerializeField]
    private GameObject _prefabBat;
    [SerializeField]
    private GameObject _objZoneTransform;
    [SerializeField]
    private TransformZone transformZone;
    private void OnMouseDrag()
    {
        _bat = GameObject.FindGameObjectsWithTag("Bat");
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);

        _objZoneTransform.SetActive(true);
        _objZoneTransform.transform.position = Vector3.MoveTowards(_objZoneTransform.transform.position, _mousePos, Time.deltaTime * 5000 );
        _prefabSmokeExplosion.transform.position = Vector3.MoveTowards(_prefabSmokeExplosion.transform.position, _mousePos, Time.deltaTime * _speedBat);

        for (int i = 0; i < _bat.Length; i++)
        {
            _bat[i].transform.position = Vector3.MoveTowards(_bat[i].transform.position, _mousePos, Time.deltaTime * _speedBat);
        }

        if (transformZone._triggerStayStart == true && _oneCall == true)
        {
            Instantiate(_prefabSmokeExplosion, _mousePos, quaternion);
            _oneCall = false;
        }     
    }
    private void SpawnBat(int Counter )
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < Counter; i++)
        {
            Instantiate(_prefabBat, _mousePos, quaternion);
        }
    }
    private void OnMouseUp()
    {
        CounterBat = 0;
        _objZoneTransform.SetActive(false);
        transformZone._triggerStayStart = false;
        _oneCall = true;
        SpawnBat(transformZone._spawnCounter);
        transformZone._spawnCounter = 0;
    }
}
