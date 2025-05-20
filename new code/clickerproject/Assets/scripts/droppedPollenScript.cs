using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class droppedPollenScript : MonoBehaviour, IPointerEnterHandler
{

    public Logic logic;
    public Item item;
    public int amountCollected;

    public float scaler;
    public float speed;
    public float lifeTime;

    public GameObject radialObject;
    public GameObject radialClone;
    public GameObject canvas;
    public GameObject lowerGUI;
    public radialIndicatorClickScript radialScript;

    public Camera cam;

    public bool isItem;
    public int itemNum;

    public GameObject guiIcon;
    public GameObject guiIconClone;
    public Vector3 topLeftPosition;

    public AudioClip pickUpSound;
    public AudioClip fullSound;

    public void addToGUI(string item){
        if(!logic.itemList.Contains(item)){
            //Debug.Log("ADDED" + item);
            logic.itemList.Add(item);

            if(logic.itemList.Count <= 10){
                guiIconClone = Instantiate(guiIcon,new Vector3(-580+(logic.itemList.Count * 120),460,0), transform.rotation);
            }else{
                guiIconClone = Instantiate(guiIcon,new Vector3(-580+((logic.itemList.Count - 10) * 120),330,0), transform.rotation);
            }
            
            guiIconClone.transform.SetParent(canvas.transform, false);

            spriteGUIScript guiIconCloneScript = guiIconClone.GetComponent<spriteGUIScript>();
            guiIconCloneScript.itemString = item;
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        if(!isItem){
            if((logic.pollen + amountCollected) <= logic.maxBackpackCount){
                logic.addPollen(amountCollected);
                soundManager.instance.playSoundFXClip(pickUpSound, transform, 1f);
                logic.UpdatePollenCount();
                Destroy(gameObject);
                Destroy(radialClone);
            }else{
                if(logic.pollen != logic.maxBackpackCount){
                    logic.pollen = logic.maxBackpackCount;
                    Destroy(gameObject);
                    Destroy(radialClone);
                }else{
                    LeanTween.cancel(logic.pollenCountText.gameObject);
                    LeanTween.cancel(gameObject);
                    soundManager.instance.playSoundFXClip(fullSound, transform, 0.5f);
                    LeanTween.value(logic.pollenCountText.gameObject, logic.pollenCountText.color, Color.red, 0.25f)
                    .setOnUpdate((Color val) => {
                        logic.pollenCountText.color = val;
                    })
                    .setEase(LeanTweenType.easeInOutSine)
                    .setLoopPingPong(1).setOnComplete(logic.whiteColor);
                }
            }
        }else{
            switch(itemNum){
                case 1:
                    item.BloomBoosterCount+=1;
                    addToGUI("bloomBooster");
                    break;
                case 2:
                    item.perennialCharmCount+=1;
                    addToGUI("perennialCharm");
                    break;
                case 3:
                    item.NectarCollectorCount+=1;
                    addToGUI("nectarCollector");
                    break;
                case 4:
                    item.nectarPouchCount+=1;
                    addToGUI("nectarPouch");
                    break;
                case 5:
                    item.honeycombAccelerator+=1;
                    addToGUI("honeycombAccelerator");
                    break;
                case 6:
                    item.royalInfusionCount+=1;
                    addToGUI("royalInfusion");
                    break;
                case 7:
                    item.BeeBombCount+=1;
                    addToGUI("beeBomb");
                    break;
                case 8:
                    item.NectarDrainCount+=1;
                    addToGUI("nectarDrain");
                    break;
                case 9:
                    item.eternalBloomCount+=1;
                    addToGUI("eternalBloom");
                    break;
                case 10:
                    item.goldenConversionCount+=1;
                    addToGUI("goldenConversion");
                    break;
                case 11:
                    item.fertilizerCount+=1;
                    addToGUI("fertilizer");
                    break;
                case 12:
                    item.proboscisSiphonCount+=1;
                    addToGUI("proboscisSiphon");
                    break;
                case 13:
                    item.bountifulBlossomCount+=1;
                    addToGUI("bountifulBlossom");
                    break;
                case 14:
                    item.petalSpreaderCount+=1;
                    addToGUI("petalSpreader");
                    break;
                case 15:
                    item.beeBudCount+=1;
                    logic.maxBees = 1 + item.beeBudCount;
                    logic.availabeBees = 1 + item.beeBudCount;
                    addToGUI("beeBud");
                    break;
                case 16:
                    item.pollenAmpliferCount+=1;
                    addToGUI("pollenAmplifer");
                    break;
                case 17:
                    item.vengeanceStingerCount+=1;
                    addToGUI("vengeanceStinger");
                    break;
                case 18:
                    item.hivePackCount+=1;
                    addToGUI("hivePack");
                    break;
                case 19:
                    item.chronocombCount+=1;
                    addToGUI("chronocomb");
                    break;
                case 20:
                    item.honeyEnricherCount+=1;
                    addToGUI("honeyEnricher");
                    break;
                default:
                    Debug.Log("none set");
                    break;
            }
            item.update = true;
            soundManager.instance.playSoundFXClip(pickUpSound, transform, 1f);
            Destroy(gameObject);
            Destroy(radialClone);
        }
    }


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();

        cam = Camera.main;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        lowerGUI = GameObject.FindGameObjectWithTag("radialGUI");


        // Ensure scaler is initialized correctly
        if (gameObject.name != "dropped lucky pollen(Clone)"){
            amountCollected = 1 + item.royalInfusionCount;
        }

        if (!isItem){
            scaler = (item.pollenAmpliferCount * 0.15F) + 0.5F;
        } else {
            scaler = 0.5F;
        }

        // Set the correct initial scale
        transform.localScale = new Vector3(scaler, scaler, scaler);

        // NECTAR DRAIN
        speed = (float)item.NectarDrainCount * 0.25F;

        // ETERNAL BLOOM
        lifeTime = (float)item.eternalBloomCount + 5F;

        // TIMER TILL DEATH
        radialClone = Instantiate(radialObject, lowerGUI.transform);
        radialClone.transform.localScale = new Vector3(scaler*20, scaler*20, scaler*20);
        radialScript = radialClone.GetComponent<radialIndicatorClickScript>();

        // Calculate the position for the top-left corner
        topLeftPosition = transform.position + new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, 0);

        // Set the position of the radial object
        radialClone.transform.position = new Vector3(topLeftPosition.x, topLeftPosition.y, 0);

        radialScript.max = lifeTime;
        radialScript.time = lifeTime;

        // Smooth scale transition
        transform.LeanScale(new Vector3(scaler, scaler, scaler), 0.25f).setEaseOutBack();
    }

    // Update is called once per frame
    void Update()
    {   
        if(logic.playing){
            radialScript = radialClone.GetComponent<radialIndicatorClickScript>();

            //MOUSE POSITION
            // Get mouse position in world space
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


            Vector3 updatedTopLeft = transform.position + new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, 0);
            radialClone.transform.position = new Vector3(updatedTopLeft.x, updatedTopLeft.y, 0);
            //transform.up = mousePos - transform.position;

            if(radialScript.time <= 0){
                LeanTween.scale(gameObject, new Vector3(0,0,0),0.1f).setOnComplete(destroyDropped);
            }
        }
    }

    void destroyDropped(){
        Destroy(gameObject);
        Destroy(radialClone);
    }
}