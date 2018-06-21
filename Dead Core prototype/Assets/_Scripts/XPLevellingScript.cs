using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPLevellingScript : MonoBehaviour
{
    public Image playerXPBar;

    public float currentXP; //loaded
    public float targetXP; //loaded
    public float previousTargetXP; //loaded
    public float differenceXP; //loaded

    public int maxLevel; //Can change this just a placeholder, doesn't need to be saved or loaded.

    public int level; //loaded
    public float levelIncrement; //Should start at 1 and gradually increase, also needs to be saved and loaded. Ensures the increase in xp needed between levels

    //Temporary for testing
    public float addXPTimer;

    public void Start()
    {
        maxLevel = 50;
        LoadLevel();
        //This is where the level and xp progress will be loaded.
        //Example
        //currentXP = 550;
        //targetXP = 1200;
        //level = 5;
        //levelIncrement = 1.3;

        //For Testing: Will add 35 for each kill;

        currentXP = 0;
        targetXP = 100;
        previousTargetXP = 0;
        differenceXP = 0;
        level = 1;
        levelIncrement = 1;

        addXPTimer = Time.time + 3f;

    }

    void LoadLevel()
    {
        //The actual code to access the data.
    }

    void SaveLevel() //Doesn't have to be in this script.
    {
        //The code to save the xp and level before the game closes down.
    }

    public void IncreaseXP(int xp) //Call this with xp value to add xp
    {
        currentXP += xp;

        if (level < maxLevel)
        {
            if (currentXP >= targetXP)
            {
                differenceXP = currentXP - targetXP;
                level += 1;
                previousTargetXP = targetXP;
                targetXP = targetXP * levelIncrement;
                levelIncrement += 0.1f;
                currentXP = differenceXP;
            }
        }
    }

    void Update() //This one constantly checks the xp and changes the level when necessary, also keeps the xp bar with the correct amount of fill
    {
        //For testing        
        if (addXPTimer < Time.time)
        {
            IncreaseXP(35);
            Debug.Log("Adding XP");
            addXPTimer = Time.time + 3f;
        }

        //THIS DOESN'T WORK
        RectTransform rt = playerXPBar.rectTransform;
        float betweenXP = targetXP - previousTargetXP;
        float percentageXP = differenceXP / betweenXP;

        float barWidth = percentageXP * rt.rect.width;
        playerXPBar.fillAmount = barWidth;


       
     }

}
