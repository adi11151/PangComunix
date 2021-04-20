using UnityEngine;
using System.Collections;
using static Enums;
using System;

public class BoundView : MonoBehaviour
{
    public BoundPos bound;
    public event Action<BoundPos, BallView> BallReachedBound = null;

    public void SetPosition(float Position)
    {
        Debug.Log("set position");

        transform.position = new Vector3(Position, transform.position.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallView ball = collision.gameObject.GetComponent<BallView>();
        if(ball != null)
            BallReachedBound?.Invoke(bound, ball);
    }


}


