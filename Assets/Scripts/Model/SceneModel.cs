using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneModel
{
    public int currentLevel = 1;
    public int currentBallsOnBord;
    public BallModels BallModels;
    public LevelInfo[] levelInfos;
    public PlayerModel player;
    public bool gameIsOn = false;

    public event Action<int> onLevelChanged = null;

    public void ChangeCurrentLevel(int CurrentLevel)
    {
        currentLevel = CurrentLevel;
        onLevelChanged.Invoke(CurrentLevel);
    }

    public SceneModel(DataModel dataModel)
    {
 
        player = new PlayerModel();
        
        player.ammoModels = new AmmoModel[2];
        BallModels = dataModel.BallModels;
        player.ammoModels = dataModel.ammoModel;
        levelInfos = new LevelInfo[dataModel.levelInfos.levelInfos.Length];
        levelInfos = dataModel.levelInfos.levelInfos;

    }
}
