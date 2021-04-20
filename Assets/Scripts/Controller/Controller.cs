using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;


//this is the maon controller of the game responsoble for balls logic and general stuff like game bounds
public class Controller
{
    SceneModel model;
    SceneView view;


    public event Action GameOver = null;

    private void BallCollision(Collision other , BallView ball)
    {

        BallView otherBall = other.gameObject.GetComponent<BallView>();
        if(otherBall != null)
        {


            otherBall.FlipDir();
            ball.FlipDir();
        }

        

    }

    private void BallInteractWithPlayer(Collision other, BallView ball)
    {
        Ammo ammo = other.gameObject.GetComponent<Ammo>();
        if (ammo != null)
            BallShoot(ball);
        else
        {

            PlayerView player = other.gameObject.GetComponent<PlayerView>();
            if (player != null)
            {
                GameOver?.Invoke();
                model.currentLevel = 1;
            }

        }
    }

    //lazer hit ball
    private void BallShoot(BallView ball)
    {
        Debug.Log("ballshoot");
        
        ball.splitLevel += 1;
        if (ball.splitLevel == model.BallModels.ballModels.Length)
        {

            ball.Pop();
            model.currentBallsOnBord--;
            if (model.currentBallsOnBord == 0)
                model.ChangeCurrentLevel(model.currentLevel + 1);

        }

        else
            SplitBall(ball);
        

    }

    //takes the existing ball shrinks it and changes its texture according to the info in the model
    public void SplitBall(BallView ball)
    {
        BallView NewBall = view.instantiator.SpawnBall(model.BallModels.BallGameObj, model.BallModels.ballModels[ball.splitLevel].size, model.BallModels.materialResource + ball.splitLevel.ToString()); ;
        NewBall.transform.position = ball.transform.position;

        //using the same ball changing its size and position
        ball.ChangeSize(model.BallModels.ballModels[ball.splitLevel].size);
        view.instantiator.ChangeMaterial(ball, model.BallModels.materialResource + ball.splitLevel.ToString());

        ball.AddPosition(-ball.direction * (model.BallModels.ballModels[ball.splitLevel].size * 0.5f));
        ball.SetDirection(-ball.direction * model.BallModels.ballModels[NewBall.splitLevel].sideForce * 0.5f); 

        NewBall.splitLevel = ball.splitLevel;

        NewBall.AddPosition(-ball.direction * (model.BallModels.ballModels[NewBall.splitLevel].size * 0.5f));
        NewBall.SetDirection(-ball.direction * model.BallModels.ballModels[NewBall.splitLevel].sideForce * 0.5f);


        NewBall.onBallHitSomething += BallInteractWithPlayer;
        NewBall.onBallHitBall += BallCollision;
        model.currentBallsOnBord += 1;


    }

    private void onBallReacheBound(BoundPos boudPos, BallView ball)
    {
        Debug.Log("ball reached");
        BallModel ballModel = model.BallModels.ballModels[ball.splitLevel];
        if (boudPos == BoundPos.bottom)
           ball.JumpToDirection(ballModel.jumpForce);
        else
            ball.FlipDir();
    

    }


    //this is initializing balls at the beggingi of level
    public void AddBall(int splitLevel , Vector3 positoin)
    {
        
        BallView ball = view.instantiator.SpawnBall(model.BallModels.BallGameObj, model.BallModels.ballModels[splitLevel].size, model.BallModels.materialResource + splitLevel.ToString());
        ball.transform.position = positoin;
        ball.splitLevel = splitLevel;
        model.currentBallsOnBord += 1;
        ball.SetDirection(Vector3.left * model.BallModels.ballModels[splitLevel].sideForce);
        ball.onBallHitBall += BallCollision;
        ball.onBallHitSomething += BallInteractWithPlayer;

    }

    public void SetBoundsPositions()
    {
        Camera camera = view.MainCamera;
        Vector3 cameraPos = camera.transform.position;
        float screenSizeX = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        float left = cameraPos.x + screenSizeX;
        float right = cameraPos.x - screenSizeX;
        view.gameBounds[(int)BoundPos.left].SetPosition(left);
        view.gameBounds[(int)BoundPos.right].SetPosition(right);

    }


    //set game Bounds data to model
    public void InitBounds()
    {
        SetBoundsPositions();
        for (int bound = 0; bound < view.gameBounds.Count; bound++)
        {
            view.gameBounds[bound].BallReachedBound += onBallReacheBound;

            if (bound < model.player.Xbounds.Length)
                model.player.Xbounds[bound] = view.gameBounds[bound].transform.position.x;

        }

    }

    //init the level from the information in the lavel infos
    public void InitLevel()
    {
    


        for (int ball = 0; ball < model.levelInfos[model.currentLevel - 1].initialSplitLevels.Length; ball++)
        {
            
            AddBall(model.levelInfos[model.currentLevel-1].initialSplitLevels[ball],
                model.levelInfos[model.currentLevel - 1].xPosOffset[ball]);
        }

    }

    public Controller(SceneView View, SceneModel Model)
    {
        model = Model;
        view = View;
        //sync data
        model.player.initPos = view.player.transform.position;
  


    }
}
