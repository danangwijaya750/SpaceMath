using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreConverter : MonoBehaviour
{
   public static int getStarsFromScore(float enemiesLevel, float enemiesDestroyed){
       var stars=3;
       float percentage=enemiesDestroyed/enemiesLevel*100;
       Debug.Log("percentage " +percentage);
       if(percentage<50f){
           stars=1;
       }else if(percentage>50f && percentage < 80f){
           stars=2;
       }
       return stars;
   }
}
