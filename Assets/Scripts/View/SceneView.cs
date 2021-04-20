using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneView : MonoBehaviour
{
    public Camera MainCamera;
 

    [SerializeField] public BallInstantiator instantiator = null;
    [SerializeField] public List<BoundView> gameBounds = null;
    [SerializeField] public PlayerView player = null;
    [SerializeField] public Joystick Joystick = null;
    [SerializeField] public Ammo Ammo = null;








}
