using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int durability;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            durability--;
            if (durability <= 0)
            {
                GameManagerArkanoid.sharedInstance.points += 5;
                GameManagerArkanoid.sharedInstance.pointsText.text = "Score: " + GameManagerArkanoid.sharedInstance.points.ToString();
                if (GameManagerArkanoid.sharedInstance.points > GameManagerArkanoid.sharedInstance.highScore.highScore) 
                {
                    GameManagerArkanoid.sharedInstance.highScore.highScore = GameManagerArkanoid.sharedInstance.points;
                    GameManagerArkanoid.sharedInstance.highScoreText.text = "HighScore: " + GameManagerArkanoid.sharedInstance.points.ToString();
                }
                Destroy(this.gameObject);
            }

        }
        
    }
}
