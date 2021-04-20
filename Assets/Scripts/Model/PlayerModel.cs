using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class PlayerModel
{

    public Vector3 position;
    public float[] Xbounds = new float[2];
    public float playerWitdth;
    public float speed = 3f;

    public int currentAmmo = 0;
    public AmmoModel[] ammoModels;
    public bool isCurrentyShooting = false;
    public Vector3 initPos;

    public event Action<Vector3> positionChanged = null;
    public event Action<AmmoModel> playerShoot = null;

    public void NotifyShoot()
    {
        Debug.Log("shodot");
        playerShoot?.Invoke(ammoModels[currentAmmo]);
    }





    public void AddDeltaPosition(Vector3 movement)
    {
        positionChanged?.Invoke(movement);
        position += movement;

    }


}
