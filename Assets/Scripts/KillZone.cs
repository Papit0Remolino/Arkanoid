using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GameManagerArkanoid.sharedInstance.lives--;
            collision.gameObject.GetComponent<ArkanoidBall>().ResetBall();
        }
    }
}
