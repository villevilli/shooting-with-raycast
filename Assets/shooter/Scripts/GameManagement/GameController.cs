using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text score;  
    public Text tutorialText;

    private int currentScore = 0;

	// Use this for initialization
	void Start ()
    {
        score.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update ()
    {
		

    }
    public void AddScore(int score)
    {
        currentScore = currentScore + score;
        updatetext();
    }
    private void updatetext()
    {
        score.text = "Score: "+currentScore;
        
    }
    public void restart()
    {
        
    }
}
