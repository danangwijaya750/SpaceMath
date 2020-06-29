using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public int targetKey;
    public Transform bulletTrail;
    private SpriteRenderer sprtRenderer;
    private Rigidbody2D rigidbody;
    public Sprite[] bulletSprites;

    void Start()
    {
        //rigidbody=GetComponent<Rigidbody2D>();
        sprtRenderer=gameObject.GetComponent<SpriteRenderer> ();
        sprtRenderer.sprite =bulletSprites[GamePlayConfig.stage-1];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = target.position - transform.position;
                diff.Normalize(); 
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        //rigidbody.MovePosition(transform.position + transform.up*10 * Time.fixedDeltaTime);
        //gameObject.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,target.position,10*Time.deltaTime);
    }
    void showEffect(){
        
    }
}
