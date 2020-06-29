using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int thisKey;
    
    public int enemyScore;
    public int enemyType;
    public Sprite[] ships;
    private SpriteRenderer sprtRenderer;
    public TextMeshPro textMesh;
    double damage=0;
    int questionPos=0;
    double hp;
    int totalQuestion;
    private ParticleSystem exploder;
    Color[] colors = {Color.black,Color.yellow,Color.yellow};
    public Slider healthBar;
    public TextMeshPro textTimer;
    int maxHealth=100;
    bool isTimerActive=true;
    float timer = 150;
    int minute=0;
    int seconds=0;
    public GameObject enemy;
    public List<Transform> posisi;

    void Start()
    {
        var stage=PlayerScript.stage;
        sprtRenderer=gameObject.GetComponent<SpriteRenderer> ();
        sprtRenderer.sprite =ships[stage-1];
        exploder=gameObject.GetComponent<ParticleSystem>();
        totalQuestion=AnswerHandler.enemiesStringStatic.Count;
        damage=100/(double)totalQuestion;
        textMesh.color=colors[stage-1];
        textMesh.text="";
        textTimer.color=colors[stage-1];
        textTimer.text="";
        enemyScore=10;
        // sprtRenderer.size=new Vector2(1f,1f);
        //5.74
        initBoss();
    }
    private void initBoss(){
        hp=maxHealth;
        healthBar.value=(float)hp;
         //checkHP();
        StartCoroutine(bossMoving());
    }
    private IEnumerator bossMoving(){
        for(int i =0; i<=100;i++){
        transform.position = Vector3.MoveTowards(transform.position,
                            new Vector3(0.0f,5.5f,0.0f),10*Time.deltaTime);
        yield return new WaitForSeconds(0.00001f);
        }
        checkHP();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimerActive){
            if(timer>0){
                timer-=Time.deltaTime;
                minute=(int) timer/60;
                seconds=(int) timer%60;
                textTimer.text=minute.ToString("00") + ":" + seconds.ToString("00");;
            }else{
                isTimerActive=false;
            }
        }else{
            transform.position+=Vector3.down*Time.fixedDeltaTime;
        }
    }
      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bullet"){
            Debug.Log("metu enemy");
            Bullet bulletTarget  = other.gameObject.GetComponent<Bullet>();
            if(bulletTarget.targetKey==thisKey){
                AnswerHandler.enemiesStatic.Remove(thisKey);
                Destroy(other.gameObject);
                exploder.Play();
                textMesh.enabled=false;
                PlayerScript.scoring+=enemyScore;
                PlayerScript.destroyedEnemy+=1;
                hp-=damage;
                healthBar.value=(float)hp;
                Debug.Log("HP "+hp);
                checkHP();
            }
        }
        if(other.gameObject.tag=="Player"){
            Debug.Log("metu palyer");
            //sprtRenderer.enabled=false;
            textMesh.enabled=false;
            var playerExploder=other.gameObject.GetComponent<ParticleSystem>();
            var playerRenderer=other.gameObject.GetComponent<SpriteRenderer>();
            playerRenderer.enabled=false;
            playerExploder.Play();
            PlayerScript.isGameOver=true;
            Destroy(other.gameObject,playerExploder.duration);
        }
        if(other.gameObject.tag=="Border"){
            textTimer.text="";
            AnswerHandler.enemiesStatic.Remove(thisKey);
            Destroy(gameObject);
        }
    }

    private void checkHP(){
        if(hp>0){
            updateQuestion();
            //deployBullet();
        }else{
            exploder.Play();
            sprtRenderer.enabled=false;
            textMesh.enabled=false;
            Destroy(gameObject,exploder.duration);
        }
    }

    public void updateQuestion(){
        textMesh.enabled=true;
        thisKey=getKey();
        textMesh.text=getQuestions();
        Debug.Log(textMesh.text+" "+thisKey);
        questionPos++;
    }
    private string getQuestions(){
        var index=0;
        foreach (var item in AnswerHandler.enemiesStringStatic)
        {
            if(index==questionPos){
                return item.Value;
            }
            index++;
        }
        return null;
    }
    private int getKey(){
        var index=0;
        foreach (var item in AnswerHandler.enemiesStringStatic)
        {
            if(index==questionPos){
                return item.Key;
            }
            index++;
        }
        return 0;
    }

    private void deployBullet(){
        var rnd=Random.Range(0,3);
        var position=new Vector3(Random.Range(posisi[0].position.x,posisi[1].position.x),posisi[0].position.y);
        var gObject = Instantiate(enemy,position,Quaternion.identity);
        var enemyScript = gObject.GetComponent<EnemyScript>();
        enemyScript.thisKey=getKey();
        enemyScript.enemyScore=10;
        enemyScript.enemyType=rnd;
        AnswerHandler.enemiesStatic[questionPos] = gObject;
        gObject.GetComponentInChildren<TextMeshPro>().text=getQuestions();
        questionPos++;
    }
}

