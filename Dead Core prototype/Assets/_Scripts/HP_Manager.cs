using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Manager : MonoBehaviour 
{
    [SerializeField] private int small_HP_Total, large_HP_Total;

    [SerializeField]
    private float HP_Small = 10;
    [SerializeField]
    private float HP_Large = 50;

    public Text smallText;
    public Text largeText;

    public GameObject player;

	void Start()
	{
        small_HP_Total = 0;
        large_HP_Total = 0;
	}
	public void AddSmallHP()
    {
        small_HP_Total += 1;
        UpdateUI();
    }
    public void AddLargeHP()
    {
        large_HP_Total += 1;
        UpdateUI();
    }    
    public void ApplySmallHP()
    {
        if(small_HP_Total > 0)
        {
            small_HP_Total -= 1;
            player.GetComponent<Player_Health>().IncreaseHealth(HP_Small);
            //play applied sound
        }
        else
        {
            //play error sound
        }

    }
    public void ApplyLargeHP()
    {
        if (large_HP_Total >0)
        {
            large_HP_Total -= 1;
            player.GetComponent<Player_Health>().IncreaseHealth(HP_Large);
            //play applied sound
        }
        else
        {
            //play error sound
        }
    }

    void UpdateUI()
    {
        smallText.text = "Large HP: " + small_HP_Total;
        largeText.text = "Small HP: " + large_HP_Total;
    }
}
