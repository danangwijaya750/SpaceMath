using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StroySceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;
    public TextMeshProUGUI tmpStory;
    private IEnumerator storyIEnum;
    public GameObject imageInput;
    public Button btnNext;
    public Button btnSkip;
    public GameObject rightSprite;
    public GameObject leftSprite;
    private int storyPos=0;
    public Sprite[] characters;
    void Start()
    {
        btnNext.onClick.AddListener(loaderStory);
        btnSkip.onClick.AddListener(fullStory);      
        storyIEnum = showStory();
        StartCoroutine(storyIEnum);
    }
    private void loaderStory(){
        StopAllCoroutines();
        storyPos++;
        if(storyPos<GameConfig.storyText.Length){
            storyIEnum = showStory();
            StartCoroutine(storyIEnum);
        }else{
            PlayerPrefs.SetString(GameConfig.PLAYER_PREF_NAME,"A");
            PlayerPrefs.Save();
            SceneLoader.LoadScene("MainMenuScene");
        }
    }
    private void fullStory(){
        StopAllCoroutines();
        tmpStory.text = GameConfig.storyText[storyPos];
        btnSkip.gameObject.SetActive(false);
        btnNext.gameObject.SetActive(true);
    }

    private void spriteController(){
        var leftRenderer = leftSprite.GetComponent<SpriteRenderer>();
        var rightRenderer = rightSprite.GetComponent<SpriteRenderer>();;
        switch(storyPos){
            case 1:
            leftRenderer.sprite=characters[0];
            rightRenderer.sprite=null;
            break;
            case 2:
            leftRenderer.sprite=characters[0];
            rightRenderer.sprite=characters[1];
            break;
            case 3:
            leftRenderer.sprite=null;
            rightRenderer.sprite=characters[3];
            break;
            case 4:
            leftRenderer.sprite=null;
            rightRenderer.sprite=characters[2];
            break;
            case 5:
            leftRenderer.sprite=null;
            rightRenderer.sprite=characters[6];
            break;
            case 6:
            //sini
            leftRenderer.sprite=characters[5];
            rightRenderer.sprite=characters[2];
            break;
            case 7:
            leftRenderer.sprite=characters[0];
            rightRenderer.sprite=null;
            break;
            case 8:
            leftRenderer.sprite=null;
            rightRenderer.sprite=characters[6];
            break;
            case 9:
            leftRenderer.sprite=characters[4];
            rightRenderer.sprite=characters[2];
            break;
            case 10:
            leftRenderer.sprite=characters[0];
            rightRenderer.sprite=null;
            break;
            case 11:
            leftRenderer.sprite=characters[0];
            rightRenderer.sprite=characters[1];
            break;
            default:
            break;
        }
    }

    private IEnumerator showStory(){
        var teks = "";
        tmpStory.text = teks;

        btnNext.gameObject.SetActive(false);
        btnSkip.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        spriteController();

            for (int j = 0; j < GameConfig.storyText[storyPos].Length; j++)
            { 
                teks += GameConfig.storyText[storyPos][j];
                tmpStory.text = teks;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1.0f);
        btnSkip.gameObject.SetActive(false);
        btnNext.gameObject.SetActive(true);
    }

    public void OnValueChange()
    {
        var inp=inputField.text.ToUpper();
        if (inp != inputField.text) inputField.text = inp;
    }
}
