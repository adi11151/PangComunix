using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInstantiator : MonoBehaviour
{
    [SerializeField]GameObject Ball = null;

    public GameObject GetBall()
    {
        return Ball;
    }


    public void ChangeMaterial(BallView ball, string meterialResource)
    {
        ball.GetComponent<Renderer>().material = Resources.Load(meterialResource, typeof(Material)) as Material;
        Debug.Log(meterialResource);
    }

    public BallView SpawnBall(GameObject Ball, float size, string meterialResource)
    {
        GameObject ball = Instantiate(Ball);
        ball.transform.localScale = new Vector3(size, size,size);
        Material material = Resources.Load(meterialResource, typeof(Material)) as Material;
        ball.GetComponent<Renderer>().material = material;
        Debug.Log(meterialResource);
        BallView bv = ball.GetComponent<BallView>();

        
        return bv;
    }
    
}
