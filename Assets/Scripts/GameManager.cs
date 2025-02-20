using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UiManager uiManager;
    private float scoreText;
    private float bestScore;
    public UiManager UiManager { get { return uiManager; } }

    public GameObject EndPanel;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();
    }

    private void Start()
    {
        StartCoroutine(StartGameAfterDelay(2f));

        uiManager.UpdateScore(0);
        bestScore = PlayerPrefs.GetFloat("bestScore", 0f);  // 저장된 최고 점수를 불러옴
        uiManager.UpdateBestScore(bestScore); // 최고 점수 UI에 반영
    }

    private IEnumerator StartGameAfterDelay(float delay)
    {
        Time.timeScale = 0f; // 게임을 잠시 멈춰준다
        yield return new WaitForSecondsRealtime(delay); // 2초동안 딜레이가 생기게 해줌
        Time.timeScale = 1f; //다시 게임이 실행되고 게임속도를 1배로 맞춰줬다
    }

    public void GameOver()
    {
        EndPanel.SetActive(true);


        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("bestScore", bestScore);  // 새로운 최고 점수 저장
            uiManager.UpdateBestScore(bestScore);  // UI에 갱신된 최고 점수 표시
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        scoreText = currentScore;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
