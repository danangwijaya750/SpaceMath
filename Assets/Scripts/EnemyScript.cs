using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int thisKey;
    
    public int enemyScore;
    public int enemyType;
    public Sprite[] ships;
    private SpriteRenderer sprtRenderer;
    private TextMeshPro textMesh;
    private ParticleSystem exploder;
    void Start()
    {
        sprtRenderer=gameObject.GetComponent<SpriteRenderer> ();
        sprtRenderer.sprite =ships[enemyType];
        exploder=gameObject.GetComponent<ParticleSystem>();
        textMesh=gameObject.GetComponentInChildren<TextMeshPro>();
        // sprtRenderer.size=new Vector2(1f,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        // rigidbody.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime);
        transform.position+=Vector3.down*Time.fixedDeltaTime;
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
                sprtRenderer.enabled=false;
                textMesh.enabled=false;
                Destroy(gameObject,exploder.duration);
                PlayerScript.scoring+=enemyScore;
                PlayerScript.destroyedEnemy+=1;
            }
            
        }
        if(other.gameObject.tag=="Player"){
            Debug.Log("metu palyer");
            sprtRenderer.enabled=false;
            textMesh.enabled=false;
            var playerExploder=other.gameObject.GetComponent<ParticleSystem>();
            var playerRenderer=other.gameObject.GetComponent<SpriteRenderer>();
            playerRenderer.enabled=false;
            playerExploder.Play();
            exploder.Play();
            PlayerScript.isGameOver=true;
            Destroy(other.gameObject,playerExploder.duration);
            Destroy(gameObject,exploder.duration);
        }
        if(other.gameObject.tag=="Border"){
            AnswerHandler.enemiesStatic.Remove(thisKey);
            Destroy(gameObject);
        }
    }
}
