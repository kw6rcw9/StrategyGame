using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaceBuild : MonoBehaviour
{
    [SerializeField] private GameObject _building;

    
    public void PlaceBuild()
    {
        Instantiate(_building, Vector3.zero, Quaternion.identity);
    }
}
