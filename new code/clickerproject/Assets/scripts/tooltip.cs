using UnityEngine;

public class tooltip : MonoBehaviour
{
    public string message;
    public SpriteRenderer thisSprite;

    public tooltipboxManager tt;

    public Sprite bloomBoosterPacket;
    public Sprite perennialCharmPacket;
    public Sprite nectarCollectorPacket;
    public Sprite nectarPouchPacket;
    public Sprite honeycombAcceleratorPacket;

    public GameObject packet1;
    public GameObject packet2;
    public GameObject packet3;

    public gameworldDragAndDrop packet1Script;
    public gameworldDragAndDrop packet2Script;
    public gameworldDragAndDrop packet3Script;

    void Start(){
        thisSprite = gameObject.GetComponent<SpriteRenderer>();

        packet1 = GameObject.Find("packet1");
        packet2 = GameObject.Find("packet2");
        packet3 = GameObject.Find("packet3");

        packet1Script = packet1.GetComponent<gameworldDragAndDrop>();
        packet2Script = packet2.GetComponent<gameworldDragAndDrop>();
        packet3Script = packet3.GetComponent<gameworldDragAndDrop>();
    }


    private void OnMouseEnter(){
        if(gameObject.name == "pouchBook"){
            tooltipboxManager._instance.setAndShowToolTip("Additional pollen storage", "Propolis Pouch");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket);
        }

        if(gameObject.name == "wingBook"){
            tooltipboxManager._instance.setAndShowToolTip("Hastier honey conversion", "Copper Wing");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.honeycombAcceleratorPacket);
        }

        if(gameObject.name == "probBook"){
            tooltipboxManager._instance.setAndShowToolTip("Swifter flower harvest rate", "Electric Proboscis");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket);
        }

        if(gameObject.name == "grainBook"){
            tooltipboxManager._instance.setAndShowToolTip("Increased max flower spawn rate", "Carpenter's Grain");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket);
        }

        if(gameObject.name == "pendantBook"){
            tooltipboxManager._instance.setAndShowToolTip("More pollen dropped for each flower harvested", "Pollen Pendant");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket);
        }

        if(gameObject.name == "fertilizerBook"){
            tooltipboxManager._instance.setAndShowToolTip("Droppables increase in size", "Royal Fertilizer");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.nectarCollectorPacket);
        }

        if(gameObject.name == "hiveBook"){
            tooltipboxManager._instance.setAndShowToolTip("Gain even greater storage for pollen", "Hive Pack");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.nectarPouchPacket);
        }

        if(gameObject.name == "mistBook"){
            tooltipboxManager._instance.setAndShowToolTip("Droppables have longer life", "Eternal Mist");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.bloomBoosterPacket);
        }

        if(gameObject.name == "luckyBook"){
            tooltipboxManager._instance.setAndShowToolTip("Chance to drop lucky pollen", "Lucky Stamen");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.perennialCharmPacket);
        }

        if(gameObject.name == "combBook"){
            tooltipboxManager._instance.setAndShowToolTip("Gain more time for the next day", "Chronochomb");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
        }

        if(gameObject.name == "extractorBook"){
            tooltipboxManager._instance.setAndShowToolTip("Instantly remove a flower", "Petal Extractor");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.nectarCollectorPacket);
        }

        if(gameObject.name == "bombBook"){
            tooltipboxManager._instance.setAndShowToolTip("Chance to drop a bee bomb", "Bee Swarm");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.bloomBoosterPacket);
        }

        if(gameObject.name == "waterBook"){
            tooltipboxManager._instance.setAndShowToolTip("Flowers spawn rate is increased", "Queen's Watering Pot");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.perennialCharmPacket);
        }

        if(gameObject.name == "charmBook"){
            tooltipboxManager._instance.setAndShowToolTip("Chance to spawn a flower near an existing one", "Perennial Charm");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
        }

        if(gameObject.name == "budBook"){
            tooltipboxManager._instance.setAndShowToolTip("Gain another friend", "Brood Bud");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.nectarCollectorPacket);
        }

        if(gameObject.name == "sucroseBook"){
            tooltipboxManager._instance.setAndShowToolTip("Droppables move towards you", "Sucrose Lodestone");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.bloomBoosterPacket);
        }

        if(gameObject.name == "stingerBook"){
            tooltipboxManager._instance.setAndShowToolTip("Chance to half flower harvest rate", "Vengeance Stinger");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
        }

        if(gameObject.name == "infusionBook"){
            tooltipboxManager._instance.setAndShowToolTip("Pollen collection is worth more", "Aparist's Infusion");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket,tooltipboxManager._instance.bloomBoosterPacket);
        }

        if(gameObject.name == "siphonBook"){
            tooltipboxManager._instance.setAndShowToolTip("Chance to convert all pollen into honey", "Wax Siphon");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
        }

        if(gameObject.name == "obsidianBook"){
            tooltipboxManager._instance.setAndShowToolTip("Convert more pollen into honey",  "Obsidian Ocelus");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.honeycombAcceleratorPacket,tooltipboxManager._instance.honeycombAcceleratorPacket);
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if((gameObject.name == "packet1" || gameObject.name == "packet2" || gameObject.name == "packet3") && gameObject.CompareTag("nectarPouchPacket") 
        && !packet1Script.isDragging && !packet2Script.isDragging && !packet3Script.isDragging){
            tooltipboxManager._instance.setAndShowToolTip("Additional pollen storage", "Propolis Pouch");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarPouchPacket);
        }
        
        if((gameObject.name == "packet1" || gameObject.name == "packet2" || gameObject.name == "packet3") && gameObject.CompareTag("bloomBoosterPacket") 
        && !packet1Script.isDragging && !packet2Script.isDragging && !packet3Script.isDragging){
            tooltipboxManager._instance.setAndShowToolTip("More pollen dropped for each flower harvested", "Pollen Pendant");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.bloomBoosterPacket);
        }

        if((gameObject.name == "packet1" || gameObject.name == "packet2" || gameObject.name == "packet3") && gameObject.CompareTag("honeycombAcceleratorPacket") 
        && !packet1Script.isDragging && !packet2Script.isDragging && !packet3Script.isDragging){
            tooltipboxManager._instance.setAndShowToolTip("Hastier honey conversion", "Copper Wing");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.honeycombAcceleratorPacket);
        }

        if((gameObject.name == "packet1" || gameObject.name == "packet2" || gameObject.name == "packet3") && gameObject.CompareTag("nectarCollectorPacket") 
        && !packet1Script.isDragging && !packet2Script.isDragging && !packet3Script.isDragging){
            tooltipboxManager._instance.setAndShowToolTip("Swifter flower harvest rate", "Electric Proboscis");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.nectarCollectorPacket);
        }

        if((gameObject.name == "packet1" || gameObject.name == "packet2" || gameObject.name == "packet3") && gameObject.CompareTag("perennialCharmPacket") 
        && !packet1Script.isDragging && !packet2Script.isDragging && !packet3Script.isDragging){
            tooltipboxManager._instance.setAndShowToolTip("Increased max flower spawn rate", "Carpenter's Grain");
            tooltipboxManager._instance.setImage(tooltipboxManager._instance.perennialCharmPacket);
        }
    }

    private void OnMouseExit(){
        tooltipboxManager._instance.hideTooltip();
    }
}
