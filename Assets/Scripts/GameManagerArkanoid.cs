using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerArkanoid : MonoBehaviour
{
    public static GameManagerArkanoid sharedInstance = null;

    public Image live1, live2, live3;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] TextMeshProUGUI win;
    [SerializeField] GameObject[] bloques = new GameObject[6];
    [SerializeField] GameObject raqueta;
    public int points;
    public TextMeshProUGUI pointsText;
    public HighScore highScore;
    public TextMeshProUGUI highScoreText;
    public int lives = 3;
    // Start is called before the first frame update
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        
    }
    private void Start()
    {
        highScoreText.text = "HighScore: " + highScore.highScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            win.gameObject.SetActive(true);
            StartCoroutine(GoToNextScene());
        }
        //if (lives < 3)
        //{
        //    live3.enabled = false;
        //}
        //if (lives < 2)
        //{
        //    live2.enabled = false;
        //}
        //if (lives < 1)
        //{
        //    live1.enabled = false;
        //}
        switch (lives)
        {
            case 3:
                live3.enabled = true;
                live2.enabled = true;
                live1.enabled = true;
                break;
            case 2:
                live3.enabled = false;
                break;
            case 1:
                live2.enabled = false;
                break;
            case 0:
                live1.enabled = false;
                gameOver.gameObject.SetActive(true);
                for (int i = 0; i < 6; i++)
                {
                    bloques[i].AddComponent<Rigidbody2D>();
                }
                raqueta.GetComponent<BoxCollider2D>().enabled = false;
                raqueta.GetComponent<RacketMovementArkanoid>().enabled = false;
                break;
            default:
                // si quieres añadir mas vidas aqui esta el problema
                //si se sale de 3 por arriba o de 0 por abajo se eliminan todas las vidas
                live3.enabled = false;
                live2.enabled = false;
                live1.enabled = false;
                break;
        }
        IEnumerator GoToNextScene()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
