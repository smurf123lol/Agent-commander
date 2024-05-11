using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Serializable]
    public struct CameraCodePair
    { 
        public BaseCamera Camera;
        public KeyCode keyCode;
    }
    public List<CameraCodePair> CameraCodePairs;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
