using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text Score;
    public Text CenterMessage;
    public List<GameObject> Lives = new List<GameObject>(3);

    private int PlayerScore = 0;
    private int LivesRemaining;

	// Use this for initialization
	void Start () {
        LivesRemaining = Lives.Count;
        CenterMessage.gameObject.SetActive(false);
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void OnStartClicked()
    {
        PlayerScore = 0;
        Score.text = "Score: " + PlayerScore.ToString();
        LivesRemaining = Lives.Count;
        for(int i = 0; i< Lives.Count; i++)
        {
            Lives[i].SetActive(true);
        }
        CenterMessage.gameObject.SetActive(false);
    }
   private void AddScore(int amountToAdd)
    {
        PlayerScore += amountToAdd;
        Score.text = "Score: " + PlayerScore.ToString();   }

    void loseLife()
    {
        if (LivesRemaining > 0)
        {
            LivesRemaining--;
            Lives[LivesRemaining].SetActive(false);
        }
    }

    private bool CheckGameOver()
    {
        if(LivesRemaining == 0)
        {
            CenterMessage.gameObject.SetActive(true);
            return true;
        }
        return false;
    }
}
