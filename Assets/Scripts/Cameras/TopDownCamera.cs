using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*!
 * \brief ����� ������ ������ ����(��� ������)
 * \TODO �������� Rect(�������) ��� ����������� ���� �������� ������, ��������� UI ��� ������
 */
public class TopDownCamera : BaseCamera
{
    /*��������� �������� �������� �� �����������*/
    public float HorizontalSpeed;
    /*��������� �������� �������� �� ���������*/
    public float VerticalSpeed;

    /*������������ �����(���������) �� �����*/
    public float MaxShift;

    void LateUpdate()
    {
        if (Active)
        {
            float keyvertical = -Input.GetAxis("Vertical") * VerticalSpeed;
            float keyhorisontal = Input.GetAxis("Horizontal") * HorizontalSpeed;

            float mouseVertical = Input.GetAxis("Mouse Y") * VerticalSpeed*5;
            float mouseHorisontal = -Input.GetAxis("Mouse X") * HorizontalSpeed*5;
            
            Vector3 axis = new Vector3(keyvertical + (Input.GetMouseButton(0) ? mouseVertical : 0),
                0,
                keyhorisontal + (Input.GetMouseButton(0) ? mouseHorisontal : 0));

            if(axis.magnitude > MaxShift) axis = axis.normalized*MaxShift;

            transform.position = transform.position + axis*Time.deltaTime;
        }
    }
}
