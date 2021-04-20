using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public UIManager UImanager;
    public PangManager pangManager;

    [SerializeField] private DataModel Dmodel;
    private void Start()
    {

        var model = new SceneModel(Dmodel);
        pangManager.SetModel(model);
        UImanager.SetModel(model);

    }
}
