using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject flower;
    public Logic logic;
    public pollenSpawnerScript flowerSpawnerScript;

    public hiveRadial hiveRadialScript;
    
    public bool update = false;
    public bool reset = false;

    //IN FLOWERSCRIPT
    public float NectarCollectorCount;
    public float BloomBoosterCount;
    public int royalInfusionCount;
    public int proboscisSiphonCount;
    public int proboscisSiphonNum;
    public int bountifulBlossomCount;
    
    //IN LOGIC
    public int nectarPouchCount;
    public int BeeBombCount;
    public int perennialCharmCount;
    public int beeBudCount;
    public int hivePackCount;
    
    //IN POLLENCONVERTERSCRIPT
    public int honeycombAccelerator;
    public int honeyEnricherCount;
    public int goldenConversionCount;

    //IN FLOWERSPAWNERSCRIPT
    public int fertilizerCount;
    public int vengeanceStingerCount;
    public int petalSpreaderCount;

    //IN DROPPEDPOLLENSCRIPT
    public int pollenAmpliferCount;
    public int NectarDrainCount;
    public int eternalBloomCount;

    //INTIMER
    public int chronocombCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        hiveRadialScript = GameObject.FindGameObjectWithTag("HiveRadial").GetComponent<hiveRadial>();
        flowerSpawnerScript = GameObject.FindGameObjectWithTag("FlowerSpawner").GetComponent<pollenSpawnerScript>();

        flowerScript[] allFlowers = FindObjectsByType<flowerScript>(FindObjectsSortMode.None);
        //reset = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        flowerScript flowerScriptInstance = flower.GetComponent<flowerScript>();
        pollenConverterScript pollenConverterScriptInstance = GameObject.FindGameObjectWithTag("PollenConverter").GetComponent<pollenConverterScript>();
        flowerSpawnerScript = GameObject.FindGameObjectWithTag("FlowerSpawner").GetComponent<pollenSpawnerScript>();

        flowerScript[] allFlowers = FindObjectsByType<flowerScript>(FindObjectsSortMode.None);
        
        if(update){
            update = false;
            //NECTAR COLLECTOR
            flowerScriptInstance.convertRate = (float)3 - ((float)NectarCollectorCount * 0.2F);

            foreach (flowerScript flower in allFlowers){
                flower.convertRate = (float)3 - ((float)NectarCollectorCount * 0.2F);
            }
            

            //BLOOM BOOSTER
            flowerScriptInstance.pollenSpawnedCount = (float)(1F+(BloomBoosterCount * 1F));

            foreach (flowerScript flower in allFlowers){
                flower.pollenSpawnedCount = (float)(1F+(BloomBoosterCount * 1F));
            }
    
            //NECTAR POUCH + HIVE PACK
            logic.maxBackpackCount = (nectarPouchCount) + (hivePackCount * 3) + 3;

            //PERENNIAL CHARM
            logic.maxFlowers = perennialCharmCount+2;

            //HONEYCOMB ACCELLERATOR
            pollenConverterScriptInstance.convertRate = 6F - (honeycombAccelerator * 0.2F);
            hiveRadialScript.indicatorTimer = pollenConverterScriptInstance.convertRate;
            hiveRadialScript.maxIndicatortimer = pollenConverterScriptInstance.convertRate;


            ////////////
            //BEE BOMB IS IN FLOWERSCRIPT

            //ROYAL INFUSION IN DROPPEDPOLLENSCRIPT

            //POLLEN AMPLIFER IN DROPPEDPOLLENSCRIPT

            //BEE BUD
            

            //FERTILIZER
            flowerSpawnerScript.spawnRate = 3 - ((float)fertilizerCount*0.2F);

            //HONEY ENRICHER
            pollenConverterScriptInstance.amountConverted = 1 + honeyEnricherCount;

            //CHRONOCOMB
            //TODO
            //logic.currentTime = 60 + (10 * chronocombCount);
        }

        if(reset){
            reset = false;

            //NECTAR COLLECTOR
            NectarCollectorCount = 0;
            flowerScriptInstance.convertRate = 3;


            //BLOOM BOOSTER
            BloomBoosterCount = 0;
            flowerScriptInstance.pollenSpawnedCount = 1;

            //NECTAR POUCH
            nectarPouchCount = 0;
            logic.maxBackpackCount = 3;

            //PERENNIAL CHARM
            perennialCharmCount = 0;
            logic.maxFlowers = 2;

            //HONEYCOMB ACCELLERATOR
            honeycombAccelerator = 0;
            pollenConverterScriptInstance.convertRate = 3;
            hiveRadialScript.indicatorTimer = pollenConverterScriptInstance.convertRate;
            hiveRadialScript.maxIndicatortimer = pollenConverterScriptInstance.convertRate;

            //BEE BUD
            beeBudCount = 0;
            logic.maxBees = 1;
            logic.availabeBees = 1;

            //HIVE PACK
            hivePackCount = 0;
            logic.maxBackpackCount = 3;

            //ROYAL INFUSION
            royalInfusionCount = 0;

            //FERTILIZER
            fertilizerCount = 0;
            flowerSpawnerScript.spawnRate = 3;

            //HONEY ENRICHER
            honeyEnricherCount = 0;
            pollenConverterScriptInstance.amountConverted = 1;

            //POLLEN AMP
            pollenAmpliferCount = 0;

            //ETERNAL BLOOM
            eternalBloomCount = 0;

            //BEE BOMB
            BeeBombCount = 0;

            //NECTAR DRAIN
            NectarDrainCount = 0;

            //GOLDEN CONVERSION
            goldenConversionCount = 0;

            //VENGEANCE STINGER
            vengeanceStingerCount = 0;

            //PROBOSCIS SIPHON
            proboscisSiphonCount = 0;
            proboscisSiphonNum = 0;

            //CHOROCOMB
            chronocombCount = 0;

            //PETAL SPREADER
            petalSpreaderCount = 0;

            bountifulBlossomCount = 0;

        }
    }
}
