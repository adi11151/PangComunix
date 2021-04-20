using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    [SerializeField] private PanelView view;

    [SerializeField]UIController controller;
    SceneModel model;


    public void LevelChanged(int level)
    {
        controller.ShowLevelBegginingScreen();
    }

    public void GameOver()
    {


        controller.GameOver();
    }

    private void Replay()
    {
        app.pangManager.DestroyAllBalls();
    }

    private void CallPangManagerToStart()
    {
            
        app.pangManager.StartGame();
    }

    public void SetModel(SceneModel Model)
    {
        model = Model;
        model.onLevelChanged += LevelChanged;
        controller.SetModel(model);
    }

    private void Start()
    {
        controller.SetView(view);
        controller.startGame += CallPangManagerToStart;
        controller.replay += Replay;


    }
}
