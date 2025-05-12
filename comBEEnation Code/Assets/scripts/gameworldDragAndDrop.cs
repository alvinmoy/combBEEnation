using UnityEngine;
using System.Collections;

public class gameworldDragAndDrop : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    private Camera cam;

    public Logic logic;
    private GameObject flower;

    private bool colliding;
    private SpriteRenderer thisSprite;

    public Sprite bloomBooster;
    public Sprite perennialCharm;
    public Sprite nectarCollector;
    public Sprite nectarPouch;
    public Sprite honeycombAccelerator;

    public GameObject itemFlower;
    public GameObject tier2Flower;

    public Vector3 intialPosition;
    public bool isSelfRng;

    public Color lowOpacity;

    public bool isTier1Flower;

    public flowerScript itemFlowerCloneScript;
    public GameObject itemFlowerClone;

    public flowerScript tier2FlowerCloneScript;
    public GameObject tier2FlowerClone;

    public bool packetUsed = false;
    public bool tier2PacketUsed = false;
    public bool selfRng = false;

    public int rngNum;

    public AudioClip packetSound;
    public AudioClip fullSound;
    public AudioClip hoverSound;

    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        thisSprite = gameObject.GetComponent<SpriteRenderer>();

        intialPosition = gameObject.transform.position;

        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    
        rngNum = Random.Range(1,6);

        switch(rngNum){
            case 1:
                thisSprite.sprite = bloomBooster;
                gameObject.tag = "bloomBoosterPacket";
                break;
            case 2:
                thisSprite.sprite = perennialCharm;
                gameObject.tag = "perennialCharmPacket";
                break;
            case 3:
                thisSprite.sprite = nectarCollector;
                gameObject.tag = "nectarCollectorPacket";
                break;
            case 4:
                thisSprite.sprite = nectarPouch;
                gameObject.tag = "nectarPouchPacket";
                break;
            case 5:
                thisSprite.sprite = honeycombAccelerator;
                gameObject.tag = "honeycombAcceleratorPacket";
                break;
            default:
                Debug.Log("broken..");
                break;
            }
    }

    // Update is called once per frame
    void Update()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        
        if(selfRng){
            rngNum = Random.Range(1,6);
            switch(rngNum){
                case 1:
                    thisSprite.sprite = bloomBooster;
                    gameObject.tag = "bloomBoosterPacket";
                    packetUsed = false;
                    break;
                case 2:
                    thisSprite.sprite = perennialCharm;
                    gameObject.tag = "perennialCharmPacket";
                    packetUsed = false;
                    break;
                case 3:
                    thisSprite.sprite = nectarCollector;
                    gameObject.tag = "nectarCollectorPacket";
                    packetUsed = false;
                    break;
                case 4:
                    thisSprite.sprite = nectarPouch;
                    gameObject.tag = "nectarPouchPacket";
                    packetUsed = false;
                    break;
                case 5:
                    thisSprite.sprite = honeycombAccelerator;
                    gameObject.tag = "honeycombAcceleratorPacket";
                    packetUsed = false;
                    break;
                default:
                    Debug.Log("broken..");
                    break;
            }
            selfRng = false;
            StartCoroutine(ResetRng());
        }

        if(isDragging){
            circleCollider.enabled = false;
            boxCollider.enabled = true;
        }else{
            circleCollider.enabled = true;
            boxCollider.enabled = false;
        }

        if(colliding && itemFlowerClone != null){
            if(itemFlowerClone.CompareTag("bloomBooster") && gameObject.CompareTag("bloomBoosterPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Pollen collection is worth more", "Aparist's Infusion");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("bloomBooster") && gameObject.CompareTag("perennialCharmPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to drop a bee bomb", "Bee Swarm");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("bloomBooster") && gameObject.CompareTag("nectarCollectorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Droppables move towards you", "Sucrose Lodestone");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("bloomBooster") && gameObject.CompareTag("nectarPouchPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Droppables have longer life", "Eternal Mist");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("bloomBooster") && gameObject.CompareTag("honeycombAcceleratorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to convert all pollen into honey", "Wax Siphon");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            /////
            
            if(itemFlowerClone.CompareTag("perennialCharm") && gameObject.CompareTag("bloomBoosterPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to drop a bee bomb", "Bee Swarm");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("perennialCharm") && gameObject.CompareTag("perennialCharmPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Flowers spawn rate is increased", "Queen's Watering Pot");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.perennialCharmPacket);
            }

            if(itemFlowerClone.CompareTag("perennialCharm") && gameObject.CompareTag("nectarCollectorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Instantly remove a flower", "Petal Extractor");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.nectarCollectorPacket);
            }

            if(itemFlowerClone.CompareTag("perennialCharm") && gameObject.CompareTag("nectarPouchPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to drop lucky pollen", "Lucky Stamen");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.perennialCharmPacket);
            }

            if(itemFlowerClone.CompareTag("perennialCharm") && gameObject.CompareTag("honeycombAcceleratorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to spawn a flower near an existing one", "Perennial Charm");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            /////
            
            if(itemFlowerClone.CompareTag("nectarCollector") && gameObject.CompareTag("bloomBoosterPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Droppables move towards you", "Sucrose Lodestone");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("nectarCollector") && gameObject.CompareTag("perennialCharmPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Instantly remove a flower", "Petal Extractor");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.nectarCollectorPacket);
            }

            if(itemFlowerClone.CompareTag("nectarCollector") && gameObject.CompareTag("nectarCollectorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Gain another friend", "Brood Bud");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.nectarCollectorPacket);
            }

            if(itemFlowerClone.CompareTag("nectarCollector") && gameObject.CompareTag("nectarPouchPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Droppables increase in size", "Royal Fertilizer");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.nectarCollectorPacket);
            }

            if(itemFlowerClone.CompareTag("nectarCollector") && gameObject.CompareTag("honeycombAcceleratorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to half flower harvest rate", "Vengeance Stinger");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            /////
            
            if(itemFlowerClone.CompareTag("nectarPouch") && gameObject.CompareTag("bloomBoosterPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Droppables have longer life", "Eternal Mist");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.bloomBoosterPacket);
            }

            if(itemFlowerClone.CompareTag("nectarPouch") && gameObject.CompareTag("perennialCharmPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to drop lucky pollen", "Lucky Stamen");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.perennialCharmPacket);
            }

            if(itemFlowerClone.CompareTag("nectarPouch") && gameObject.CompareTag("nectarCollectorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Droppables increase in size", "Royal Fertilizer");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.nectarCollectorPacket);
            }

            if(itemFlowerClone.CompareTag("nectarPouch") && gameObject.CompareTag("nectarPouchPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Gain even greater storage for pollen", "Hive Pack");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.nectarPouchPacket);
            }

            if(itemFlowerClone.CompareTag("nectarPouch") && gameObject.CompareTag("honeycombAcceleratorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Gain more time for the next day", "Chronochomb");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            /////
            
            if(itemFlowerClone.CompareTag("honeycombAccelerator") && gameObject.CompareTag("bloomBoosterPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to convert all pollen into honey", "Wax Siphon");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            if(itemFlowerClone.CompareTag("honeycombAccelerator") && gameObject.CompareTag("perennialCharmPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to spawn a flower near an existing one", "Perennial Charm");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            if(itemFlowerClone.CompareTag("honeycombAccelerator") && gameObject.CompareTag("nectarCollectorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Chance to half flower harvest rate", "Vengeance Stinger");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            if(itemFlowerClone.CompareTag("honeycombAccelerator") && gameObject.CompareTag("nectarPouchPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Gain more time for the next day", "Chronochomb");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }

            if(itemFlowerClone.CompareTag("honeycombAccelerator") && gameObject.CompareTag("honeycombAcceleratorPacket")){
                tooltipboxManager._instance.setAndShowToolTip("Convert more pollen into honey",  "Obsidian Ocelus");
                tooltipboxManager._instance.setImage(tooltipboxManager._instance.honeycombAcceleratorPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
            }
        }
    }

    void OnMouseEnter(){
        if(!isDragging){
            soundManager.instance.playSoundFXClip(hoverSound, transform, 0.5f);
        }
    }

    void OnMouseDown(){
        if(!isDragging){
            isDragging = true;
        }
        offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag(){
        if (isDragging){
            lowOpacity = thisSprite.color;
            lowOpacity.a = 0.6f;
            thisSprite.color = lowOpacity;
            Vector3 newPosition = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Keep object on the same Z plane
            transform.position = mousePosition;
        }
    }

    void createTier1Flower(){
        itemFlowerClone = Instantiate(itemFlower, flower.transform.position, flower.transform.rotation);
        itemFlowerCloneScript = itemFlowerClone.GetComponent<flowerScript>();
        itemFlowerCloneScript.isItemFlower = true;
        soundManager.instance.playSoundFXClip(packetSound, transform, 0.5f);
        Destroy(flower);
    }

    void createTier2Flower(){
        tier2FlowerClone = Instantiate(tier2Flower, itemFlowerClone.transform.position, itemFlowerClone.transform.rotation);
        tier2FlowerCloneScript = tier2FlowerClone.GetComponent<flowerScript>();
        tier2FlowerCloneScript.isItemFlower = true;
    }
    void OnMouseUp()
    {
        if(isDragging){
            isDragging = false;
        }
        lowOpacity = thisSprite.color;
        lowOpacity.a = 1f;
        thisSprite.color = lowOpacity;

        if(colliding && !isDragging){
            if(!isTier1Flower){
                if(thisSprite.sprite == bloomBooster && logic.honey >= logic.bloomBoosterCost){
                    // Debug.Log("Bloom booster");
                    createTier1Flower();
                    logic.honey-=logic.bloomBoosterCost;
                    itemFlowerCloneScript.itemFlowerNum = 1;
                    itemFlowerClone.GetComponent<Renderer>().material.color = Color.red;
                    itemFlowerClone.tag = "bloomBooster";
                    packetUsed = true;
                }else{
                    if(thisSprite.sprite == bloomBooster && logic.honey < logic.bloomBoosterCost){
                        logic.maxAnimation();
                    }
                }
                if(thisSprite.sprite == perennialCharm && logic.honey >= logic.perennialCharmCost){
                    // Debug.Log("perennialCharm");
                    createTier1Flower();
                    logic.honey-=logic.perennialCharmCost;
                    itemFlowerCloneScript.itemFlowerNum = 2;
                    itemFlowerClone.GetComponent<Renderer>().material.color = new Color(0.5f, 0f, 0.5f);
                    itemFlowerClone.tag = "perennialCharm";
                    packetUsed = true;
                }else{
                    if(thisSprite.sprite == perennialCharm && logic.honey < logic.perennialCharmCost){
                        logic.maxAnimation();
                    }
                    
                }
                if(thisSprite.sprite == nectarCollector  && logic.honey >= logic.nectarCollectorCost){
                    // Debug.Log("nectarCollector");
                    createTier1Flower();
                    logic.honey-=logic.nectarCollectorCost;
                    itemFlowerCloneScript.itemFlowerNum = 3;
                    itemFlowerClone.GetComponent<Renderer>().material.color = Color.green;
                    itemFlowerClone.tag = "nectarCollector";
                    packetUsed = true;
                }else{
                    if(thisSprite.sprite == nectarCollector && logic.honey < logic.nectarCollectorCost){
                        logic.maxAnimation();
                    }
                }
                if(thisSprite.sprite == nectarPouch  && logic.honey >= logic.nectarPouchCost){
                    // Debug.Log("nectarPouch");
                    createTier1Flower();
                    logic.honey-=2;
                    itemFlowerCloneScript.itemFlowerNum = 4;
                    itemFlowerClone.GetComponent<Renderer>().material.color = Color.blue;
                    itemFlowerClone.tag = "nectarPouch";
                    packetUsed = true;
                }else{
                    if(thisSprite.sprite == nectarPouch && logic.honey < logic.nectarPouchCost){
                        logic.maxAnimation();
                    }
                }
                if(thisSprite.sprite == honeycombAccelerator  && logic.honey >= logic.honeycombAcceleratorCost){
                    // Debug.Log("honeycombAccelerator");
                    createTier1Flower();
                    logic.honey-=logic.honeycombAcceleratorCost;
                    itemFlowerCloneScript.itemFlowerNum = 5;
                    itemFlowerClone.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0f);
                    itemFlowerClone.tag = "honeycombAccelerator";
                    packetUsed = true;
                }else{
                    if(thisSprite.sprite == honeycombAccelerator && logic.honey < logic.honeycombAcceleratorCost){
                        logic.maxAnimation();
                    }
                }
        }else{

            if(thisSprite.sprite == bloomBooster && logic.honey >= logic.bloomBoosterCost){
                createTier2Flower();
                logic.honey-=logic.bloomBoosterCost;
                packetUsed = true;
                tier2PacketUsed = true;
                //6 royal infusion
                if(itemFlowerClone.tag == "bloomBooster"){
                    tier2FlowerCloneScript.itemFlowerNum = 6;
                }
                //7 bee bomb
                if(itemFlowerClone.tag == "perennialCharm"){
                    tier2FlowerCloneScript.itemFlowerNum = 7;
                }
                //8 nectar drain
                if(itemFlowerClone.tag == "nectarCollector"){
                    tier2FlowerCloneScript.itemFlowerNum = 8;
                }
                //9 eternal bloom
                if(itemFlowerClone.tag == "nectarPouch"){
                    tier2FlowerCloneScript.itemFlowerNum = 9;
                }
                //10 golden conversion
                if(itemFlowerClone.tag == "honeycombAccelerator"){
                    tier2FlowerCloneScript.itemFlowerNum = 10;
                }
            }
            if(thisSprite.sprite == perennialCharm && logic.honey >= logic.perennialCharmCost){
                createTier2Flower();
                logic.honey-=logic.perennialCharmCost;
                packetUsed = true;
                tier2PacketUsed = true;
                // 7 bee bomb
                if(itemFlowerClone.tag == "bloomBooster"){
                    tier2FlowerCloneScript.itemFlowerNum = 7;
                }
                // 11 fertilizer
                if(itemFlowerClone.tag == "perennialCharm"){
                    tier2FlowerCloneScript.itemFlowerNum = 11;
                }
                //12 proboscis siphon
                if(itemFlowerClone.tag == "nectarCollector"){
                    tier2FlowerCloneScript.itemFlowerNum = 12;
                }
                //13 bountiful blossom
                if(itemFlowerClone.tag == "nectarPouch"){
                    tier2FlowerCloneScript.itemFlowerNum = 13;
                }
                //14 petal spreader
                if(itemFlowerClone.tag == "honeycombAccelerator"){
                    tier2FlowerCloneScript.itemFlowerNum = 14;
                }
            }
            if(thisSprite.sprite == nectarCollector && logic.honey >= logic.nectarCollectorCost){
                createTier2Flower();
                logic.honey-=logic.nectarCollectorCost;
                packetUsed = true;
                tier2PacketUsed = true;
                //8 nectar drain
                if(itemFlowerClone.tag == "bloomBooster"){
                    tier2FlowerCloneScript.itemFlowerNum = 8;
                }
                //12 proboscis siphon
                if(itemFlowerClone.tag == "perennialCharm"){
                    tier2FlowerCloneScript.itemFlowerNum = 12;
                }
                //15 bed bud
                if(itemFlowerClone.tag == "nectarCollector"){
                    tier2FlowerCloneScript.itemFlowerNum = 15;
                }
                //16 pollen amplifier
                if(itemFlowerClone.tag == "nectarPouch"){
                    tier2FlowerCloneScript.itemFlowerNum = 16;
                }
                //17 vengeance stinger
                if(itemFlowerClone.tag == "honeycombAccelerator"){
                    tier2FlowerCloneScript.itemFlowerNum = 17;
                }
            }
            if(thisSprite.sprite == nectarPouch && logic.honey >= logic.nectarCollectorCost){
                createTier2Flower();
                logic.honey-=logic.nectarCollectorCost;
                packetUsed = true;
                tier2PacketUsed = true;
                //9 eternal bloom
                if(itemFlowerClone.tag == "bloomBooster"){
                    tier2FlowerCloneScript.itemFlowerNum = 9;
                }
                //13 bountiful blossom
                if(itemFlowerClone.tag == "perennialCharm"){
                    tier2FlowerCloneScript.itemFlowerNum = 13;
                }
                //16 pollen amplifer
                if(itemFlowerClone.tag == "nectarCollector"){
                    tier2FlowerCloneScript.itemFlowerNum = 16;
                }
                //18 hive pack
                if(itemFlowerClone.tag == "nectarPouch"){
                    tier2FlowerCloneScript.itemFlowerNum = 18;
                }
                //19 chronocomb
                if(itemFlowerClone.tag == "honeycombAccelerator"){
                    tier2FlowerCloneScript.itemFlowerNum = 19;
                }
            }
            if(thisSprite.sprite == honeycombAccelerator && logic.honey >= logic.honeycombAcceleratorCost){
                createTier2Flower();
                logic.honey-=logic.honeycombAcceleratorCost;
                packetUsed = true;
                tier2PacketUsed = true;
                //10 golden conversion
                if(itemFlowerClone.tag == "bloomBooster"){
                    tier2FlowerCloneScript.itemFlowerNum = 10;
                }
                //14 petal spreader
                if(itemFlowerClone.tag == "perennialCharm"){
                    tier2FlowerCloneScript.itemFlowerNum = 14;
                }
                //17 vengeance stinger
                if(itemFlowerClone.tag == "nectarCollector"){
                    tier2FlowerCloneScript.itemFlowerNum = 17;
                }
                //19 chronocomb
                if(itemFlowerClone.tag == "nectarPouch"){
                    tier2FlowerCloneScript.itemFlowerNum = 19;
                }
                //20 honey enricher
                if(itemFlowerClone.tag == "honeycombAccelerator"){
                    tier2FlowerCloneScript.itemFlowerNum = 20;
                }
            }
        }
            gameObject.transform.position = intialPosition;
            if (packetUsed)
            {
                selfRng = true;
                packetUsed = false;
            }

            if(tier2PacketUsed){
                soundManager.instance.playSoundFXClip(packetSound, transform, 0.5f);
                Destroy(itemFlowerClone);
                tier2PacketUsed = false;
            }
        }else{
            if(!colliding){
                gameObject.transform.position = intialPosition;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "flower(Clone)"){
            Debug.Log("AA");
            flower = col.gameObject;
            colliding = true;
        }

        if(col.name == "item flower(Clone)"){
            itemFlowerClone = col.gameObject;
            isTier1Flower = true;
            colliding = true;
        }
    }

        void OnTriggerExit2D(Collider2D col){
        if(col.name == "flower(Clone)"){
            flower = null;
            colliding = false;
        }
        if(col.name == "item flower(Clone)"){
            itemFlowerClone = null;
            isTier1Flower = false;
            colliding = false;
            
            tooltipboxManager._instance.hideTooltip();
        }
    }

    IEnumerator ResetRng()
    {
        yield return new WaitForSeconds(0.00000000001f);
        selfRng = false;
    }
}
