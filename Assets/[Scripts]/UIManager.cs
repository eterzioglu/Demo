using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Variables
    public InputField gridCount;
    public Button button;
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject endPanel;
    public Text scoreText;
    public Button restartButton;
    public int scoreCount = 0;
    #endregion

    #region Singleton
    public static UIManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    void Start()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score : " + scoreCount;

        if (scoreCount == 3)
        {
            Success();
        }
    }

    public void GenerateGridButton()
    {
        gridCount.image.DOFade(0, 0.5f);
        gridCount.transform.GetChild(1).GetComponent<Text>().DOFade(0, 0.5f);
        button.image.DOFade(0, 0.5f);
        button.transform.GetChild(0).GetComponent<Image>().DOFade(0, 0.5f);
        button.transform.GetChild(1).GetComponent<Text>().DOFade(0, 0.5f).OnComplete(() =>
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            GridManager.instance.GenerateGrid();
        });
    }

    void Success()
    {
        scoreText.DOFade(0, 0.25f).OnComplete(() =>
            {
                gamePanel.SetActive(false);
                endPanel.SetActive(true);
                scoreCount = 0;
            });
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
