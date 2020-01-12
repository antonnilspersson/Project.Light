using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialText : MonoBehaviour
{
    public Text text;
    public string[] strings;
    float timer = 0;
    float fTimeInterval = 3;
    float tTimeInterval = 1;

    float startTimer = 0;
    float startInterval = 2;

    int i = 0;

    Color color;
    float alpha;

    bool fadeIn = true;
    bool done = false;
    bool noPos = false;

    bool startGame = false;

    void Start()
    {
        text.text = "";
        color = text.color;
        color.a = 0;
    }

    void Update()
    {
        text.text = strings[i];

        startTimer += Time.deltaTime;

        


        if (!done)
        {
            if (fadeIn)
                FadeIn();
            else
                FadeOut();
        }

        if(done || Input.GetKeyDown(KeyCode.Return))
            startGame = true;

        if (startGame)
        {
            SceneManager.LoadScene("LoadingScreen");
        }

    }

    void FadeIn()
    {
        if(!noPos)
        {
            text.rectTransform.localPosition = new Vector2(Random.Range(-500, 500), Random.Range(-300, 300));
            noPos = true;
        }

        color.a += Time.deltaTime;
        text.color = color;

        if (text.color.a >= 1)
        {
            color.a = 1;

            timer += Time.deltaTime;

            if (timer >= fTimeInterval)
            {
                fadeIn = false;
                timer = 0;
            }
        }
    }

    void FadeOut()
    {
        color.a -= Time.deltaTime / 3;
        text.color = color;
        if (text.color.a <= 0)
        {
            color.a = 0;

            timer += Time.deltaTime;
            if(timer >= tTimeInterval)
            {
                fadeIn = true;
                timer = 0;

                if (i == strings.Length - 1)
                    done = true;
                else
                {
                    i += 1;
                    noPos = false;
                }

            }
        }
    }

    void RandomPos(float x, float y)
    {
    }
}
