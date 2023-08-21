using Unity.VisualScripting;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 10.0f, _speed = 10.0f, _zoomSpeed = 10.0f;
        private float _mult = 1f;
        private void Update()
        {
            
            float _rotate = 0f;
            if (Input.GetKey(KeyCode.Q))
            {
                _rotate = -1f;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                _rotate = 1f;
            }

            _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
            transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime * _rotate * _mult, Space.World);
            transform.position += transform.up * _zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
            transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, -25f, 25f), transform.position.z);
           
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            // float hor = 0f, ver = 0f;
            //
            // if (Input.mousePosition.x < 5f)
            //     hor = -1f;
            // if (Input.mousePosition.y < 5f)
            //     ver = -1f;
            //
            // if (Input.mousePosition.x > Screen.width - 5f) 
            //     hor = 1f;
            // if (Input.mousePosition.y > Screen.height - 5f)
            //     ver = 1f;
            //
             transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * _speed, Space.Self);
        }
    }
}
