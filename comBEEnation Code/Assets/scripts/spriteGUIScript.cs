using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class spriteGUIScript : MonoBehaviour
{
    public Logic logic;
    public Item item;

    private Image thisSprite;
    public TextMeshProUGUI thisText;

    public GameObject itemDescription;
    public GameObject canvas;
    public GameObject itemDescriptionClone;
    public Image itemDescriptionCloneImage;
    public TextMeshProUGUI itemCloneText;
    public TextMeshProUGUI itemDescriptionCloneText;


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

    public string itemString;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();

        itemDescriptionClone = Instantiate(itemDescription,new Vector3(10, -2, 0),Quaternion.identity);
        itemDescriptionClone.transform.SetParent(canvas.transform, false);

        itemDescriptionCloneImage = itemDescriptionClone.transform.Find("itemImage").GetComponent<Image>();
        itemCloneText = itemDescriptionClone.transform.Find("itemText").GetComponent<TextMeshProUGUI>();
        itemDescriptionCloneText = itemDescriptionClone.transform.Find("itemDescription").GetComponent<TextMeshProUGUI>();
        itemDescriptionCloneImage.preserveAspect = true;
        Fade();
        StartCoroutine(killItemDescription(itemDescriptionClone));
         
    }

    IEnumerator enable()
    {
        yield return new WaitForSeconds(0.01f);

        
        itemDescriptionClone.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    void Fade(){
        itemDescriptionCloneImage.CrossFadeAlpha(1,1.0F,false);
    }

    // Update is called once per frame
    void Update()
    {
        thisSprite = gameObject.GetComponent<Image>();
        thisSprite.preserveAspect = true;

        
        
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();

        if(itemString == "bloomBooster"){
            thisSprite.sprite = pollenPendant;
            itemDescriptionCloneImage.sprite = pollenPendant;
            itemCloneText.text = "Pollen Pendant";
            itemDescriptionCloneText.text = "More pollen dropped for each flower harvested";
            thisText.text = item.BloomBoosterCount.ToString();
        }
        
        if(itemString == "perennialCharm"){
            thisSprite.sprite = queensGrain;
            itemDescriptionCloneImage.sprite = queensGrain;
            itemCloneText.text = "Carpenter's Grain";
            itemDescriptionCloneText.text = "Increased max flower spawn rate";
            thisText.text = item.perennialCharmCount.ToString();
        }

        if(itemString == "nectarCollector"){
            thisSprite.sprite = electricTippedProb;
            itemDescriptionCloneImage.sprite = electricTippedProb;
            itemCloneText.text = "Electric Proboscis";
            itemDescriptionCloneText.text = "Swifter flower harvest rate";
            thisText.text = item.NectarCollectorCount.ToString();
            
        }

        if(itemString == "nectarPouch"){
            thisSprite.sprite = propolisPouch;
            itemDescriptionCloneImage.sprite = propolisPouch;
            itemCloneText.text = "Propolis Pouch";
            itemDescriptionCloneText.text = "Additional pollen storage";
            thisText.text = item.nectarPouchCount.ToString();
            
        }

        if(itemString == "honeycombAccelerator"){
            thisSprite.sprite = copperWings;
            itemDescriptionCloneImage.sprite = copperWings;
            itemCloneText.text = "Copper Wing";
            itemDescriptionCloneText.text = "Hastier honey conversion";
            thisText.text = item.honeycombAccelerator.ToString();
            
        }

        if(itemString == "royalInfusion"){
            thisSprite.sprite = apiaristsInfusion;
            itemDescriptionCloneImage.sprite = apiaristsInfusion;
            itemCloneText.text = "Aparist's Infusion";
            itemDescriptionCloneText.text = "Pollen collection is worth more";
            thisText.text = item.royalInfusionCount.ToString();
            
        }

        if(itemString == "beeBomb"){
            thisSprite.sprite = beeSwarm;
            itemDescriptionCloneImage.sprite = beeSwarm;
            itemCloneText.text = "Bee Swarm";
            itemDescriptionCloneText.text = "Chance to drop a bee bomb";
            thisText.text = item.BeeBombCount.ToString();
            
        }

        if(itemString == "nectarDrain"){
            thisSprite.sprite = sucroseLodestone;
            itemDescriptionCloneImage.sprite = sucroseLodestone;
            itemCloneText.text = "Sucrose Lodstone";
            itemDescriptionCloneText.text = "Droppables move towards you";
            thisText.text = item.NectarDrainCount.ToString();
        }

        if(itemString == "eternalBloom"){
            thisSprite.sprite = eternalMist;
            itemDescriptionCloneImage.sprite = eternalMist;
            itemCloneText.text = "Eternal Mist";
            itemDescriptionCloneText.text = "Droppables have longer life";
            thisText.text = item.eternalBloomCount.ToString();
        }

        if(itemString == "goldenConversion"){
            thisSprite.sprite = waxSiphon;
            itemDescriptionCloneImage.sprite = waxSiphon;
            itemCloneText.text = "Wax Siphon";
            itemDescriptionCloneText.text = "Chance to convert all pollen into honey";
            thisText.text = item.goldenConversionCount.ToString();
        }

        if(itemString == "fertilizer"){
            thisSprite.sprite = queensWateringPot;
            itemDescriptionCloneImage.sprite = queensWateringPot;
            itemCloneText.text = "Queen's Watering Pot";
            itemDescriptionCloneText.text = "Flowers spawn rate is increased";
            thisText.text = item.fertilizerCount.ToString();
        }

        if(itemString == "proboscisSiphon"){
            thisSprite.sprite = petalExtractor;
            itemDescriptionCloneImage.sprite = petalExtractor;
            itemCloneText.text = "Petal Extractor";
            itemDescriptionCloneText.text = "Instantly remove a flower";
            thisText.text = item.proboscisSiphonCount.ToString();
        }

        if(itemString == "bountifulBlossom"){
            thisSprite.sprite = luckyStamen;
            itemDescriptionCloneImage.sprite = luckyStamen;
            itemCloneText.text = "Lucky Stamen";
            itemDescriptionCloneText.text = "Chance to drop lucky pollen";
            thisText.text = item.bountifulBlossomCount.ToString();
        }

        if(itemString == "petalSpreader"){
            thisSprite.sprite = perennialCharm;
            itemDescriptionCloneImage.sprite = perennialCharm;
            itemCloneText.text = "Perennial Charm";
            itemDescriptionCloneText.text = "Chance to spawn a flower near an existing one";
            thisText.text = item.petalSpreaderCount.ToString();
        }

        if(itemString == "beeBud"){
            thisSprite.sprite = broodBud;
            itemDescriptionCloneImage.sprite = broodBud;
            itemCloneText.text = "Brood Bud";
            itemDescriptionCloneText.text = "Gain another friend";
            thisText.text = item.beeBudCount.ToString();
        }

        if(itemString == "pollenAmplifer"){
            thisSprite.sprite = royalFertilizer;
            itemDescriptionCloneImage.sprite = royalFertilizer;
            itemCloneText.text = "Royal Fertilizer";
            itemDescriptionCloneText.text = "Droppables increase in size";
            thisText.text = item.pollenAmpliferCount.ToString();
        }

        if(itemString == "vengeanceStinger"){
            thisSprite.sprite = vengeanceStinger;
            itemDescriptionCloneImage.sprite = vengeanceStinger;
            itemCloneText.text = "Vengeance Stinger";
            itemDescriptionCloneText.text = "Chance to half flower harvest rate";
            thisText.text = item.vengeanceStingerCount.ToString();
        }
        
        if(itemString == "hivePack"){
            thisSprite.sprite = hivePack;
            itemDescriptionCloneImage.sprite = hivePack;
            itemCloneText.text = "Hive Pack";
            itemDescriptionCloneText.text = "Gain even greater storage for pollen";
            thisText.text = item.hivePackCount.ToString();
        }

        if(itemString == "chronocomb"){
            thisSprite.sprite = chronoComb;
            itemDescriptionCloneImage.sprite = chronoComb;
            itemCloneText.text = "Chronocomb";
            itemDescriptionCloneText.text = "Gain more time for the next day";
            thisText.text = item.chronocombCount.ToString();
        }

        if(itemString == "honeyEnricher"){
            thisSprite.sprite = obsidianOcelus;
            itemDescriptionCloneImage.sprite = obsidianOcelus;
            itemCloneText.text = "Obsidian Ocelus";
            itemDescriptionCloneText.text = "Convert more pollen into honey";
            thisText.text = item.honeyEnricherCount.ToString();
        }
        
    }

    IEnumerator killItemDescription(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        LeanTween.alpha(obj, 0f, 1f).setOnComplete(destroyGUI);
    }

    void destroyGUI(){
        Destroy(itemDescriptionClone);
    }
}
