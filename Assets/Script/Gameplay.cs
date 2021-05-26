using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gameplay : MonoBehaviour
{
    public Slider timer;
    public Text total_score;
    public static int score;
    public static bool endGame = false;
    public static int liveTime = 0;
    public Canvas Live, Death_;
    public Text Score, BestScore, LiveTime, BestLiveTime;
    public GameObject TargetObj;
    private Mover _actionTarget;
    void Start()
    {
        _actionTarget = TargetObj.GetComponent<Mover>();
        score = 0;
        StartCoroutine(Timer());
        Live.gameObject.SetActive(true);
        Death_.gameObject.SetActive(false);
    }

    
    void Update()
    {
        total_score.text = "Score: " + score;
        Death();
        if (PlayerPrefs.GetInt("score")<score)
        {
            PlayerPrefs.SetInt("score", score);
        }
        if (PlayerPrefs.GetInt("livetime") < liveTime)
        {
            PlayerPrefs.SetInt("livetime", liveTime);
        }
        
        //PlayerPrefs.SetInt( "score", score);
        //PlayerPrefs.SetInt("livetime", liveTime);
    }
    void Death()
    {
        if (timer.value <= 0)
        {
            endGame = true;
            Score.text = "Your score: " + score;
            BestScore.text = "Your best score: " + PlayerPrefs.GetInt("score");
            LiveTime.text = "Your live-time: " + liveTime +"s";
            BestLiveTime.text = "Your best live-time: " + PlayerPrefs.GetInt("livetime") + "s";
            Live.gameObject.SetActive(false);
            Death_.gameObject.SetActive(true);
            timer.gameObject.SetActive(false);
            total_score.gameObject.SetActive(false);
            _actionTarget.Starter();
        }
    }
    IEnumerator Timer()
    {
        while (!endGame)
        {
            yield return new WaitForSeconds(1f);
            timer.value -= 0.1f;
            liveTime++;
        }
        

    }
    public void Restart()
    {
        Live.gameObject.SetActive(true);
        Death_.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        total_score.gameObject.SetActive(true);
        timer.value = 1;
        score = 0;
        liveTime = 0;
        endGame = false;
        StartCoroutine(Timer());
        


    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ResetTimer()
    {
        timer.value = 1;
    }
}
