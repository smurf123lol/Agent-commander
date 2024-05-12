using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//������������ ����� ��������
public class CameraManager : MonoBehaviour
{
    // ���� ������/��������� ������
    [Serializable]
    public struct CameraCodePair
    { 
        public BaseCamera Camera;
        public KeyCode keyCode;
    }
    // ������ �����
    public List<CameraCodePair> CameraCodePairs;
    // �������� ������
    public CameraCodePair activeCamera;

    void Start()
    {
        activeCamera = CameraCodePairs.First();
        Camera.current.enabled = false;
        activeCamera.Camera.Active = true;
        activeCamera.Camera.mCamera.enabled = true;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (var camerapair in CameraCodePairs)
        {
            if (Input.GetKeyDown(camerapair.keyCode))
            {
                if (!camerapair.Camera.Active)
                {
                    activeCamera.Camera.Active = false;
                    activeCamera.Camera.mCamera.enabled = false;
                    activeCamera = camerapair;
                    activeCamera.Camera.Active = true;
                    activeCamera.Camera.mCamera.enabled = true;
                }
            }
        }
    }
}
