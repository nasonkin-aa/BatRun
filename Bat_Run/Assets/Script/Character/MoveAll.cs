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
    [SerializeField]
    private GameObject _prefabVampire;

    private void OnMouseDrag()
    {
        _bat = GameObject.FindGameObjectsWithTag("Bat");
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);

        _objZoneTransform.SetActive(true);
        _objZoneTransform.transform.position = Vector3.MoveTowards(_objZoneTransform.transform.position, _mousePos, Time.deltaTime * 5000 );
        _prefabSmokeExplosion.transform.position = Vector3.MoveTowards(_prefabSmokeExplosion.transform.position, _mousePos, Time.deltaTime * 500);
        _prefabVampire.transform.position = Vector3.MoveTowards(_prefabVampire.transform.position, _mousePos, Time.deltaTime * 500);

        for (int i = 0; i < _bat.Length; i++)
        {
            _bat[i].transform.position = Vector3.MoveTowards(_bat[i].transform.position, _mousePos, Time.deltaTime * _speedBat);
        }

        if (transformZone._triggerStayStart == true && _oneCall == true)
        {
            StartCoroutine(ChangeFormBatVampire());
            _oneCall = false;
        }     
    }
    private IEnumerator ChangeFormBatVampire()
    {
        _prefabSmokeExplosion.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _prefabSmokeExplosion.SetActive(false);
        _prefabVampire.SetActive(true);
    }
    private IEnumerator ChangeFormVampireBat() 
    {
        _prefabVampire.SetActive(false);
        if (transformZone._triggerStayStart == true)
        { 
            _prefabSmokeExplosion.SetActive(true);
        }
        yield return new WaitForSeconds(0.3f);
        _prefabVampire.SetActive(false);
        _prefabSmokeExplosion.SetActive(false);
        SpawnBat(transformZone._spawnCounter);
        transformZone._spawnCounter = 0;
    }
    private void SpawnBat(int Counter )
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < Counter; i++)
        {
            Instantiate(_prefabBat, _prefabSmokeExplosion.transform.position, quaternion);
        }
    }
    private void OnMouseUp()
    {
        StartCoroutine(ChangeFormVampireBat());
        CounterBat = 0;
        _objZoneTransform.SetActive(false);
        transformZone._triggerStayStart = false;
        _oneCall = true;
        //_prefabSmokeExplosion.SetActive(false);
    }

}
