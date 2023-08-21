using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Environment
{
    public class PlaceObjects : MonoBehaviour
    {
       
        
        [SerializeField] private LayerMask _layer;
        [SerializeField] private float _rotateSpeed = 60f;
        private void Start()
        {
            PositionObject();
        }


        private void Update()
        {
            PositionObject();

           ObjectController();
            

        }
        private void PositionObject()
        {
            
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(ray, out _hit, 1000f, _layer))
            {
                transform.position = _hit.point;
               
                




            }
        }

        private void ObjectController()
        {
            if (Input.GetMouseButton(0))
            {
                
                
                transform.position = new Vector3(transform.position.x, -10, transform.position.z);
                GetComponent<MoveHouseUp>().enabled = true;
                if(gameObject.GetComponent<AutoCreateCar>())
                    gameObject.GetComponent<AutoCreateCar>().enabled = true;
                Destroy(gameObject.GetComponent<PlaceObjects>());
            }
            if(Input.GetKey(KeyCode.LeftShift))
                transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed);

            if (Input.GetKey(KeyCode.Z))
            {
                transform.localScale += Vector3.one * 3f * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.X))
            {
                transform.localScale -= Vector3.one * 3f * Time.deltaTime;
                
            }
                
        }
    }
}
