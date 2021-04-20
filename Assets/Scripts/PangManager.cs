using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangManager : Manager
{

    [SerializeField]private SceneView view;


	SceneModel model;
	Controller controller;

    public void Replay()
    {
		DestroyAllBalls();
		StartGame();

	}

	public void DestroyAllBalls()
    {
		BallView[] balls = FindObjectsOfType<BallView>();
		for (int ball = 0; ball < balls.Length; ball++)
			Destroy(balls[ball].gameObject);

		view.player.transform.position = model.player.initPos;

	}

	public void GameOver()
    {

		DestroyAllBalls();
		app.UImanager.GameOver();

		
    }
	public void StartGame()
    {

		controller.InitLevel();
	}



	public void SetModel(SceneModel Model)
    {
		model = Model;
		controller = new Controller(view, model);
		controller.InitBounds();
		new JoysticController(view.Joystick, model.player);
		new PlayerController(view.player, model.player);
		controller.GameOver += GameOver;
	}

	void Start()
	{




	


	}

}
