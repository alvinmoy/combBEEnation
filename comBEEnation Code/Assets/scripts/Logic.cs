using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class Logic : MonoBehaviour
{
    public Item item;
    public int pollen = 0;
    public int quota = 3;
    public int totalTime;
    public int totalHoney;
    public int totalPollen;
    public int refreshCost = 1;

    //text
    public TextMeshProUGUI  pollenCountText;
    public TextMeshProUGUI  honeyCountText;
    public TextMeshProUGUI  beeCountText;
    public TextMeshProUGUI  currentTimeText;
    public TextMeshProUGUI  currentDay;

    public TextMeshProUGUI  gameOverPollen;
    public TextMeshProUGUI  gameOverHoney;
    public TextMeshProUGUI  gameOverTime;
    public TextMeshProUGUI  gameOverDay;

    //for spawning flowers
    public int maxFlowers = 2;
    public int maxFlowersCount = 1;

    //backpack count
    public int maxBackpackCount = 12;
    public int honey = 0;

    //bees
    public int maxBees = 1;
    public int availabeBees = 1;

    //timer
    public int currentTime;

    public bool playing;

    public bool isRng;

    //item costs
    public int bloomBoosterCost;
    public int perennialCharmCost;
    public int nectarCollectorCost;
    public int nectarPouchCost;
    public int honeycombAcceleratorCost;

    public Button continueButton;
    public GameObject gameOver;

    public List<Vector3> positionList = new List<Vector3>();
    public List<string> itemList = new List<string>();

    public int rounds;

    //PACKETs
    public GameObject packet1;
    public GameObject packet2;
    public GameObject packet3;

    public gameworldDragAndDrop packet1Script;
    public gameworldDragAndDrop packet2Script;
    public gameworldDragAndDrop packet3Script;

    //SETTINGS
    public GameObject settingsWindow;
    private Vector3 objectSize;
    float cooldownTime = 1f; // Time in seconds before the Escape key can be pressed again
    float nextActionTime = 0f; // Time when the Escape key can be pressed again

    public AudioClip fullSound;

    public bool refereshing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();

        pollenCountText.text = pollen.ToString() + "/" + maxBackpackCount.ToString();
        honeyCountText.text = "<color=red>" + honey.ToString() + "</color>" + "►" +  quota.ToString();
        beeCountText.text = availabeBees.ToString() + "/" + maxBees.ToString();

        totalTime = currentTime;
        quota = 3;

        positionList.Remove(new Vector3(0,0,0));

        packet1 = GameObject.Find("packet1");
        packet2 = GameObject.Find("packet2");
        packet3 = GameObject.Find("packet3");

        packet1Script = packet1.GetComponent<gameworldDragAndDrop>();
        packet2Script = packet2.GetComponent<gameworldDragAndDrop>();
        packet3Script = packet3.GetComponent<gameworldDragAndDrop>();

        Transform parentObject = GameObject.Find("Settings Canvas").transform;
        settingsWindow = parentObject.Find("Settings")?.gameObject;
    }

    public void UpdatePollenCount()
    {
        pollenCountText.text = $"{pollen}/<color=#FFD700>{maxBackpackCount}</color>"; // Gold color for maxBackpackCount
        AnimateMaxBackpackCount();
    }

    void AnimateMaxBackpackCount()
    {
        LeanTween.value(gameObject, 1f, 1.2f, 0.25f)
        .setOnUpdate((float val) => {
            pollenCountText.text = $"<color=green><size={val * 100}%>{pollen}</size></color>/{maxBackpackCount}";
        })
        .setEase(LeanTweenType.easeInOutBack)
        .setLoopPingPong(1);
    }

    public void whiteColor(){
        LeanTween.value(honeyCountText.gameObject, honeyCountText.color, Color.white, 0.25f)
                    .setOnUpdate((Color val) => {
                        honeyCountText.color = val;
                    })
                    .setEase(LeanTweenType.easeInOutSine);

        LeanTween.value(pollenCountText.gameObject, pollenCountText.color, Color.white, 0.25f)
                    .setOnUpdate((Color val) => {
                        pollenCountText.color = val;
                    })
                    .setEase(LeanTweenType.easeInOutSine);
    }

    public void maxAnimation(){
        LeanTween.cancel(honeyCountText.gameObject);
        soundManager.instance.playSoundFXClip(fullSound, transform, 0.5f);
        LeanTween.value(honeyCountText.gameObject, honeyCountText.color, Color.red, 0.25f)
        .setOnUpdate((Color val) => {
        honeyCountText.color = val;
        })
        .setEase(LeanTweenType.easeInOutSine)
        .setLoopPingPong(1).setOnComplete(whiteColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(honey < quota){
            honeyCountText.text = "<color=red>" + honey.ToString() + "</color>" + "►" +  quota.ToString();
        }else{
            honeyCountText.text = "<color=green>" + honey.ToString() + "</color>" + "►" +  quota.ToString();
        }
        //ITEMS
        pollenCountText.text = pollen.ToString() + "/" + maxBackpackCount.ToString();
        
        beeCountText.text = availabeBees.ToString() + "/" + maxBees.ToString();

        currentDay.text = "Day " + rounds;

        if(currentTime <= 10){
            currentTimeText.color = Color.red;
        }else{
            currentTimeText.color = Color.white;
        }

        if(currentTime <= 0){
            playing = false;

            GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");
            GameObject[] bees = GameObject.FindGameObjectsWithTag("bee");
            GameObject[] radials = GameObject.FindGameObjectsWithTag("Radial");
            GameObject[] droppedPollen = GameObject.FindGameObjectsWithTag("DroppedPollen");

            GameObject[] bloomBoosterFlowers = GameObject.FindGameObjectsWithTag("bloomBooster");
            GameObject[] perennialCharmFlowers = GameObject.FindGameObjectsWithTag("perennialCharm");
            GameObject[] nectarCollectorFlowers = GameObject.FindGameObjectsWithTag("nectarCollector");
            GameObject[] nectarPouchFlowers = GameObject.FindGameObjectsWithTag("nectarPouch");
            GameObject[] honeycombAcceleratorFlowers = GameObject.FindGameObjectsWithTag("honeycombAccelerator");
            

            foreach (GameObject flower in flowers){
                Destroy(flower);
            }

            foreach (GameObject bee in bees){
                Destroy(bee);
            }

            foreach (GameObject radial in radials){
                Destroy(radial);
            }

            foreach (GameObject flower in bloomBoosterFlowers){
                honey += bloomBoosterCost;
                Destroy(flower);
            }

            foreach (GameObject flower in perennialCharmFlowers){
                honey += perennialCharmCost;
                Destroy(flower);
            }

            foreach (GameObject flower in nectarCollectorFlowers){
                honey += nectarCollectorCost;
                Destroy(flower);
            }

            foreach (GameObject flower in nectarPouchFlowers){
                honey += nectarPouchCost;
                Destroy(flower);
            }

            foreach (GameObject flower in honeycombAcceleratorFlowers){
                honey += honeycombAcceleratorCost;
                Destroy(flower);
            }

            foreach (GameObject dp in droppedPollen){
                Destroy(dp);
            }

            if(honey >= quota){
                continueButton.gameObject.SetActive(true);
            }else{
                gameOver.gameObject.SetActive(true);
                gameOverPollen.text = totalPollen.ToString();
                gameOverHoney.text = totalHoney.ToString();
                gameOverDay.text = "Day: " + rounds.ToString();
                int min = Mathf.FloorToInt(totalTime / 60);
                int sec = Mathf.FloorToInt(totalTime % 60);
                gameOverTime.text = string.Format("{0:00}:{1:00}", min, sec);
            }
        }

        if(isRng){
            packet1Script.selfRng=true;
            packet2Script.selfRng=true;
            packet3Script.selfRng=true;
            isRng = false;
        }

        

        if (Time.time >= nextActionTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!settingsWindow.activeSelf)
                {
                    settingsWindow.SetActive(true);
                    objectSize = settingsWindow.transform.localScale;
                    playing = false;
                }
                else
                {
                    settingsClose();
                    playing = true;
                }

                nextActionTime = Time.time + cooldownTime; // Set the next time the Escape key can be pressed
            }
        }
        
    }

    public void settingsClose(){
        LeanTween.scale(settingsWindow, new Vector3(0,0,0),0.5f).setOnComplete(disableSettings);
    }

    public void disableSettings(){
        settingsWindow.SetActive(false);
        settingsWindow.transform.localScale = objectSize;
    }

    public void addPollen(int count){
        pollen += count;
        totalPollen += count;
        pollenCountText.text = pollen.ToString() + "/" + maxBackpackCount;
    }

    public void backToMain(){
        SceneManager.LoadScene(0);
    }
}
