using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttack : MonoBehaviour
{
    [SerializeField] private float _radius = 70f;

    private void DetectCollision()
    {
       Collider[] _hitColliders = Physics.OverlapSphere(transform.position, _radius);
       foreach (var el in _hitColliders)
       {
           if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy")) ||
               (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")))
           {
               Debug.Log(el.name);
           }
       }
    }
    
}
