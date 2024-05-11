using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BaseCamera : MonoBehaviour
{
    bool Active;
    Camera camera;
    void Awake()
    {
        Active = false;
        camera = GetComponent<Camera>();
    }
}
