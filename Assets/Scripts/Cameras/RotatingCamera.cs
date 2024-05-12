using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*!
 * \brief  ласс вращающейс€ камеры
 * \detail  амера обладает стандартрым наклоном и возможностью поворота по оси x/y
 * \TODO ќтдельный UI дл€ камеры
 */
public class RotatingCamera : BaseCamera
{
    /* Ќачальный угол наклона камеры по оси X(вертикально)*/
    [Range(0, 360)]
    public float BaseAngleX;
    [Range(0,180)]
    /* ћаксимальный уровень смещени€ по оси X*/
    public float MaxShiftX;
    /* Ќачальный угол наклона камеры по оси Y(горизонтально)*/
    [Range(0, 360)]
    public float BaseAngleY;
    /* ћаксимальный уровень смещени€ по оси Y*/
    [Range(0, 180)]
    public float MaxShiftY;

    /*ћножитель скорости поворота по вертикали*/
    public float HorizontalSpeed;
    /*ћножитель скорости поворота по горизонтали*/
    public float VerticalSpeed;

    /*—мещение угла поворота относительно стандартного по оси X*/
    protected float shiftX = 0;
    /*—мещение угла поворота относительно стандартного по оси Y*/
    protected float shiftY = 0;

    void Update()
    {
        if(Active)
        {
            float keyvertical = -Input.GetAxis("Vertical") * VerticalSpeed;
            float keyhorisontal = Input.GetAxis("Horizontal") * HorizontalSpeed;

            shiftX = Mathf.Clamp(shiftX + keyvertical * Time.deltaTime, -MaxShiftX, MaxShiftX);
            shiftY = Mathf.Clamp(shiftY + keyhorisontal * Time.deltaTime, -MaxShiftY, MaxShiftY);

            Vector3 euler = new Vector3((BaseAngleX+shiftX)%360, (BaseAngleY+shiftY)%360, 0);

            Quaternion quaternion = Quaternion.Euler(euler);
            transform.localRotation = quaternion;
        }
    }
}
