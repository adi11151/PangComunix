using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    public event Action buttonClick  = null;

    public void OnMouseUp()
    {
        Debug.Log("Fire");
        buttonClick?.Invoke();
    }


    public void ButtonPressed()
    {
        Debug.Log("Fire");
        buttonClick?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
  
            buttonClick?.Invoke();

        }
    }
}
