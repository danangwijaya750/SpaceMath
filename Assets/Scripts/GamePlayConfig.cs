using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayConfig : MonoBehaviour
{
    public static int stage = 1;
    public static int level =1;
    public static float destroyed=0f;
    public static int scoring=0;
    public Button btnRestart;
    public Button btnMenu;
    public GameObject gameOverView;
    public GameObject player;
    public static bool isDestroy;
    BackgroundMove backgroundMove;
    GameObject bgObject;

    public void restartLevel(){
        
        btnRestart.gameObject.SetActive(false);
        btnMenu.gameObject.SetActive(false);
        gameOverView.SetActive(false);
        PlayerScript.stage=stage;
        PlayerScript.level=level;
        var position=new Vector3(0f,-9.61f);
        var gObject = Instantiate(player,position,Quaternion.identity);
        
    }
    void Start(){
        bgObject=GameObject.Find("bg");
        backgroundMove=(BackgroundMove) bgObject.GetComponent(typeof(BackgroundMove));
        backgroundMove.changeBg();
    }
    public void saveScoreBackToMenu(){
        if(!isDestroy){
        var oldScore= PlayerPrefs.GetInt(GameConfig.PLAYER_SCORE_PREF);
        PlayerPrefs.SetInt(GameConfig.PLAYER_SCORE_PREF,(oldScore+scoring));
        float allEnemies=(float)GameConfig.enemiesPerLevel[stage-1,level-1];
        var stars = ScoreConverter.getStarsFromScore(allEnemies,destroyed);
        Debug.Log("star "+stars);
        PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[stage-1,level-1],stars);
        PlayerPrefs.Save();
        Debug.Log("stars : "+PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[stage-1,level-1]));
        if(level<=5){
            PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL[stage-1,level], 1);
            PlayerPrefs.Save();
        }else{
            PlayerPrefs.SetInt(GameConfig.PREF_STAGE[stage], 1);
            PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL[stage,0], 1);
            PlayerPrefs.Save();
        }
        }
        else{
            var oldScore= PlayerPrefs.GetInt(GameConfig.PLAYER_SCORE_PREF);
            PlayerPrefs.SetInt(GameConfig.PLAYER_SCORE_PREF,(oldScore+scoring));
            float allEnemies=(float)GameConfig.enemiesPerLevel[stage-1,level-1];
            var stars = ScoreConverter.getStarsFromScore(allEnemies,destroyed);
            var oldStars=PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[stage-1,level-1]);
            Debug.Log("star "+stars);
            if(oldStars<=stars){
                PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[stage-1,level-1],stars);
            }
            PlayerPrefs.Save();
            Debug.Log("stars : "+PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[stage-1,level-1]));
        }
         SceneLoader.LoadScene("SelectStageScene");
        
    }
}
