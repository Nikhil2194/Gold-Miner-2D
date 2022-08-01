using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    [SerializeField] private TextMeshProUGUI countdownText;
    public int countdownTimer = 60;

    [SerializeField] private TextMeshProUGUI scoreText;
    public  int ScoreCount;

    [SerializeField] Image scoreFillUI;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
       

    }

    private void Start()
    {
        DisplayScore(0);
        countdownText.text = countdownTimer.ToString();
        StartCoroutine("Countdown");
        
    }


   IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);

        countdownTimer = countdownTimer- 1;

        countdownText.text = countdownTimer.ToString();

        if(countdownTimer <=10)
        {
            SoundManager.instance.TimeRunningOut(true);
        }

        StartCoroutine("CountDown");

        if(countdownTimer <=0)
        {
            StopCoroutine("CountDown");

            SoundManager.instance.GameEnd();
            SoundManager.instance.TimeRunningOut(false);

            StartCoroutine(RestartGame());
        }
    }

    public void DisplayScore(int scoreValue)
    {
        if (scoreText == null)
            return;

            ScoreCount += scoreValue;
            scoreText.text = "$ " + ScoreCount;

            scoreFillUI.fillAmount = (float)ScoreCount / 100f;    //98/100 = 0.98

            if(ScoreCount >=100)
            {
                StopCoroutine("CountDown");
                SoundManager.instance.GameEnd();
                StartCoroutine(RestartGame());
        
            }
        
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }
}
