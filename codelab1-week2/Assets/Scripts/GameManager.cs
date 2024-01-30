using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    public int score = 0;

    public TextMeshProUGUI scoreText;

    public int targetScore = 5;

    public int levelNumber = 1;

    private void Awake() //happens before first frame, before start - put singleton stuff here
    {

        if (instance == null) //if instance var has nothing aka no singleton
        {

            instance = this; //change to current instance
            
            DontDestroyOnLoad(gameObject);

        }
        else //if theres already a singleton of this type
        {
            
            Destroy(gameObject);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + score;

        if (score == targetScore)
        {

            levelNumber++;
            
            SceneManager.LoadScene("Level" + levelNumber);

            targetScore = Mathf.RoundToInt(targetScore + targetScore * 1.5f); //mult. original target score by 1.5f (add f for float)
            //level 1 target: 5
            //level 2 target: 5 + 5(1.5) = 5 + 7.5 = 12.5 = 13
            //level 3 target: 13 + 13(1.5) = 13 + 19.5 = 32.5 = 33
        }

    }
}
