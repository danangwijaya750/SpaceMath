using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnswerHandler : MonoBehaviour
{
    public TextMeshPro answerText;
    public static Dictionary<int,GameObject> enemiesStatic = new Dictionary<int,GameObject>();
    public static Dictionary<int,string> enemiesStringStatic = new Dictionary<int, string>(); 
    public static int scoreCount=0;
    public Button buttonShot,button1,button2,button3,button4,button5,button6,button7,button8,button9,button0;
    public Sprite[] buttonSprites;  
    Color[] colors = {Color.black,Color.black,Color.yellow};
    //public static int[,] levelConfig=new int{5,10,};

    // Start is called before the first frame update
    void Start()
    {
        initColor();
    }
    private void initColor(){
        var stage = GamePlayConfig.stage;
        buttonShot.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button1.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button2.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button3.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button4.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button5.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button6.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button7.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button8.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button9.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        button0.GetComponent<Image>().sprite=buttonSprites[stage - 1];
        buttonShot.GetComponentInChildren<Text>().color=colors[stage - 1];
        button1.GetComponentInChildren<Text>().color=colors[stage - 1];
        button2.GetComponentInChildren<Text>().color=colors[stage - 1];
        button3.GetComponentInChildren<Text>().color=colors[stage - 1];
        button4.GetComponentInChildren<Text>().color=colors[stage - 1];
        button5.GetComponentInChildren<Text>().color=colors[stage - 1];
        button6.GetComponentInChildren<Text>().color=colors[stage - 1];
        button7.GetComponentInChildren<Text>().color=colors[stage - 1];
        button8.GetComponentInChildren<Text>().color=colors[stage - 1];
        button9.GetComponentInChildren<Text>().color=colors[stage - 1];
        button0.GetComponentInChildren<Text>().color=colors[stage - 1];
        answerText.color=colors[stage-1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btn0_click(){
        answerText.text+="0";
    }

    public void btn1_click(){
        answerText.text+="1";
    }

    public void btn2_click(){
        answerText.text+="2";
    }

    public void btn3_click(){
        answerText.text+="3";
    }

    public void btn4_click(){
        answerText.text+="4";
    }

    public void btn5_click(){
        answerText.text+="5";
    }

    public void btn6_click(){
        answerText.text+="6";
    }

    public void btn7_click(){
        answerText.text+="7";
    }

    public void btn8_click(){
        answerText.text+="8";
    }
  
    public void btn9_click(){
        answerText.text+="9";
    }
}
