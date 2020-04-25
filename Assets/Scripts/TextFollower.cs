using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Camera camera;
    private Vector3 enemyPos;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     Vector3 enemyScenePos=camera.WorldToViewportPoint(enemy.transform.position);
     this.transform.position=new Vector3(enemyScenePos.x,enemyScenePos.y,enemyScenePos.z);
    }
}
