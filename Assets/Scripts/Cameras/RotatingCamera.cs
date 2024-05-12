using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*!
 * \brief ����� ����������� ������
 * \detail ������ �������� ����������� �������� � ������������ �������� �� ��� x/y
 * \TODO ��������� UI ��� ������
 */
public class RotatingCamera : BaseCamera
{
    /* ��������� ���� ������� ������ �� ��� X(�����������)*/
    [Range(0, 360)]
    public float BaseAngleX;
    [Range(0,180)]
    /* ������������ ������� �������� �� ��� X*/
    public float MaxShiftX;
    /* ��������� ���� ������� ������ �� ��� Y(�������������)*/
    [Range(0, 360)]
    public float BaseAngleY;
    /* ������������ ������� �������� �� ��� Y*/
    [Range(0, 180)]
    public float MaxShiftY;

    /*��������� �������� �������� �� ���������*/
    public float HorizontalSpeed;
    /*��������� �������� �������� �� �����������*/
    public float VerticalSpeed;

    /*�������� ���� �������� ������������ ������������ �� ��� X*/
    protected float shiftX = 0;
    /*�������� ���� �������� ������������ ������������ �� ��� Y*/
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
