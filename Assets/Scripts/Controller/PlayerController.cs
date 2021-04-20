using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    PlayerView view;
    PlayerModel model;

 

    public void Shoot(AmmoModel ammo)
    {
        view.Shoot(ammo.ammoGameObj);
            
    }

    


    private void MovePlayer(Vector3 position)
    {
        view.MovePlayer(position);                   
    }

    public PlayerController(PlayerView Pview, PlayerModel Pmodel)
    {
        view = Pview;
        model = Pmodel;
        Pmodel.playerWitdth = view.gameObject.GetComponent<CapsuleCollider>().radius;
        model.positionChanged += MovePlayer;
        model.playerShoot += Shoot;


    }


}
