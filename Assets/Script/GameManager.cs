using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int life;
    public GameObject ballPrefab;
    public Text textGameOver;
    private int score;
    private float leftTime;
    private Text textScore;
    private Text textLife;
    private Text textTimer;
    private bool inGame;
    public Text textClear;
    static int highScore = 0;

    public float T;

    private Text textResult;
    private Text textResultBall;
    private Text textResultTime;
    private Text textResultTotal;
    private Text textHighScore;
    public GameObject nextSceneButton;

    private AudioSource audioSource;
        public AudioClip overSound;
        public AudioClip killSound;
        public AudioClip clearSound;

    void Start() {
        Time.timeScale = T;
        life = 3;
        textGameOver.enabled = false;
        textClear.enabled = false;
        nextSceneButton.SetActive(false);

        score = 0;
        leftTime = 30f;
        audioSource = gameObject.AddComponent<AudioSource>();
        textScore = GameObject.Find("Score").GetComponent<Text>();
        textLife = GameObject.Find("BallLife").GetComponent<Text>();
        textTimer = GameObject.Find("TimeText").GetComponent<Text>();

        textResult = GameObject.Find("Result Score").GetComponent<Text>();
        textResultBall = GameObject.Find("Result Ball").GetComponent<Text>();
        textResultTime = GameObject.Find("Result Time").GetComponent<Text>();
        textResultTotal = GameObject.Find("Result Total").GetComponent<Text>();
        textHighScore = GameObject.Find("HighScore").GetComponent<Text>();

        SetScoreText(score);
        SetLifeText(life);
        SetHighScoreText(highScore);    //ハイスコア表示

        inGame = true;

    }

    private void SetScoreText(int score) {
        textScore.text = "Score:" + score.ToString();
    }

    private void SetLifeText(int life){
        textLife.text = "Ball:" + life.ToString(); 
    }

    private void SetHighScoreText(int highScore)
    {
        textHighScore.text = "High Score :" + highScore.ToString();
    }

    public void Replay()
    {
        // SceneManager.LoadScene("pinballtest");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("pinball-start");    //スタート画面に戻る
    }

    public void AddScore(int point){
        if (inGame){
            score += point;
            SetScoreText(score);
        }
    }

    public void NextScene()
    {
        Scene scene = SceneManager.GetActiveScene();    //現在のシーンを受け取ります
        int i = scene.buildIndex;   //現在のシーンのindexナンバーを受け取ります
        i++;
        int j = SceneManager.sceneCountInBuildSettings; //BuildSettingに登録されているシーン数を受け取ります
        if(j - i > 0)
        {
            SceneManager.LoadScene(i);  //次のシーンに進む
        }
    }

    public bool IsIngame()
    {
        return inGame;
    }

    void Update () {
        if (inGame){
            leftTime -= Time.deltaTime / T;
            textTimer.text = "Time :" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");
            if (leftTime < 0f){
                audioSource.PlayOneShot(overSound);
                textGameOver.enabled = true;
                inGame = false;
            }


            GameObject ballObj = GameObject.Find("Ball");
             if (ballObj == null){
            --life;
            SetLifeText(life);
                if (life > 0){
                    audioSource.PlayOneShot(killSound);
                    GameObject newBall = Instantiate(ballPrefab);
                    newBall.name = ballPrefab.name;
                }
                else{
                    life = 0;
                    audioSource.PlayOneShot(overSound);
                    textGameOver.enabled = true;
                    inGame = false;
                }
            }
            GameObject targetObj = GameObject.FindWithTag("Target");
            if(targetObj == null){
                audioSource.PlayOneShot(clearSound);
                textClear.enabled = true;
                nextSceneButton.SetActive(true);

                int scorePoint = score * 50;            //スコア計算
                int scoreBall = life * 1000;            //スコア計算
                int scoreTime = (int)(leftTime * 100f); //小数値を整数型に直します(int)　スコア計算
                textResult.text = "Score * 50 = " + scorePoint.ToString();          //表示
                textResultBall.text = "Ball * 1000 = " + scoreBall.ToString();      //表示
                textResultTime.text = "Time * 100 = " + scoreTime.ToString();       //表示

                int totalScore = scorePoint + scoreBall + scoreTime;                //トータル計算
                textResultTotal.text = "Total Score : " + totalScore.ToString();    //表示

                if(highScore < totalScore)      //ハイスコアを上回っていたら
                {
                    highScore = totalScore;     //更新
                }
                inGame = false;
            }
        }
	}
}
