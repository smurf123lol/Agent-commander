using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*\brief ������� ����� ������
 */
[RequireComponent(typeof(Camera))]
public class BaseCamera : MonoBehaviour
{
    public bool Active;
    public Camera mCamera;

    void Awake()
    {
        Active = false;
        mCamera = GetComponent<Camera>();
        mCamera.enabled = Active;
    }
}
