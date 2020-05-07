using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static string PLAYER_PREF_NAME="PlayerName";
    public static string [ , ] PREF_STAGE_LEVEL = 
    {
        {"stage1Level1","stage1Level2","stage1Level3","stage1Level4","stage1Level5","stage1LevelBoss"},
        {"stage2Level1","stage2Level2","stage2Level3","stage2Level4","stage2Level5","stage2LevelBoss"},
        {"stage3Level1","stage3Level2","stage3Level3","stage3Level4","stage3Level5","stage3LevelBoss"}
    };

    public static int [ , ] enemiesPerLevel = {
        {5,8,10,12,15,20},
        {0,0,0,0,0,0},
        {0,0,0,0,0,0}
    };

    public static int [ ] enemiesScores = {10,15,20};
    public static int [ ] enemiesSpeed = {10,10,10};
}
