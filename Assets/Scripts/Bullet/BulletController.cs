using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 Position;
    [SerializeField] private float _speed = 30f;
    [SerializeField] private int _damage = 20;

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Position, step);
        if(transform.position == Position)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            CarAttack attack = other.GetComponent<CarAttack>();
            attack.Health -= _damage;
            Transform healthBar = other.transform.GetChild(0).transform;
            if (other.CompareTag("Enemy"))
            {
                healthBar.gameObject.SetActive(true);
                healthBar.GetComponent<Renderer>().material.color = new Color(1, 0, 0);

            }
            healthBar.localScale = new Vector3(
                healthBar.localScale.x - 0.3f, healthBar.localScale.y, healthBar.localScale.z);
            
            if (attack.Health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
