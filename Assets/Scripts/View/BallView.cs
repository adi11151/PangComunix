using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    private Rigidbody _rb = null;
    public event Action<Collision, BallView> onBallHitBall = null;
    public event Action<Collision, BallView> onBallHitSomething = null;

    public int splitLevel;
    public Vector3 direction;

    private void OnDestroy()
    {
        onBallHitBall = null;
        onBallHitSomething = null;
    }

    public void SetDirection(Vector3 Direction)
    {
        direction = Direction;
        _rb.velocity = Direction;
    }

    public Vector3 GetVelocity()
    {
        return _rb.velocity;
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rb.velocity = velocity;

    }

    public void ChangeSize(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void FlipDir()
    {
   

        _rb.velocity = -direction.normalized ;
        direction = _rb.velocity ;

    }



    public void Pop()
    {
        Destroy(this.gameObject);
    }

    public void MoveToPosition(Vector3 newPos)
    {
        transform.position = newPos;
    }

    public void AddPosition(Vector3 additional)
    {
        transform.position += additional;
    }

    public void ChangeSize(float size)
    {
        transform.localScale = new Vector3(size, size, size);

    }

    public void JumpToDirection(float force)
    {
        Debug.Log("jump");
        _rb.velocity +=  Vector3.up * force  + direction ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallView otherBall = collision.gameObject.GetComponent<BallView>();
        if (otherBall != null)
        {
            //validate collition will trigger event only once.
            if (transform.position.x < collision.transform.position.x)
                onBallHitBall?.Invoke(collision, this);
        }
        else onBallHitSomething?.Invoke(collision, this);

    }



    private void Awake()
    {
 
        _rb = GetComponent<Rigidbody>();
    }


}
