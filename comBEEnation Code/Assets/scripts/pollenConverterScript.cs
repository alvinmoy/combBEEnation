using UnityEngine;

public class pollenConverterScript : MonoBehaviour
{
    public bool converting = false;
    private float timer;
    public float convertRate;
    public Logic logic;
    public Item item;
    public hiveRadial hiveRadialScript;
    public int amountConverted;
    public bool selfConverting;

    public bool inRadius;

    public AudioClip honeySound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();
        hiveRadialScript = GameObject.FindGameObjectWithTag("HiveRadial").GetComponent<hiveRadial>();

        hiveRadialScript.indicatorTimer = convertRate;
        hiveRadialScript.maxIndicatortimer = convertRate;
        hiveRadialScript.radialIndicatorUI.enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {   
        if(logic.pollen > 0){
            selfConverting = true;
            hiveRadialScript.working = true;
        }else{
            selfConverting = false;
            hiveRadialScript.working = false;
        }

        if(logic.playing){
            if(logic.pollen <= 0 ){
                hiveRadialScript.radialIndicatorUI.gameObject.SetActive(false);
                converting = false;
                hiveRadialScript.indicatorTimer = hiveRadialScript.maxIndicatortimer;
            }else{
                hiveRadialScript.radialIndicatorUI.gameObject.SetActive(true);
            }
            
            if (selfConverting && logic.pollen > 0){
                hiveRadialScript.radialIndicatorUI.gameObject.SetActive(true);
                if(hiveRadialScript.indicatorTimer <= 0){
                    if(goldenConversionChance(item.goldenConversionCount)){
                        logic.honey += logic.pollen;
                        logic.pollen = 0;
                    }

                    //HONEY ENRICHER
                    if(logic.pollen - amountConverted >= 0){
                        logic.pollen = logic.pollen - amountConverted;
                        logic.honey += amountConverted;
                        logic.totalHoney += amountConverted;
                        
                        soundManager.instance.playSoundFXClip(honeySound, transform, 0.5f);
                    }else{
                        logic.honey += logic.pollen;
                        logic.pollen = 0;
                        
                        soundManager.instance.playSoundFXClip(honeySound, transform, 0.5f);
                    }
                    logic.pollenCountText.text = logic.pollen.ToString() + "/" + logic.maxBackpackCount.ToString();
                    logic.honeyCountText.text = logic.honey.ToString();
                    if(logic.pollen > 0){
                        hiveRadialScript.indicatorTimer = hiveRadialScript.maxIndicatortimer;
                    }
                }
            }

            // if(!inRadius){
            //     hiveRadialScript.working = false;
            //     converting = false;
            // }
        }else{
            hiveRadialScript.radialIndicatorUI.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown(){
        if(logic.pollen > 0){
            hiveRadialScript.working = true;
            converting = true;
        }
    }

    private void OnMouseUp(){
        hiveRadialScript.working = false;
        converting = false;

        //timer = timer + Time.deltaTime;
    }

    private void OnMouseEnter(){
        inRadius = true;
    }

    private void OnMouseExit(){
        inRadius = false;
    }

    bool goldenConversionChance(float count){
        float goldenConversionNum = Random.value;
        if(count*0.01 >= goldenConversionNum && item.goldenConversionCount > 0){
            return true;
        }else{
            return false;
        }
    }
}
