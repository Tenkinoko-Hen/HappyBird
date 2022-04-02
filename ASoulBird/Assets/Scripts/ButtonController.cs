using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button playBtn;
    // Start is called before the first frame update
   public void playGame()
    {
        GameState.instance.GameStart = GameState.G_State.InGame;
    }


    public void Restart()
    {
        PipelineManage.instance.init();
        GameState.instance.GameStart = GameState.G_State.Ready;
        PlayerC.instance.p_init();
   
    }
}
