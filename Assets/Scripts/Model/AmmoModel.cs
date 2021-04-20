using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[CreateAssetMenu]
public class AmmoModel : ScriptableObject
{
    public AmmoType ammoType = AmmoType.lazer;
    public GameObject ammoGameObj = null;

}
