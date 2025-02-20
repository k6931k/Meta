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
        bestScore = PlayerPrefs.GetFloat("bestScore", 0f);  // ����� �ְ� ������ �ҷ���
        uiManager.UpdateBestScore(bestScore); // �ְ� ���� UI�� �ݿ�
    }

    private IEnumerator StartGameAfterDelay(float delay)
    {
        Time.timeScale = 0f; // ������ ��� �����ش�
        yield return new WaitForSecondsRealtime(delay); // 2�ʵ��� �����̰� ����� ����
        Time.timeScale = 1f; //�ٽ� ������ ����ǰ� ���Ӽӵ��� 1��� �������
    }

    public void GameOver()
    {
        EndPanel.SetActive(true);


        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("bestScore", bestScore);  // ���ο� �ְ� ���� ����
            uiManager.UpdateBestScore(bestScore);  // UI�� ���ŵ� �ְ� ���� ǥ��
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
