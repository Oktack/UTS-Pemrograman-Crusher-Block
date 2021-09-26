using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public int force;
    public Text scoreText;
    private int score;
    private int Lose;
    Rigidbody2D rb2d;
    GameObject panelWin;
    GameObject panelLose;
    GameObject panelPause;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 instruction = new Vector2(0, -force).normalized;
        rb2d.AddForce(instruction * force);
        score = 0;
        SetScoreText();
        Lose = 1;

        panelWin = GameObject.Find("PanelWin");
        panelWin.SetActive(false);

        panelLose = GameObject.Find("PanelLose");
        panelLose.SetActive(false);

        panelPause = GameObject.Find("MenuPause");
        panelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Down")
        {
            Vector2 instruction = new Vector2(0, -force).normalized;
            rb2d.AddForce(instruction * force);
            Lose -= 1;
            if (Lose == 0)
            {
                Destroy(gameObject);
                panelLose.SetActive(true);
                return;
            }
        }
        if (coll.gameObject.name == "Paddle")
        {
            float corner = (transform.position.x - coll.transform.position.x) * 5f;
            Vector2 instruction = new Vector2(corner, rb2d.velocity.y).normalized;
            rb2d.velocity = new Vector2(0, 0);
            rb2d.AddForce(instruction * force * 2);
        }
        if (coll.gameObject.CompareTag("CubeYellow"))
        {
            coll.gameObject.SetActive(false);
            score = score + 10;
            SetScoreText();
        }
        if (coll.gameObject.CompareTag("CubeRed"))
        {
            coll.gameObject.SetActive(false);
            score = score + 8;
            SetScoreText();
        }
        if (coll.gameObject.CompareTag("CubeGreen"))
        {
            coll.gameObject.SetActive(false);
            score = score + 5;
            SetScoreText();
        }
        if (coll.gameObject.CompareTag("CubePurple"))
        {
            coll.gameObject.SetActive(false);
            score = score + 3;
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
        if (score >= 100)
        {
            Destroy(gameObject);
            panelWin.SetActive(true);
            return;
        }
    }
}
