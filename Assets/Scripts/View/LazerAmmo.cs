using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAmmo : Ammo
{
    [SerializeField]float maxHeight = 5f;
    [SerializeField]float minHeight = -1;
    float timer = 0;
    float movementDorection = 1f;
    [SerializeField]float movementSpeed;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    public void setHeight(float MinHeight)
    {
        minHeight = MinHeight;
    }

    void Update()
    {
        if (movementDorection >= 0 && transform.position.y >= maxHeight)
        {
            
            movementDorection = 0;
            timer += Time.deltaTime;

            if(timer >= 0.5f)
            {

                movementDorection = -2;

            }
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + movementDorection * movementSpeed * Time.deltaTime, transform.position.z);
        if (transform.position.y < minHeight && movementDorection < 0)
            Destroy(this.gameObject);

    }

}
