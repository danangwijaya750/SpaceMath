using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public float distance = 50f;
    // Start is called before the first frame update
    GameObject bgObject;
    BackgroundMove backgroundMove;
    public GameObject[] levelSelection;
    public GameObject stageSelection;
    void Start()
    {
        bgObject=GameObject.Find("bg");
        backgroundMove=(BackgroundMove) bgObject.GetComponent(typeof(BackgroundMove));
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
                        PlayerScript.stage=1;
                        openSelector(1);
                        backgroundMove.changeBg();
                        //BackgroundMove.changeBg();
                    break;
                    case "Stage2" :
                        PlayerScript.stage=2;
                        backgroundMove.changeBg();
                        openSelector(2);
                        //BackgroundMove.changeBg();
                    break;
                    case "Stage3" :
                        PlayerScript.stage=3;
                        backgroundMove.changeBg();
                        openSelector(3);
                        //BackgroundMove.changeBg();
                    break;
                    case "Stage1Level1":
                        PlayerScript.level=1;
                        playGame();
                    break;
                    case "Stage1Level2":
                        PlayerScript.level=2;
                        playGame();
                    break;
                    case "Stage1Level3":
                        PlayerScript.level=3;
                        playGame();
                    break;
                    case "Stage1Level4":
                        PlayerScript.level=4;
                        playGame();
                    break;
                    case "Stage1Level5":
                        PlayerScript.level=5;
                        playGame();
                    break;
                    case "Stage1LevelBoss":
                        PlayerScript.level=6;
                        playGame();
                    break;
                      case "Stage2Level1":
                        PlayerScript.level=1;
                        playGame();
                    break;
                    case "Stage2Level2":
                        PlayerScript.level=2;
                        playGame();
                    break;
                    case "Stage2Level3":
                        PlayerScript.level=3;
                        playGame();
                    break;
                    case "Stage2Level4":
                        PlayerScript.level=4;
                        playGame();
                    break;
                    case "Stage2Level5":
                        PlayerScript.level=5;
                        playGame();
                    break;
                    case "Stage2LevelBoss":
                        PlayerScript.level=6;
                        playGame();
                    break;
                      case "Stage3Level1":
                        PlayerScript.level=1;
                        playGame();
                    break;
                    case "Stage3Level2":
                        PlayerScript.level=2;
                        playGame();
                    break;
                    case "Stage3Level3":
                        PlayerScript.level=3;
                        playGame();
                    break;
                    case "Stage3Level4":
                        PlayerScript.level=4;
                        playGame();
                    break;
                    case "Stage3Level5":
                        PlayerScript.level=5;
                        playGame();
                    break;
                    case "Stage3LevelBoss":
                        PlayerScript.level=6;
                        playGame();
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
        for(int i=0;i<levelSelection.Length;i++){
            levelSelection[i].SetActive(false);
        }
        stageSelection.SetActive(false);
    }

}
