using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI nscoreText;

    void Start()
    {
        if (scoreText == null)
            Debug.LogError("score text is null");
        if (BestScore == null)
            Debug.LogError("best score text is null");
        if (nscoreText == null)
            Debug.LogError("score text is null");


    }


    
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        nscoreText.text = score.ToString();
    }

    public void UpdateBestScore(float bestScore)
    {
        BestScore.text = "Best Score: " + bestScore.ToString();  // 최고 점수 표시
    }
}
