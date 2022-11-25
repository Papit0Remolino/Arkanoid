using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    public Vector2 ballInit;

    void Start()
    {
        RestartBallMovement();
        ballInit = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Racket")
        {
            float xF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(xF, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
    private float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketWidth)
    {
        return (ballPosition.x - racketPosition.x) / racketWidth;
    }
    public void ResetBall()
    {
        GetComponent<TrailRenderer>().emitting = false;
        speed = 10;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = ballInit;
        GetComponent<TrailRenderer>().emitting = true;
        if (GameManager.sharedInstance.lives > 0)
        {
            Invoke("RestartBallMovement", 2.0f);
        }
    }

    void RestartBallMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}
