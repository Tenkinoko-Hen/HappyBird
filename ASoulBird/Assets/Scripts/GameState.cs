using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public GameObject reayPanel;
    public GameObject pointPanel;
    public GameObject gameOverPanel;

    private int G_Point;
    public Text G_PointText;
    public Text G_NowText;
    public Text G_EndText;

    public int GP
    {
        get { return G_Point;}
        set
        {
            this.G_Point = value;
            this.G_PointText.text = G_Point.ToString();

        }
    }
    public enum G_State
    {
        Ready,
        InGame,
        GameOver
    }
    public G_State gameStart_Choose;
    
    public G_State GameStart
    {
        get { return gameStart_Choose; }
        set { this.gameStart_Choose = value;
            this.UpdateUI();
        }

    }

    private void Awake()
    {
        GameStart = G_State.Ready;
        instance = this;
        UpdateUI();
        PlayerC.instance.OnDeath += Player_OnDeath;
        PlayerC.instance.OnGP = OnPlayerGP;
    }

    void OnPlayerGP(int GP)
    {
        this.GP += GP;
    }

    private void Player_OnDeath()
    {
        this.GameStart = G_State.GameOver;
    }

 public void UpdateUI()
    {
        switch (GameStart)
        {

            case G_State.Ready:
                ReadyState();
                break;
            case G_State.InGame:
                InGameyState();
                break;
            case G_State.GameOver:
                GameOverState();
                break;


        }

        gameOverPanel.SetActive(GameStart==G_State.GameOver);
        reayPanel.SetActive(GameStart == G_State.Ready);
        pointPanel.SetActive(GameStart == G_State.InGame);
    }
    private void endPoint()
    {
        G_NowText.text = G_Point.ToString();


            if (G_Point > PlayerPrefs.GetInt("Normal_Point"))
            {
                PlayerPrefs.SetInt("Normal_Point", G_Point);
                G_EndText.text = PlayerPrefs.GetInt("Normal_Point").ToString();
              
            }
            else
            {
                G_EndText.text = PlayerPrefs.GetInt("Normal_Point").ToString();
            }


        
    }

    private void  ReadyState()
    {
        G_Point = 0;
        PlayerC.instance.Idel();

    }

    public void InGameyState()
    {
      

    
        //开始生成管道
        PipelineManage.instance.StartPipeline();
        //切换飞行状态
        PlayerC.instance.fly();
        //隐藏游戏面板
   

    }

    public void GameOverState()
    {

        this.G_PointText.text = "0";
        endPoint();
        //停止生成管道
        PipelineManage.instance.StopPipeline();
      

    }

}
