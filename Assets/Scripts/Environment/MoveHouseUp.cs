using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHouseUp : MonoBehaviour
{
    void Update()
    {
        
        Vector3 target = transform.position;
        target.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, target, 3f * Time.deltaTime);
        
        
        if(transform.position == target)
            Destroy(GetComponent<MoveHouseUp>());
    }
}
