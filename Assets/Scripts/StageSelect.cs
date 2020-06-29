using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StageSelect : MonoBehaviour
{
    public float distance = 50f;
    // Start is called before the first frame update
    GameObject bgObject;
    BackgroundMove backgroundMove;
    public GameObject[] levelSelection;
    public GameObject stageSelection;
    public GameObject[] stageSelectButton;
    public GameObject[] stage1LevelSelectButton;
    public GameObject[] stage2LevelSelectButton;
    public GameObject[] stage3LevelSelectButton;
    public Sprite[] lockUnlock;
    private bool isExpanded=false;
    public TextMeshPro tmpTitle;
    void Start()
    {
        bgObject=GameObject.Find("bg");
        backgroundMove=(BackgroundMove) bgObject.GetComponent(typeof(BackgroundMove));
        initStage();
        initLevel();
    }

    private void initStage(){
        for (int i = 0; i < 3; i++)
        {
            var state = PlayerPrefs.GetInt(GameConfig.PREF_STAGE[i])==1?true:false;
            stageSelectButton[i].GetComponent<BoxCollider2D>().enabled = state;
            if(state){
                stageSelectButton[i].GetComponent<SpriteRenderer>().sprite = lockUnlock[0];
            }
        }
    }
    private void initLevel(){
        for(int i =0;i<3;i++){
            for(int j=0;j<6;j++){
                switch (i){
                    case 0:
                        initLevelStage1(i,j);
                    break;
                    case 1:
                        initLevelStage2(i,j);
                    break;
                    case 2:
                        initLevelStage3(i,j);
                    break;
                    default:
                    break;
                }
            }
        }
    }

    private void initLevelStage1(int i,int j){
        var state = PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL[i,j])==1?true:false;
        Debug.Log(i+","+j+" : "+state);

        stage1LevelSelectButton[j].GetComponent<BoxCollider2D>().enabled = state;
        if(state){
            stage1LevelSelectButton[j].GetComponent<SpriteRenderer>().sprite = lockUnlock[0];
            var star=PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[i,j]);
            for(int k =0;k<star;k++){
                var starObj = stage1LevelSelectButton[j].gameObject.transform.Find("Stars"+(k+1));
                starObj.gameObject.SetActive(true);
            }
        }
    }
    private void initLevelStage2(int i,int j){
        var state = PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL[i,j])==1?true:false;
        Debug.Log(i+","+j+" : "+state);
        stage2LevelSelectButton[j].GetComponent<BoxCollider2D>().enabled = state;
        if(state){
            stage2LevelSelectButton[j].GetComponent<SpriteRenderer>().sprite = lockUnlock[0];
            var star=PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[i,j]);
            for(int k =0;k<star;k++){
                var starObj = stage2LevelSelectButton[j].gameObject.transform.Find("Stars"+(k+1));
                starObj.gameObject.SetActive(true);
            }
        }
    }
    private void initLevelStage3(int i,int j){
        var state = PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL[i,j])==1?true:false;
        Debug.Log(i+","+j+" : "+state);
        stage3LevelSelectButton[j].GetComponent<BoxCollider2D>().enabled = state;
        if(state){
            stage3LevelSelectButton[j].GetComponent<SpriteRenderer>().sprite = lockUnlock[0];
            var star=PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[i,j]);
            for(int k =0;k<star;k++){
                var starObj = stage3LevelSelectButton[j].gameObject.transform.Find("Stars"+(k+1));
                starObj.gameObject.SetActive(true);
            }
        }
    }

    void FixedUpdate(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Hitedd");
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.GetPoint(distance));
             RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, distance);
             if (hit.collider!=null) 
             {
                 Debug.Log(hit.collider.name);
                switch (hit.collider.name)
                {
                    case "Stage1" :
                        GamePlayConfig.stage=1;
                        PlayerScript.stage=1;
                        openSelector(1);
                        backgroundMove.changeBg();
                        //BackgroundMove.changeBg();
                    break;
                    case "Stage2" :
                        GamePlayConfig.stage=2;
                        PlayerScript.stage=2;
                        backgroundMove.changeBg();
                        openSelector(2);
                        //BackgroundMove.changeBg();
                    break;
                    case "Stage3" :
                        GamePlayConfig.stage=3;
                        PlayerScript.stage=3;
                        backgroundMove.changeBg();
                        openSelector(3);
                        //BackgroundMove.changeBg();
                    break;
                    case "Stage1Level1":
                        GamePlayConfig.level=1;
                        PlayerScript.level=1;
                        playGame();
                    break;
                    case "Stage1Level2":
                        GamePlayConfig.level=2;
                        PlayerScript.level=2;
                        playGame();
                    break;
                    case "Stage1Level3":
                        GamePlayConfig.level=3;
                        PlayerScript.level=3;
                        playGame();
                    break;
                    case "Stage1Level4":
                        GamePlayConfig.level=4;
                        PlayerScript.level=4;
                        playGame();
                    break;
                    case "Stage1Level5":
                        GamePlayConfig.level=5;
                        PlayerScript.level=5;
                        playGame();
                    break;
                    case "Stage1LevelBoss":
                        GamePlayConfig.level=6;
                        PlayerScript.level=6;
                        playGame();
                    break;
                      case "Stage2Level1":
                        GamePlayConfig.level=1;
                        PlayerScript.level=1;
                        playGame();
                    break;
                    case "Stage2Level2":
                        GamePlayConfig.level=2;
                        PlayerScript.level=2;
                        playGame();
                    break;
                    case "Stage2Level3":
                        GamePlayConfig.level=3;
                        PlayerScript.level=3;
                        playGame();
                    break;
                    case "Stage2Level4":
                        GamePlayConfig.level=4;
                        PlayerScript.level=4;
                        playGame();
                    break;
                    case "Stage2Level5":
                        GamePlayConfig.level=5;
                        PlayerScript.level=5;
                        playGame();
                    break;
                    case "Stage2LevelBoss":
                        GamePlayConfig.level=6;
                        PlayerScript.level=6;
                        playGame();
                    break;
                      case "Stage3Level1":
                        GamePlayConfig.level=1;
                        PlayerScript.level=1;
                        playGame();
                    break;
                    case "Stage3Level2":
                        GamePlayConfig.level=2;
                        PlayerScript.level=2;
                        playGame();
                    break;
                    case "Stage3Level3":
                        GamePlayConfig.level=3;
                        PlayerScript.level=3;
                        playGame();
                    break;
                    case "Stage3Level4":
                        GamePlayConfig.level=4;
                        PlayerScript.level=4;
                        playGame();
                    break;
                    case "Stage3Level5":
                        GamePlayConfig.level=5;
                        PlayerScript.level=5;
                        playGame();
                    break;
                    case "Stage3LevelBoss":
                        GamePlayConfig.level=6;
                        PlayerScript.level=6;
                        playGame();
                    break;
                    case "BackToMenu":
                        backToMenu();
                    break;
                    default:
                    break;
                }
             }
        }
    }
    private void playGame(){
        SceneLoader.LoadScene("GamePlayScene");
    }
    private void openSelector(int stage){
        isExpanded=!isExpanded;
        deactivateStageSelector();
        switch(stage){
            case 1:
            levelSelection[stage-1].SetActive(true);
            break;
            case 2:
            levelSelection[stage-1].SetActive(true);
            break;
            case 3:
            levelSelection[stage-1].SetActive(true);
            break;
        }
    }
    private void deactivateStageSelector(){
        tmpTitle.text="SELECT LEVEL";
        for(int i=0;i<levelSelection.Length;i++){
            levelSelection[i].SetActive(false);
        }
        stageSelection.SetActive(false);
    }
    private void activateStageSelector(){
        tmpTitle.text="SELECT STAGE";
        for(int i=0;i<levelSelection.Length;i++){
            levelSelection[i].SetActive(false);
        }
        stageSelection.SetActive(true);
    }

    private void backToMenu(){
         if(isExpanded){
            activateStageSelector();
         }
         else{
             SceneLoader.LoadScene("MainMenuScene");
         }
         isExpanded=!isExpanded;
    }

}
