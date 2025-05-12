using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class continueButtonScript : MonoBehaviour
{
    public Button yourButton;
    public Logic logic;
    public Item item;
    public float growthRate = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();

        yourButton = gameObject.GetComponent<Button>();
		yourButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick(){
        yourButton.gameObject.SetActive(false);
        logic.honey -= logic.quota;
        // logic.honey /= 2;
        // logic.honey = 0;
        logic.pollen = 0;
        logic.playing = true;
		logic.currentTime = 90 + (10 * item.chronocombCount);
        logic.totalTime += logic.currentTime;
        logic.quota = (int)Mathf.Ceil(logic.quota+(0.01F*logic.totalTime));

        LeanTween.scale(logic.honeyCountText.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.25f).setOnComplete(turnTextSmall);
        logic.isRng = true;
        
        logic.availabeBees = logic.maxBees;
        logic.maxFlowersCount = 0;
        logic.rounds+=1;
        item.proboscisSiphonNum = 0;

        growthRate = 0.025f;

        logic.bloomBoosterCost = Mathf.RoundToInt(logic.bloomBoosterCost * Mathf.Pow(1 + growthRate, logic.rounds));
        logic.perennialCharmCost = Mathf.RoundToInt(logic.perennialCharmCost * Mathf.Pow(1 + growthRate, logic.rounds));
        logic.nectarCollectorCost = Mathf.RoundToInt(logic.nectarCollectorCost * Mathf.Pow(1 + growthRate, logic.rounds));
        logic.nectarPouchCost = Mathf.RoundToInt(logic.nectarPouchCost * Mathf.Pow(1 + growthRate, logic.rounds));
        logic.honeycombAcceleratorCost = Mathf.RoundToInt(logic.honeycombAcceleratorCost * Mathf.Pow(1 + growthRate, logic.rounds));
    
        //Debug.Log(logic.honeycombAcceleratorCost * Mathf.Pow(1 + growthRate, logic.rounds) + ":" + logic.bloomBoosterCost * Mathf.Pow(1 + growthRate, logic.rounds) + ":" + logic.rounds);
	}

    void turnTextSmall(){
        LeanTween.scale(logic.honeyCountText.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }
}
