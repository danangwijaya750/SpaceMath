using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed=1f;
	public float clamppos;
	public Vector3 startPos;
	public Sprite[] bgSprite;
    private GameObject bgbawah;

    // Start is called before the first frame update
    void Start()
    {
        startPos=transform.position;
       
    }
    public void changeBg(){
        var atas=GameObject.Find("bg");
        atas.GetComponent<SpriteRenderer>().sprite = bgSprite[PlayerScript.stage-1];
        var bawah=GameObject.Find("bgbawah");
        bawah.GetComponent<SpriteRenderer>().sprite = bgSprite[PlayerScript.stage-1];
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newPos=Mathf.Repeat(Time.time * speed,clamppos);
	    transform.position=startPos+Vector3.down*newPos;
    }
}
