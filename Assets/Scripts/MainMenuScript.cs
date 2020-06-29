using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingPanel;
    public Button sfxButton, bgmButton, closePanelButton;
    public AudioSource audioSource;
    public TextMeshProUGUI scoreTMP,starsTMP;
    void Start()
    {
      initial();
    }
    private void initial(){
        var stars =0;
          for (int i = 0; i < 3; i++)
        {
            if(!PlayerPrefs.HasKey(GameConfig.PREF_STAGE[i])){
                Debug.Log("Old Not saved");
                var state=false;
                    if(i==0){
                        state=true;
                    }
                    PlayerPrefs.SetInt(GameConfig.PREF_STAGE[i], state?1:0);
            }
            for(int j= 0;j < 6;j++){
                if(!PlayerPrefs.HasKey(GameConfig.PREF_STAGE_LEVEL[i,j])){
                    bool foo=false;
                    if(j==0 && i==0 ){
                        foo=true;
                    }
                    PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL[i,j], foo?1:0);
                }
                if(!PlayerPrefs.HasKey(GameConfig.PREF_STAGE_LEVEL_SCORE[i,j])){
                    PlayerPrefs.SetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[i,j], 0);
                }
                stars+=PlayerPrefs.GetInt(GameConfig.PREF_STAGE_LEVEL_SCORE[i,j]);
                PlayerPrefs.Save();
            }
        }
        var scores = PlayerPrefs.GetInt(GameConfig.PLAYER_SCORE_PREF);
        scoreTMP.text="SCORE : "+scores.ToString(); 
        starsTMP.text="STARS : "+stars.ToString();

    }

    public void OpenGameScene(){
        SceneLoader.LoadScene("SelectStageScene");
    }
    public void OpenSettings(){
        settingPanel.SetActive(true);
    }

    public void CloseSettings(){
        settingPanel.SetActive(false);
    }
    public void SFXToogle(){

    }
    public void BGMToogle(){

    }
}
