using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDCameraScript : MonoBehaviour
{
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMoving = Input.GetMouseButton(1);
        if(isMoving)
        {
            Vector3 delta = new Vector3(Input.GetAxis("Mouse Y"),
                0,
                -Input.GetAxis("Mouse X"));
            this.transform.position += delta*1.4f;
        }
    }
}
