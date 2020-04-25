using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnswerHandler : MonoBehaviour
{
    public TextMeshPro answerText;
    public static Dictionary<int,GameObject> enemiesStatic = new Dictionary<int,GameObject>();
    public static int scoreCount=0;
    //public static int[,] levelConfig=new int{5,10,};

    // Start is called before the first frame update
    void Start()
    {
       
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
