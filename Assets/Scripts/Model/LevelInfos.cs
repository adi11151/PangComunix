using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu]
public class LevelInfos : ScriptableObject
{


    public LevelInfo[] levelInfos;


}

[Serializable]
public class LevelInfo 
{

    public int[] initialSplitLevels;
    public Vector3[] xPosOffset;
}

