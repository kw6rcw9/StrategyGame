using System;
using System.Collections;
using System.Collections.Generic;
using Environment;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _factory;

    private void Start()
    {
        StartCoroutine(SpawnFactory());
    }

    IEnumerator SpawnFactory()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            yield return new WaitForSeconds(10f);
            GameObject spawn = Instantiate(_factory);
            Destroy(spawn.GetComponent<PlaceObjects>());
            spawn.transform.position = _points[i].position;
            spawn.transform.rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 360), 0));
            spawn.GetComponent<AutoCreateCar>().enabled = true;
            spawn.GetComponent<AutoCreateCar>().IsEnemy = true;
        }
    }
}
