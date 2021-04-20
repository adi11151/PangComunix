using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] public CircleCollider2D Base = null;
    [SerializeField] public ShootButton ShootBtn = null;

    
    public event Action<float> Drag = null; 
 

    private void OnMouseDown()
    {

        transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
    }

    public void Move(Vector3 movement)
    {
        transform.localPosition = movement;
    }
    Vector3 delta = Vector3.zero;
    private void OnMouseDrag()
    {
        if(Input.touchCount <2)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(mousePos.x - Base.transform.position.x);


            delta = mousePos - Base.transform.position;
            float posX = delta.x;
            Drag?.Invoke(posX);
        }



    }





}
