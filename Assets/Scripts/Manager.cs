using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{


    public GameManager app { get { return GameObject.FindObjectOfType<GameManager>(); } }
}

