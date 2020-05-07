﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int stage = 1;
    public static int level =1;
    public TextMeshPro answerText;
    public Sprite[] ships; 
    private List<int> key = new List<int>();
    private List<string> question=new List<string>();
    private Dictionary<int,string> dict=new Dictionary<int, string>();
    public EnemyScript enemy;
    public AnswerHandler answerHandler;
    public List<Transform> posisi; 
    public Bullet bullet;
    private bool isGeneratedAll=false;
    public GameObject gameOverView;
    public GameObject pauseGameView;
    public static bool isGameOver=false;
    public TextMeshPro gameStatus;
    public TextMeshPro finalScore;
    public static int scoring;
    public static int destroyedEnemy;
    void Start()
    { 
       InitStageAndLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(AnswerHandler.enemiesStatic.Count==0&&isGeneratedAll){
            Debug.Log("End Game");
            gameOver();    
        }else if(isGameOver){
            gameOver();
            isGeneratedAll=false;
        }
    }

    private void gameOver(){
        gameOverView.SetActive(true);
        if(isGameOver){
            gameStatus.text="Game Over";
            finalScore.text="Your Score : "+scoring;      
        }else{
            gameStatus.text="Stage Clear";
            finalScore.text="Your Score : "+scoring; 
        }
    }

    public void ShotAnswer(){
        if(answerText.text!=""){
            if(AnswerHandler.enemiesStatic.ContainsKey(int.Parse(answerText.text))){
                var enm=AnswerHandler.enemiesStatic[int.Parse(answerText.text)];
                Vector3 diff = enm.transform.position - transform.position;
                diff.Normalize(); 
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                var gObject = Instantiate(bullet,transform.position,Quaternion.identity);
                gObject.target=enm.transform;
                gObject.targetKey=int.Parse(answerText.text);
            }
            else{
                Debug.Log("Kamu nembak apa? :v");
            }
        }
        answerText.text="";
    }

    private void InitStageAndLevel(){
          switch (stage)
        {
            case 1:
            //.generate for Grade 1
            gameObject.GetComponent<SpriteRenderer> ().sprite =ships[0];
            break;
            case 2:
            //.generate for Grade 2
            gameObject.GetComponent<SpriteRenderer> ().sprite =ships[1];
            break;
            case 3:
            //.generate for Grade 3
            gameObject.GetComponent<SpriteRenderer> ().sprite =ships[2];
            break;
            default:
            //.generate for endless mode
            break;
        }
        StartCoroutine(playerMoving());
        
    }

    private void QuestionGenerator(){
        AnswerHandler.enemiesStatic.Clear();
        var enemiesCount= GameConfig.enemiesPerLevel[stage-1,level-1];
        if(stage==1){
            for(int i =0;i<enemiesCount;i++){
                if(i%2==0){
                    plusGenerator(0,20);
                }else{
                    minusGenerator(0,20);
                }
            }
        }else if(stage==2){
            for(int i =0;i<enemiesCount;i++){

                plusGenerator(0,20);
            }
        }else if(stage==3){
             for(int i =0;i<enemiesCount;i++){
                plusGenerator(0,20);
            }
        }
        StartCoroutine(spawnEnemy());
        
    }
    private void plusGenerator(int lowest, int highest){
        int a=Random.Range(lowest,highest);
        int b=Random.Range(lowest,highest);
        var rnd=a+b;
        while(dict.ContainsKey(rnd)||rnd>highest){
             a=Random.Range(lowest,highest);
             b=Random.Range(lowest,highest);
             rnd=a+b;
        }
        dict.Add(rnd,a+"+"+b);
        Debug.Log("added : "+rnd);
        
    } 
    private void minusGenerator(int lowest, int highest){
        int a=Random.Range(lowest,highest);
        int b=Random.Range(lowest,highest);
        var rnd=a-b;
        while(dict.ContainsKey(rnd)||rnd<0){
             a=Random.Range(lowest,highest);
             b=Random.Range(lowest,highest);
             rnd=a-b;
        }
        dict.Add(rnd,a+"-"+b);
        Debug.Log("added : "+rnd);
    }
    private void multipleGenerator(int lowest, int highest){
        int a=Random.Range(lowest,highest);
        int b=Random.Range(lowest,highest);
        var rnd=a*b;
        while(dict.ContainsKey(rnd)||rnd>highest){
             a=Random.Range(lowest,highest);
             b=Random.Range(lowest,highest);
             rnd=a*b;
        }
        dict.Add(rnd,a+"x"+b);
        Debug.Log("added : "+rnd);
    }
    private void divideGenerator(int lowest, int highest){
         int a=Random.Range(lowest,highest);
        int b=Random.Range(lowest,highest);
        var rnd=a/b;
        while(dict.ContainsKey(rnd)||rnd>highest){
             a=Random.Range(lowest,highest);
             b=Random.Range(lowest,highest);
             rnd=a/b;
        }
        dict.Add(rnd,a+":"+b);
        Debug.Log("added : "+rnd);
    }

    private IEnumerator playerMoving(){
        for(int i =0; i<=100;i++){
        transform.position = Vector3.MoveTowards(transform.position,
                            new Vector3(0.0f,-2.2f,0.0f),10*Time.deltaTime);
        yield return new WaitForSeconds(0.00001f);
        }
        QuestionGenerator();
    }

    private IEnumerator spawnEnemy(){
         foreach(var data in dict){
            var rnd=Random.Range(0,3);
            var position=new Vector3(Random.Range(posisi[0].position.x,posisi[1].position.x),posisi[0].position.y);
            var gObject = Instantiate(enemy,position,Quaternion.identity);
            gObject.thisKey=data.Key;
            gObject.enemyScore=10;
            gObject.enemyType=rnd;
            AnswerHandler.enemiesStatic.Add(data.Key,gObject.gameObject);
            gObject.GetComponentInChildren<TextMeshPro>().text=data.Value;
            yield return new WaitForSeconds(2f);
        }
        isGeneratedAll=true;
    }
}
