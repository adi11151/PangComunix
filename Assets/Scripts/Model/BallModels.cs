using UnityEngine;
using System.Collections;
using System;


//this class hold the balls prefab data
[CreateAssetMenu]
public class BallModels : ScriptableObject
{
    public string materialResource = "";
    public GameObject BallGameObj = null;
    public BallModel[] ballModels;
}

[Serializable]
public class BallModel 
{
    
    public int splitLevel;
    public float jumpForce = 10f;
    public float sideForce = 2f;
    public float size = 0;


    public BallModel(float Size) {
        size = Size;
    }


    public void ChangeSize(float Size)
    {
        size = Size;
    }

    public float GetSize()
    {
        return size;
    }

}
