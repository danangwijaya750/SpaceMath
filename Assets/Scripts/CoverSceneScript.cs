using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class CoverSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider loadingBar;
    public Button buttonStart;
    public TextMeshProUGUI TMPLoading;

    private IEnumerator IENumLoading;

    private AudioSource audioSource;

    private AsyncOperation asyncOperation;
     private float progress;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        IENumLoading= doLoading();
        StartCoroutine(IENumLoading);
        buttonStart.onClick.AddListener(delegate { enterGame();});
    }
    private IEnumerator doLoading(){
       
        for (int i = 0; i <= 10; i++) 
        {
            progress = i * 0.1f;
            //Debug.Log(progres);
            loadingBar.value = progress;
            if (progress >= 1f) {
                TMPLoading.gameObject.SetActive(false);
                buttonStart.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void enterGame(){
        StopAllCoroutines();        
        if (PlayerPrefs.HasKey(GameConfig.PLAYER_PREF_NAME))
        {
            SceneLoader.LoadScene("MainMenuScene");
        }
        else
        {
            SceneLoader.LoadScene("StoryScene");
        }
    }

    
}
