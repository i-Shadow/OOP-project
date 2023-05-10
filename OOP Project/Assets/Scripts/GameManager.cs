using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Animator animator;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameOver;
    public static GameManager Instance;
    public GameObject heart1Full, heart2Full, heart3Full, heart1Half, heart2Half, heart3Half, heart1Hollow, heart2Hollow, heart3Hollow;
    public int lives = 6;
    public int maxLives = 6;
    public int minLives = 0;
    public float score = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LivesIndication();
       if (!gameOver)
        {
            score = score += Time.deltaTime;
            scoreText.SetText("Score: " + (int)score);
        }
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        animator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        animator.SetTrigger("Sit_b");

    }

    private void LivesIndication()
    {
        switch (lives)
        {
            case 6:

                heart1Full.gameObject.SetActive(true);
                heart2Full.gameObject.SetActive(true);
                heart3Full.gameObject.SetActive(true);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(false);
                heart1Hollow.gameObject.SetActive(false);
                heart2Hollow.gameObject.SetActive(false);
                heart3Hollow.gameObject.SetActive(false);
                break;
            case 5:
                heart1Full.gameObject.SetActive(true);
                heart2Full.gameObject.SetActive(true);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(true);
                heart1Hollow.gameObject.SetActive(false);
                heart2Hollow.gameObject.SetActive(false);
                heart3Hollow.gameObject.SetActive(false);
                break;

            case 4:

                heart1Full.gameObject.SetActive(true);
                heart2Full.gameObject.SetActive(true);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(false);
                heart1Hollow.gameObject.SetActive(false);
                heart2Hollow.gameObject.SetActive(false);
                heart3Hollow.gameObject.SetActive(true);
                break;
            case 3:
                heart1Full.gameObject.SetActive(true);
                heart2Full.gameObject.SetActive(false);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(true);
                heart3Half.gameObject.SetActive(false);
                heart1Hollow.gameObject.SetActive(false);
                heart2Hollow.gameObject.SetActive(false);
                heart3Hollow.gameObject.SetActive(true);
                break;

            case 2:
                heart1Full.gameObject.SetActive(true);
                heart2Full.gameObject.SetActive(false);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(true);
                heart1Hollow.gameObject.SetActive(false);
                heart2Hollow.gameObject.SetActive(true);
                heart3Hollow.gameObject.SetActive(true);
                break;

            case 1:

                heart1Full.gameObject.SetActive(false);
                heart2Full.gameObject.SetActive(false);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(true);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(false);
                heart1Hollow.gameObject.SetActive(false);
                heart2Hollow.gameObject.SetActive(true);
                heart3Hollow.gameObject.SetActive(true);
                break;
            case 0:
                heart1Full.gameObject.SetActive(false);
                heart2Full.gameObject.SetActive(false);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(false);
                heart1Hollow.gameObject.SetActive(true);
                heart2Hollow.gameObject.SetActive(true);
                heart3Hollow.gameObject.SetActive(true);
                GameOver();
                break;

            default:

                heart1Full.gameObject.SetActive(false);
                heart2Full.gameObject.SetActive(false);
                heart3Full.gameObject.SetActive(false);
                heart1Half.gameObject.SetActive(false);
                heart2Half.gameObject.SetActive(false);
                heart3Half.gameObject.SetActive(false);
                heart1Hollow.gameObject.SetActive(true);
                heart2Hollow.gameObject.SetActive(true);
                heart3Hollow.gameObject.SetActive(true);
                break;



        }

    }
}
