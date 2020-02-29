using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainScript : MonoBehaviour
{
    
    public mainBalls mWhite;
    public mainBalls mGreen;
    public mainBalls sWhite;
    public mainBalls sGreen;
    public Text scoreText;
    public Text topScoreText;
    public int initialSpeed;
    

    public GameObject gameOver;
    int score = 0;

    bool lost = false;
    bool moving = false;

    float minH;
    Vector3 mainPos;
    Vector3 hideUp;
    Vector3 hideDown;
    Vector3 hide1;
    Vector3 hide2;
    
    // Start is called before the first frame update
    void Start()
    {
        initGame();
    }
        

    public void initGame(){
        gameOver.SetActive(false);
        score = 0;
        scoreText.text = score+"";
        sWhite.speed = initialSpeed;
        sGreen.speed = initialSpeed;
        lost = false;
        moving = false;
        minH = Mathf.Abs(mWhite.transform.position.y);
        mainPos = new Vector3(0,-0.6f, sWhite.transform.position.z);
        hideUp = new Vector3(0,-7,sWhite.transform.position.z);
        hideDown = new Vector3(0,7,sWhite.transform.position.z);
        hide1 = new Vector3(-10,-20,sWhite.transform.position.z);
        hide2 = new Vector3(10,-20,sWhite.transform.position.z);
        System.Random rnd = new System.Random();
        int i = rnd.Next(2);
        HideBalls(i);
        sWhite.gameDelegate = this;
        sGreen.gameDelegate = this;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(lost)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        //if (Input.touchCount > 0)
        {
            FlipCircles();
        }
    }

    public void Win()
    {
        moving = false;
        sWhite.speed+=0.05f;
        sGreen.speed+=0.05f;
        score++;
        System.Random rnd = new System.Random();
        int i = rnd.Next(50);
        HideBalls(i);
        scoreText.text = score+"";
        Debug.Log("WIN!!");
    }

    public void Lose()
    {
        lost = true;
        if(PlayerPrefs.GetInt("TopScore") == null || PlayerPrefs.GetInt("TopScore") < score){
                    PlayerPrefs.SetInt("TopScore", score);
        }
        topScoreText.text = PlayerPrefs.GetInt("TopScore")+"";
        gameOver.SetActive(true);
        
        Debug.Log("LOSE!!");
    }
    

    void MoveNextBall(int i)
    {
        
        if (!(lost || moving))
        {
            moving = true;
            if((i%2)==0)
             {
                sWhite.SetDestination(mainPos);
             }else{
                sGreen.SetDestination(mainPos);
             }
        }
        
    }

    void HideBalls(int i)
    {
        if(lost)
        {
            return;
        }
        Vector3 hide;
        if (i > 25)
        {
            hide = hideUp;
        }else{
            hide = hideDown;
        }
        if((i%2) == 0)
        {
            sWhite.transform.position = hide;
            sGreen.transform.position = hide2;
            sGreen.SetDestination(Vector3.zero);
        }else{
            sWhite.transform.position = hide1;
            sWhite.SetDestination(Vector3.zero);
            sGreen.transform.position = hide;
        }
        MoveNextBall(i);    
    }

    void FlipCircles()
    {
        float y1 = mWhite.transform.position.y > 0 ? (minH*-1) : minH;
        
        Vector3 pos1 = new Vector3(0, -y1, mGreen.transform.position.z) ;
        Vector3 pos2 = new Vector3(0, y1, mWhite.transform.position.z) ;
        
        mWhite.SetDestination(pos2);
        mGreen.SetDestination(pos1);
    }
}
