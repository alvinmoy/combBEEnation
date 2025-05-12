using System.Threading.Tasks;
using System.Collections; 
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class flowerScript : MonoBehaviour, IPointerDownHandler
{
    public Logic logic;
    public Item item;

    public radialIndicatorClickScript radialScript;
    public GameObject radialObject;
    public GameObject radialClone;
    public GameObject radialParent;
    public GameObject canvas;
    public GameObject lowerGUI;

    public GameObject Bee;
    public GameObject DroppedPollen;
    public GameObject beeBomb;
    public GameObject beeClone;
    public GameObject beeBombClone;
    public GameObject luckyDroppedPollen;

    public float clickCount;
    public float maxClickCount;
    public bool inUse = false;
    public float timer;
    public float beeBombTimer;

    public float convertRate = 3;
    public float pollenObtained;
    public float pollenSpawnedCount = 1;

    public bool wasSetByBeeBomb = false;
    private bool isDragging;
    private bool colliding;
    private GameObject packet;

    public AudioClip dropSound;
    public AudioClip stinger;
    public bool hasBeenChecked = false;

    public bool flowerMinus = false;
    public bool isVengeanceStinger = false;

    //ITEM FLOWER STUFF
    public bool isItemFlower;
    public int itemFlowerNum;

    public GameObject tier1Item;

    //ITEM FLOWER DROPPED ICONS
    private SpriteRenderer thisSprite;
    public Sprite propolisPouch;
    public Sprite copperWings;
    public Sprite electricTippedProb;
    public Sprite queensGrain;
    public Sprite pollenPendant;
    public Sprite broodBud;
    public Sprite hivePack;
    public Sprite royalFertilizer;
    public Sprite vengeanceStinger;
    public Sprite apiaristsInfusion;
    public Sprite obsidianOcelus;
    public Sprite beeSwarm;
    public Sprite perennialCharm;
    public Sprite queensWateringPot;
    public Sprite chronoComb;
    public Sprite sucroseLodestone;
    public Sprite luckyStamen;
    public Sprite eternalMist;
    public Sprite waxSiphon;
    public Sprite petalExtractor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        lowerGUI = GameObject.FindGameObjectWithTag("radialGUI");
    }

    // Update is called once per frame
    void Update()
    {   
        beeBombScript beeBombScriptInstance = beeBomb.GetComponent<beeBombScript>();
        if(logic.playing){
            if (inUse){
            timer = timer + Time.deltaTime;
            if(timer >= convertRate){
                clickCount++;
                timer = 0;
                if(!flowerMinus){
                    logic.maxFlowersCount--;
                }
                flowerMinus = true;
                logic.positionList.Remove(gameObject.transform.position);
                Destroy(beeClone);
                Destroy(radialClone);
                
                
                //Debug.Log(isItemFlower);

                if(!isItemFlower && !hasBeenChecked){
                    for(int i = 0; i < pollenSpawnedCount; i++){
                        GameObject pollenClone = Instantiate(DroppedPollen, new Vector3(Random.Range(transform.position.x-1,transform.position.x+1),Random.Range(transform.position.y-1,transform.position.y+1),0), transform.rotation);
                    }

                    if(bountifulBlossomChance(item.bountifulBlossomCount)){
                        GameObject luckyPollenClone = Instantiate(luckyDroppedPollen, new Vector3(Random.Range(transform.position.x-1,transform.position.x+1),Random.Range(transform.position.y-1,transform.position.y+1),0), transform.rotation);
                        droppedPollenScript luckyPollenCloneScript = luckyPollenClone.GetComponent<droppedPollenScript>();
                        luckyPollenCloneScript.amountCollected+=1;

                        //Debug.Log(luckyPollenCloneScript.amountCollected);
                    }
                }else{
                    if(!hasBeenChecked){
                        GameObject tier1ItemClone = Instantiate(tier1Item, new Vector3(Random.Range(transform.position.x-1,transform.position.x+1),
                        Random.Range(transform.position.y-1,transform.position.y+1),0), transform.rotation);

                        droppedPollenScript ItemCloneScript = tier1ItemClone.GetComponent<droppedPollenScript>();
                        thisSprite = tier1ItemClone.GetComponent<SpriteRenderer>();

                        ItemCloneScript.isItem = true;
                        switch(itemFlowerNum){
                            case 1:
                                ItemCloneScript.itemNum = 1;
                                thisSprite.sprite = pollenPendant;
                                break;
                            case 2:
                                ItemCloneScript.itemNum = 2;
                                thisSprite.sprite = queensGrain;
                                break;
                            case 3:
                                ItemCloneScript.itemNum = 3;
                                thisSprite.sprite = electricTippedProb;
                                break;
                            case 4:
                            ItemCloneScript.itemNum = 4;
                                thisSprite.sprite = propolisPouch;
                                break;
                            case 5:
                                ItemCloneScript.itemNum = 5;
                                thisSprite.sprite = copperWings;
                                break;
                            case 6:
                                ItemCloneScript.itemNum = 6;
                                thisSprite.sprite = apiaristsInfusion;
                                break;
                            case 7:
                                ItemCloneScript.itemNum = 7;
                                thisSprite.sprite = beeSwarm;
                                break;
                            case 8:
                                ItemCloneScript.itemNum = 8;
                                thisSprite.sprite = sucroseLodestone;
                                break;
                            case 9:
                                ItemCloneScript.itemNum = 9;
                                thisSprite.sprite = eternalMist;
                                break;
                            case 10:
                                ItemCloneScript.itemNum = 10;
                                thisSprite.sprite = waxSiphon;
                                break;
                            case 11:
                                ItemCloneScript.itemNum = 11;
                                thisSprite.sprite = queensWateringPot;
                                break;
                            case 12:
                                ItemCloneScript.itemNum = 12;
                                thisSprite.sprite = petalExtractor;
                                break;
                            case 13:
                                ItemCloneScript.itemNum = 13;
                                thisSprite.sprite = luckyStamen;
                                break;
                            case 14:
                                ItemCloneScript.itemNum = 14;
                                thisSprite.sprite = perennialCharm;
                                break;
                            case 15:
                                ItemCloneScript.itemNum = 15;
                                thisSprite.sprite = broodBud;
                                break;
                            case 16:
                                ItemCloneScript.itemNum = 16;
                                thisSprite.sprite = royalFertilizer;
                                break;
                            case 17:
                                ItemCloneScript.itemNum = 17;
                                thisSprite.sprite = vengeanceStinger;
                                break;
                            case 18:
                                ItemCloneScript.itemNum = 18;
                                thisSprite.sprite = hivePack;
                                break;
                            case 19:
                                ItemCloneScript.itemNum = 19;
                                thisSprite.sprite = chronoComb;
                                break;
                            case 20:
                                ItemCloneScript.itemNum = 20;
                                thisSprite.sprite = obsidianOcelus;
                                break;
                        }
                    }
                }
                
                //BEE BOMB
                if(!wasSetByBeeBomb){
                    spawnBeeBomb();
                }
                if(logic.maxBees > logic.availabeBees){
                    logic.availabeBees++;
                }
                
                
                if(!hasBeenChecked){
                    soundManager.instance.playSoundFXClip(dropSound, transform, 0.5f);
                    LeanTween.scale(gameObject, new Vector3(0,0,0),0.25f).setOnComplete(destroyFlower);
                }
                hasBeenChecked = true;
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        if(logic.playing && !inUse){
            if(logic.availabeBees > 0){
                radialClone = Instantiate(radialObject, lowerGUI.transform);
                radialIndicatorClickScript radialScript = radialClone.GetComponent<radialIndicatorClickScript>();

                radialScript.max = convertRate;
                radialScript.time = convertRate;

                radialClone.transform.position = new Vector3(gameObject.transform.position.x + 0.4F, gameObject.transform.position.y + 0.4F, 0);
                Image radialCloneSprite = radialClone.GetComponent<Image>();

                beeClone = Instantiate(Bee, 
                    new Vector3(gameObject.transform.position.x, 
                    gameObject.transform.position.y+0.2F, 
                    gameObject.transform.position.z),
                    gameObject.transform.rotation);

                SpriteRenderer beeSprite = beeClone.GetComponent<SpriteRenderer>();
                SpriteRenderer flowerSprite = gameObject.GetComponent<SpriteRenderer>();

                if (beeSprite != null && flowerSprite != null) {
                
                    beeSprite.sortingLayerID = flowerSprite.sortingLayerID;  
                    beeSprite.sortingOrder = flowerSprite.sortingOrder + 1;

                }
                //gameObject.transform.parent = beeClone.transform;
                logic.availabeBees--;
                BoxCollider2D collider = GetComponent<BoxCollider2D>();
                if (collider != null) {
                Destroy(collider);
                }   
                inUse = true;
                
                if(isVengeanceStinger){
                    soundManager.instance.playSoundFXClip(stinger, transform, 0.5f);
                }
                if(item.proboscisSiphonNum < item.proboscisSiphonCount && item.proboscisSiphonCount != 0 && !hasBeenChecked){
                    item.proboscisSiphonNum++;
                    convertRate = 0.001f;
                    // LeanTween.scale(gameObject, new Vector3(0,0,0),0.25f).setOnComplete(destroyFlower);
                    
                }
            }
        }
    }

    void spawnBeeBomb(){
            float chance = Random.Range(1,10);
            if(chance <= item.BeeBombCount){
                beeBombClone = Instantiate(beeBomb, new Vector3(transform.position.x,transform.position.y,0), transform.rotation);
            }
    }

    bool bountifulBlossomChance(float count){
        float bountifulBlossomNum = Random.value;
        if(count*0.1 >= bountifulBlossomNum && item.bountifulBlossomCount > 0){
            return true;
        }else{
            return false;
        }
    }

    public void destroyFlower(){
        Destroy(gameObject);
    }
}
