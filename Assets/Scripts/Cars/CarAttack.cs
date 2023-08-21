using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAttack : MonoBehaviour
{
    [NonSerialized] public int Health = 100;
    [SerializeField] private float _radius = 70f;
    [SerializeField] private GameObject _bullet;
    private Coroutine _coroutine = null;
    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
       Collider[] _hitColliders = Physics.OverlapSphere(transform.position, _radius);
       if (_hitColliders.Length == 0 && _coroutine != null)
       {
           StopCoroutine(_coroutine);
           _coroutine = null;

           if (gameObject.CompareTag("Enemy"))
           {
               GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
           }
       }
       foreach (var el in _hitColliders)
       {
           if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy")) ||
               (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")))
           {
               if (gameObject.CompareTag("Enemy"))
                   GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
               
               if(_coroutine == null)
                   _coroutine = StartCoroutine(StartAttack(el));
           }
       }
    }

    IEnumerator StartAttack(Collider collider)
    {
        
            GameObject obj = Instantiate(_bullet, transform.GetChild(1).position, Quaternion.identity);
            obj.GetComponent<BulletController>().Position = collider.transform.position;
            yield return new WaitForSeconds(1f);
            _coroutine = null;
    }
    
}
