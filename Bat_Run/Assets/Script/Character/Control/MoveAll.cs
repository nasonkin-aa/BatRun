using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAll : MonoBehaviour
{
    public int CounterBat;
    public GameObject[] _bat;
    public bool VampireDeath = false;

    private float _speedBat = 5f;
    private bool _oneCall = true;
    [SerializeField]
    private GameObject _prefabSmokeExplosion;
    [SerializeField]
    private GameObject _prefabBat;
    [SerializeField]
    private GameObject _objZoneTransform;
    [SerializeField]
    public TransformZone transformZone;
    [SerializeField]
    private GameObject _prefabVampire;

    private void OnMouseDrag()
    {
        _bat = GameObject.FindGameObjectsWithTag("Bat");
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);

        _objZoneTransform.SetActive(true);
        _objZoneTransform.transform.position = Vector3.MoveTowards(_objZoneTransform.transform.position, _mousePos, Time.deltaTime * 50000 );
        _prefabSmokeExplosion.transform.position = Vector3.MoveTowards(_prefabSmokeExplosion.transform.position, _mousePos, Time.deltaTime * 500);
        _prefabVampire.transform.position = Vector3.MoveTowards(_prefabVampire.transform.position, _mousePos, Time.deltaTime * 500);

        if (!VampireDeath)
        {
            foreach (var bat in _bat)
                bat.transform.position = Vector3.MoveTowards(bat.transform.position, _mousePos, Time.deltaTime * _speedBat);
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
        if(transformZone._triggerStayStart == true)
        {
            _prefabVampire.SetActive(true);
        }
    }
    private IEnumerator ChangeFormVampireBat() 
    {
        _prefabVampire.SetActive(false);

        if (transformZone._triggerStayStart == true && !VampireDeath )
        {
            _prefabSmokeExplosion.SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);
        _prefabVampire.SetActive(false);
        _prefabSmokeExplosion.SetActive(false);
        SpawnBat(transformZone._spawnCounter);
    }
    private void SpawnBat(int Counter )
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < Counter; i++)
        {
            Instantiate(_prefabBat, 
                new Vector3(Random.Range(_prefabSmokeExplosion.transform.position.x - 2, _prefabSmokeExplosion.transform.position.x + 2) ,
                Random.Range(_prefabSmokeExplosion.transform.position.y - 0.5f, _prefabSmokeExplosion.transform.position.y + 0.5f))  
                , quaternion);
        }
        transformZone._spawnCounter = 0;
    }
    private void OnMouseUp()
    {
        StartCoroutine(ChangeFormVampireBat());
        VampireDeath = false;
        _objZoneTransform.SetActive(false);
        transformZone._triggerStayStart = false;
        _oneCall = true;
        CounterBat = 0;
    }

    private void FixedUpdate()
    {
        if(_bat.Length == 0 && VampireDeath)
        {
            Debug.Log("gg");
        }

    }

}
