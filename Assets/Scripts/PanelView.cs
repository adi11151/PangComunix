using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : Manager
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject MenuButton;
    [SerializeField] Text Level;



    public void SetMenuButon()
    {
        MenuButton.gameObject.SetActive(true);
    }
    public void SetLevelText(string level)
    {
        MenuButton.SetActive(false);
        Level.text =  "Level : " + level;
        Level.SetAllDirty();
    }
    public void ActiveManuPanel()
    {
      
        Menu.gameObject.SetActive(true);

    }
    public void DisactiveMenuPanel()
    {
        Menu.gameObject.SetActive(false);
    }

    public void SetText(string level)
    {
        Level.text = level;
        Level.SetAllDirty();
 

    }

}
