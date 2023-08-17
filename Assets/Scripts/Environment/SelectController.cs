using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SelectController : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    [SerializeField] private LayerMask _layer, _layerMask;
    [SerializeField] private List<GameObject> _players;
    private UnityEngine.Camera _cam;
    private GameObject _cubeSelection;
    private RaycastHit _hit;
    private void Awake()
    {
        _cam = GetComponent<UnityEngine.Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _players.Count > 0)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, _layer))
            {
                foreach (var el in _players)
                {
                    el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                }
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var el in _players)
            {
               el.transform.GetChild(0).gameObject.SetActive(false);
            }
            _players.Clear();
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out _hit, 1000f, _layer))
            _cubeSelection = Instantiate(_cube, new Vector3(_hit.point.x, 1, _hit.point.z), Quaternion.identity);
            
        }

        if (_cubeSelection)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit _hitDrag, 1000f, _layer))
            {
                float xScale =(_hit.point.x - _hitDrag.point.x) * -1;
                float zScale = _hit.point.z - _hitDrag.point.z;

                if (xScale < 0.0f && zScale < 0.0f)
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));
                }
                else if (xScale < 0.0f)
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0,0,180));
                }
                else if (zScale < 0.0f)
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(180,0,0));
                }
                else
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0)); 
                }
                _cubeSelection.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, Mathf.Abs(zScale));
            }

        }

        if (Input.GetMouseButtonUp(0) && _cubeSelection)
        {
           RaycastHit[] hits = Physics.BoxCastAll(
                _cubeSelection.transform.position, 
                _cubeSelection.transform.localScale, Vector3.up, Quaternion.identity,
                0, _layerMask);

           foreach (var el in hits)
           {
               if(el.collider.CompareTag("Enemy"))continue;
               _players.Add(el.transform.gameObject);
               el.transform.GetChild(0).gameObject.SetActive(true);
           }
            Destroy(_cubeSelection);
        }
    }
}
