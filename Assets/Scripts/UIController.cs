using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController :MonoBehaviour
{
    PanelView view;
    SceneModel model;

    public event Action startGame = null;
    public event Action replay = null;



    public IEnumerator CountToStart()
    {
        int count = 4;
        view.SetLevelText(model.currentLevel.ToString());
        while(count > 0)
        {
            Debug.Log(count);
            yield return new WaitForSeconds(1f);
            count--;
            view.SetText(count.ToString());
            
        }
        view.SetText("");
        view.SetMenuButon();

        startGame?.Invoke();
        model.gameIsOn = true;

    }
    public void ShowLevelBegginingScreen()
    {
  
        StartCoroutine(CountToStart());

    }

    public void GameOver()
    {
        model.gameIsOn = false;
        OpenMenu();


    }

    public void StartGame()
    {
        Debug.Log("start game");
        Time.timeScale = 1;

        if (model.gameIsOn)
            ResetLevel();
        view.DisactiveMenuPanel();
        ShowLevelBegginingScreen();



        
 
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        view.ActiveManuPanel();
    }

    public void ResetLevel()
    {
        replay?.Invoke();
    }

    public void SetView(PanelView view)
    {
        this.view = view;
    }

    public void SetModel(SceneModel Model)
    {
        model = Model;
    }

}
