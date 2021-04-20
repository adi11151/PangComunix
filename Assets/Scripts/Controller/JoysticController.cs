using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the game input controller class 
public class JoysticController
{
    Joystick joystickView;
    PlayerModel model;

    float dragScreenProportions = 0.05f;
    public void Drag(float delta)
    {
        //move the joystick visually
        if (delta * dragScreenProportions > - joystickView.Base.radius && delta * dragScreenProportions < joystickView.Base.radius)
            joystickView.Move(new Vector3(delta* dragScreenProportions, joystickView.transform.localPosition.y, joystickView.transform.localPosition.z));

        //to prevent from adding another script- "joystick model" i am apdating the player model directly from here and doing the movement calculations
        //in joystick coneroller.
        delta *= Time.deltaTime * model.speed;
        if (model.position.x + delta +model.playerWitdth < model.Xbounds[0] && model.position.x +delta -model.playerWitdth > model.Xbounds[1])
        {
            model.AddDeltaPosition(new Vector3(delta, 0, 0));
        }
    }




    public void Shoot()
    {
        model.NotifyShoot();

    }

    public JoysticController(Joystick view, PlayerModel playerModel)
    {
        joystickView = view;
        joystickView.Drag += Drag;
        joystickView.ShootBtn.buttonClick += Shoot;
        model = playerModel;
    }
}
