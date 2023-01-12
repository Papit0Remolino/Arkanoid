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
                GameManager.sharedInstance.points += 5;
                GameManager.sharedInstance.pointsText.text = "Score: " + GameManager.sharedInstance.points.ToString();
                if (GameManager.sharedInstance.points > GameManager.sharedInstance.highScore.highScore) 
                {
                    GameManager.sharedInstance.highScore.highScore = GameManager.sharedInstance.points;
                    GameManager.sharedInstance.highScoreText.text = "HighScore: " + GameManager.sharedInstance.points.ToString();
                }
                Destroy(this.gameObject);
            }

        }
        
    }
}
