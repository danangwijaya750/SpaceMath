using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingPanel;
    public Button sfxButton, bgmButton, closePanelButton;
    void Start()
    {
        
        
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
