using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text multiplierText;
    public int multiplier=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+ score.ToString();
        multiplierText.text = "Combo: " +multiplier.ToString() + "x";
    }
}
