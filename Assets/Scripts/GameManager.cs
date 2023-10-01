using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] BorderController borderController;
    [SerializeField] Transform upLeftMarker;
    [SerializeField] Transform upRightMarker;
    [SerializeField] Transform downRightMarker;

    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI scoreText;

    AudioSource audioSource;

    private int score;

    void Awake() 
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        score = 0;
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }  

    public void AstroidKill(float shrinkAmout, int scoreAmount)
    {
        borderController.ExpandBorder(shrinkAmout);
        score += scoreAmount;
    }

    public Transform GetUpLeftMarker()
    {
        return upLeftMarker;
    }
    public Transform GetUpRightMarker()
    {
        return upRightMarker;
    }
    public Transform GetDownRightMarker()
    {
        return downRightMarker;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        audioSource.Stop();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
    public int GetScore()
    {
        return score;
    }

    public void ResetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void FastMusic(float amount)
    {
        audioSource.pitch = 1 + 0.4f * amount;
    }
}
