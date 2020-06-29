using System.Collections;
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

    public BossScript boss;
    bool switcing=false;

    public AnswerHandler answerHandler;
    public List<Transform> posisi; 
    public Bullet bullet;
    public GameObject bgObject;
    private bool isGeneratedAll=false;
    public GameObject gameOverView;
    public GameObject pauseGameView;
    public static bool isGameOver=false;
    public TextMeshPro gameStatus;
    public TextMeshPro finalScore;
    public static int scoring;
    public static int destroyedEnemy;
    public static bool isDestroy=false;
    public Button btnMenu;
    public Button btnRestart;
    BackgroundMove backgroundMove;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    GameObject BossObject;
    BossScript bossScriptObject;
    public GameObject[] starsObject;
    Color[] colors = {Color.black,Color.black,Color.yellow};

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
        float destroyed= (float)destroyedEnemy;
        GamePlayConfig.scoring=scoring;
        GamePlayConfig.destroyed=destroyed;
        gameStatus.color=colors[stage-1];
        finalScore.color=colors[stage-1];
        handleClick();
        audioSource.Stop();
        if(isGameOver){
            audioSource.clip = audioClips[3];
            audioSource.Play();
            }
        else{
            Debug.Log("ora gem over");
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
        if(isGameOver){
            isDestroy=true;
            GamePlayConfig.isDestroy=true;
            gameStatus.color=colors[stage-1];
            gameStatus.text="GAME OVER";
            finalScore.text="Your Score : "+scoring;      
        }else{
            isDestroy=false;
            GamePlayConfig.isDestroy=false;
            gameStatus.text="STAGE CLEAR";
            finalScore.text="Your Score : "+scoring;
            float allEnemies=(float)GameConfig.enemiesPerLevel[stage-1,level-1];
            var stars = ScoreConverter.getStarsFromScore(allEnemies,destroyed);
            showStars(stars);
        }
    }

    private void showStars(int stars){
        for (int i = 0; i < stars; i++)
        {
            starsObject[i].SetActive(true);
        }
    }


    public void ShotAnswer(){
        if(answerText.text!=""){
            if(AnswerHandler.enemiesStatic.ContainsKey(int.Parse(answerText.text))){
                audioSource.Stop();
                if(level<=5){
                    audioSource.clip = audioClips[0];
                    audioSource.Play();
                    var enm=AnswerHandler.enemiesStatic[int.Parse(answerText.text)];
                    Debug.Log(enm.gameObject.name);
                    Vector3 diff = enm.transform.position - transform.position;
                    diff.Normalize(); 
                    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                    var gObject = Instantiate(bullet,transform.position,Quaternion.identity);
                    gObject.target=enm.transform;
                    gObject.targetKey=int.Parse(answerText.text);
                }
                else{
                    if(BossObject.GetComponent<BossScript>().thisKey == int.Parse(answerText.text)){
                        audioSource.clip = audioClips[0];
                        audioSource.Play();
                        var enm=AnswerHandler.enemiesStatic[int.Parse(answerText.text)];
                        Debug.Log(enm.gameObject.name);
                        Vector3 diff = enm.transform.position - transform.position;
                        diff.Normalize(); 
                        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                        var gObject = Instantiate(bullet,transform.position,Quaternion.identity);
                        gObject.target=enm.transform;
                        gObject.targetKey=int.Parse(answerText.text);
                    }
                }

            }
            else{
                Debug.Log("Kamu nembak apa? :v");
            }
        }
        answerText.text="";
    }

    private void InitStageAndLevel(){
        backgroundMove=(BackgroundMove)bgObject.GetComponent(typeof(BackgroundMove));
        backgroundMove.changeBg();
        scoring=0;
        isGeneratedAll=false;
        isGameOver=false;
        destroyedEnemy=0;
        switch (GamePlayConfig.stage)
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
            for(int i=0;i<enemiesCount;i++){
                if(i%2==0){
                    multipleGenerator(1,10);
                 }else{
                    divideGenerator(1,100);
                }
            }
        }else if(stage==3){
             for(int i =0;i<enemiesCount;i++){
                if(i%2==0){
                    if(switcing){
                        plusGenerator(0,50);
                        switcing=!switcing;
                    }else{
                        multipleGenerator(1,10);
                        switcing=!switcing;
                    }
                 }else{
                     if(switcing){
                        minusGenerator(0,50);
                        switcing=!switcing;
                    }else{
                        divideGenerator(1,100);
                        switcing=!switcing;
                    }
                }
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
        while(dict.ContainsKey(rnd)||rnd>100){
             a=Random.Range(lowest,highest);
             b=Random.Range(lowest,highest);
             rnd=a*b;
        }
        dict.Add(rnd,a+"x"+b);
        Debug.Log("added : "+rnd);
    }
    private void divideGenerator(int lowest, int highest){
        float a=(float) Random.Range(lowest,highest);
        float b=(float) Random.Range(1,10);
        float rnd=a/b;
        string rndString=rnd.ToString();
        int nmbr=0;
        while(dict.ContainsKey((int)rnd)||b>a||rnd>10||!int.TryParse(rndString , out nmbr)){
             a=(float) Random.Range(lowest,highest);
             b=(float) Random.Range(1,10);
             rnd=a/b;
             rndString=rnd.ToString();
        }
        dict.Add((int)rnd,a+":"+b);
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
        if(level<=5){
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
        }else{
            foreach(var data in dict){
                AnswerHandler.enemiesStringStatic.Add(data.Key,data.Value);
            }
            var position=new Vector3(0,15f);
            var gObject =Instantiate(boss,position,Quaternion.identity);
            BossObject=gObject.gameObject;
            foreach(var data in dict){
                AnswerHandler.enemiesStatic.Add(data.Key,BossObject);
                yield return new WaitForSeconds(0.1f);
            }
        }
        isGeneratedAll=true;
    }

    void handleClick(){
        btnMenu.gameObject.SetActive(true);
    }

    public void restartLevel(){
        if(!isDestroy){
        btnRestart.gameObject.SetActive(false);
        btnMenu.gameObject.SetActive(false);
        gameOverView.SetActive(false);
        InitStageAndLevel();
        }
    }

    public void saveScoreBackToMenu(){
        if(!isDestroy){
        var oldScore= PlayerPrefs.GetInt(GameConfig.PLAYER_SCORE_PREF);
        PlayerPrefs.SetInt(GameConfig.PLAYER_SCORE_PREF,(oldScore+scoring));
        float destroyed= (float)destroyedEnemy;
        float allEnemies=(float)GameConfig.enemiesPerLevel[stage-1,level-1];
        var stars = ScoreConverter.getStarsFromScore(allEnemies,destroyed);
        PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[stage-1,level-1],stars);
        if(level<=5){
            PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL[stage-1,level], 1);
            PlayerPrefs.Save();
        }else{
            PlayerPrefs.SetInt(GameConfig.PREF_STAGE[stage], 1);
            PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL[stage,0], 1);
            PlayerPrefs.Save();
        }
        }
    }
}
