using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI FinishScore;
    public TextMeshProUGUI HighestScore;
    public TextMeshProUGUI truetextanim;
    public TextMeshProUGUI showtruetext;


    public Image fadeImage;
    private Blade blade;
    private Spawner spawner;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject QuestionPanel;

    [SerializeField] Button PlayAgainButton;
    [SerializeField] Button Buton1;
    [SerializeField] Button Buton2;

    public Questions questions;
    private int score;

    public int turnnumber;
    private int highscore;

    [SerializeField] public float timeRemaining = 60;

    bool timesover = false;
    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        NewGame();
    }

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }
    private void NewGame()
    {
        Time.timeScale = 1f;
        timeRemaining = 60f;
        blade.enabled = true;
        spawner.enabled = true;
        timesover = false;
        GameOverPanel.SetActive(false);
        FinishScore.gameObject.SetActive(false);
        HighestScore.gameObject.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
        //scoreText.GetComponent<Animator>().enabled = false;


    }
    void Update()
    {
        Debug.Log(Time.timeScale);
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int iValue = (int)timeRemaining;
            TimeText.text = iValue.ToString();
        }
        else
        {
            if(!timesover)
            {
                StartCoroutine(ExplodeSequence());

            }
        }

        if(Time.timeScale > 1f)
        {
            StartCoroutine(resetTime());
        }
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit f in fruits)
        {
            Destroy(f.gameObject);
        }

        Bomb[] bomb = FindObjectsOfType<Bomb>();

        foreach (Bomb b in bomb)
        {
            Destroy(b.gameObject);
        }
        AddTime[] timeobject = FindObjectsOfType<AddTime>();

        foreach (AddTime b in timeobject)
        {
            Destroy(b.gameObject);
        }

        SpeedBoost[] speedobject = FindObjectsOfType<SpeedBoost>();

        foreach (SpeedBoost b in speedobject)
        {
            Destroy(b.gameObject);
        }
    }
    public void IncreaseScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;

            PlayerPrefs.SetInt("highscore", highscore);
        }

    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }
   

    public void Question()
    {
        Vibrator.Vibrate(100);

        blade.enabled = false;
        spawner.enabled = false;
        QuestionPanel.SetActive(true);
        Time.timeScale = 0f;

        Dictionary<string, int> dict = questions.BeginnerQuesitons();
        turnnumber = Random.Range(0, 2);
        if(turnnumber == 0)
        {

            TextMeshProUGUI text1 = QuestionPanel.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>(); /*temp.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();*/

            var randomKey = dict.Keys.ToArray()[(int)Random.Range(0, dict.Keys.Count - 1)];
            var randomValueFromDictionary = dict[randomKey]; // Answer

            QuestionText.text = randomKey.ToString();
            text1.text =  randomValueFromDictionary.ToString();

            //text1.text = dict["2+2"].ToString(); //" 2 + 2 = ?";
            TextMeshProUGUI text2 = QuestionPanel.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
            //text2.text = " 2 + 2 = ?";

            //var randomKey2 = dict.Keys.ToArray()[(int)Random.Range(0, dict.Keys.Count - 1)];
            //var randomValueFromDictionary2 = dict[randomKey2]; // Answer
            int randomnumber = Random.Range(0, randomValueFromDictionary - 1);
            if (randomnumber == randomValueFromDictionary)
            {
                randomnumber += 10;
            }
            text2.text = randomnumber.ToString();
            
        }
        else
        {
            TextMeshProUGUI text1 = QuestionPanel.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI text2 = QuestionPanel.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();

            var randomKey = dict.Keys.ToArray()[(int)Random.Range(0, dict.Keys.Count - 1)];
            var randomValueFromDictionary = dict[randomKey]; // Answer
            QuestionText.text = randomKey.ToString();

            text2.text = randomValueFromDictionary.ToString();

            //text1.text = dict["2+2"].ToString(); //" 2 + 2 = ?";
            //text2.text = " 2 + 2 = ?";

            //var randomKey2 = dict.Keys.ToArray()[(int)Random.Range(0, dict.Keys.Count - 1)];
            //var randomValueFromDictionary2 = dict[randomKey2]; // Answer
            int randomnumber = Random.Range(0, randomValueFromDictionary - 1);
            if (randomnumber == randomValueFromDictionary)
            {
                randomnumber += 10;
            }
            text1.text =  randomnumber.ToString();
            
        }

        //Button btn = Buton2.GetComponent<Button>();

        //btn.onClick.AddListener(Button2_click);

        //Button btn1 = Buton1.GetComponent<Button>();

        //btn1.onClick.AddListener(Button1_click);
    }

    public void Button1_click()
    {
        if(turnnumber == 0)
        {
            int t = 5;
            Time.timeScale = 1f;

            score += 50;
            scoreText.text = score.ToString();

            timeRemaining = timeRemaining +t;
            blade.enabled = true;
            spawner.enabled = true;
            QuestionPanel.SetActive(false);

            truetextanim.gameObject.SetActive(true);
            StartCoroutine(resettrueanim());
        }
        else
        {
            Time.timeScale = 1f;
            StartCoroutine(ExplodeSequence());

            QuestionPanel.SetActive(false);
            blade.enabled = true;
            spawner.enabled = true;
        }
    }
    public void Button2_click()
    {
        if (turnnumber == 0)
        {
            Time.timeScale = 1f;

            QuestionPanel.SetActive(false);
            blade.enabled = true;
            spawner.enabled = true;
            //Vibrator.Vibrate(400);
            StartCoroutine(ExplodeSequence());


        }
        else
        {
            int t = 5;

            Time.timeScale = 1f;
            timeRemaining = timeRemaining + t;

            score += 50;
            scoreText.text = score.ToString();


            blade.enabled = true;
            spawner.enabled = true;
            QuestionPanel.SetActive(false);
            
            //GameObject timer = Instantiate(truetextanim.gameObject, truetextanim.gameObject.transform.position, timerrotation);
            
            truetextanim.gameObject.SetActive(true);
            StartCoroutine(resettrueanim());
            //Destroy(timer, 5);
        }
    }

    IEnumerator resettrueanim()
    {
        showtruetext.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        truetextanim.gameObject.SetActive(false);
        showtruetext.gameObject.SetActive(false);

    }
    private IEnumerator ExplodeSequence()
    {
        Vibrator.Vibrate(1000);
        timesover = true;
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear,Color.white,t);

            Time.timeScale = 1f - t;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        //NewGame();
        ClearScene();

        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);


            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        //scoreText.GetComponent<Animator>().enabled = true;
        FinishScore.gameObject.SetActive(true);
        HighestScore.gameObject.SetActive(true);
        FinishScore.text =  "Score: "+ scoreText.text;
        HighestScore.text = "Highest Score: " + PlayerPrefs.GetInt("highscore", highscore).ToString();
        GameOverPanel.SetActive(true);
       
        Button btn = PlayAgainButton.GetComponent<Button>();

        btn.onClick.AddListener(GameOver);
    }

    private void GameOver()
    {
        NewGame();
    }

    private IEnumerator resetTime()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
    }
}
