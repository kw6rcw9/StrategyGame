using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateCar : MonoBehaviour
{
    public  bool IsEnemy = false;
    [SerializeField] private  GameObject _car;
    [SerializeField] private float _time = 5f;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        for (int i = 1; i <= 3; i++)
        {
            yield return new WaitForSeconds(_time);
            Vector3 pos = new Vector3(transform.GetChild(0).position.x + UnityEngine.Random.Range(3f, 8f),
                transform.GetChild(0).position.y,
                transform.GetChild(0).position.z + UnityEngine.Random.Range(3f, 8f));
            GameObject spawn = Instantiate(_car, pos, Quaternion.identity);
            if (IsEnemy)
                spawn.tag = "Enemy";
        }
    }
}
