using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    
    public event Action playerHitBall = null;




    public void Shoot(GameObject ammo)
    {
        Instantiate(ammo, transform.position, Quaternion.identity);
    }

    public void MovePlayer(Vector3 position)
    {

        transform.position += position;


    }
 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("player collition");
        BoundView bound = collision.gameObject.GetComponent<BoundView>();

        if (bound != null)
        {
            Debug.Log("Stop");
            transform.position = new Vector3(bound.transform.position.x, transform.position.y, transform.position.z);

        }



    }
    

    


}
