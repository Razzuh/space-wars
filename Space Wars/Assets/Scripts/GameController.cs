using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController
    : MonoBehaviour {
    public GameObject asteroid;

    public Text Score;
    public Text CenterMessage;
    public List<GameObject> Lives = new List<GameObject>();
    public Text Level;
    public Text Health;

    private int PlayerScore = 0;
    private int LivesRemaining;
    private int AsteroidsRemaining;
    private int level;
    private int increaseEachLevel = 4;
    private int PlayerHealth = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void OnStartClicked()
    {
        PlayerScore = 0;
        Score.text = "Score: " + PlayerScore.ToString();
        LivesRemaining = Lives.Count;
        for (int i = 0; i < Lives.Count; i++)
        {
            Lives[i].SetActive(true);
        }
        CenterMessage.gameObject.SetActive(false);
        level = 1;
        Level.text = "Level " + level.ToString();
        Health.text = "Health: " + PlayerHealth.ToString();
        SpawnAsteroids();
    }

    public void AddScore()
    {
        if (!CheckGameOver())
            PlayerScore++;
        Score.text = "Score: " + PlayerScore.ToString();
        //if(PlayerScore == 50 || PlayerScore == 100 ||
        //    PlayerScore == 150 || PlayerScore == 200)
        //    {
        //    LivesRemaining++;
        //    Lives[LivesRemaining].SetActive(true);
        //}
        if (AsteroidsRemaining < 1)
        {
            level++;
            SpawnAsteroids();
        }
    }

    public void LoseHealth()
    {
        if (!CheckGameOver())
            PlayerHealth--;
        Health.text = "Health: " + PlayerHealth.ToString();
        if (PlayerHealth == 0)
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        if (LivesRemaining > 0)
        {
            LivesRemaining--;
            Lives[LivesRemaining].SetActive(false);
            PlayerHealth = 10;
            Health.text = "Health: " + PlayerHealth.ToString();
            CheckGameOver();
        }
    }

    private bool CheckGameOver()
    {
        if (LivesRemaining == 0)
        {
            CenterMessage.gameObject.SetActive(true);

            return true;
        }

        return false;
    }

    void SpawnAsteroids()
    {
        DestroyRemainingAsteroids();

        AsteroidsRemaining = (level * increaseEachLevel);

        for (int i = 0; i < AsteroidsRemaining; i++)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f),
                Random.Range(-6.0f, 6.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }

        Level.text = "Level " + level.ToString();
    }

    public void DecreaseAsteroids()
    {
        AsteroidsRemaining--;
    }

    //public void SplitAsteroid()
    //{
    //    AsteroidsRemaining += 2;
    //}

    void DestroyRemainingAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("LAsteroid");

        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        //GameObject[] asteroids2 = GameObject.FindGameObjectsWithTag("SAsteroid");

        //foreach (GameObject current in asteroids2)
        //{
        //    GameObject.Destroy(current);
        //}
    }
}
