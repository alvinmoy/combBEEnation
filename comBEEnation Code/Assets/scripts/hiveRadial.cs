using UnityEngine;
using UnityEngine.UI;

public class hiveRadial : MonoBehaviour
{

    public float indicatorTimer = 1.0f;
    public float maxIndicatortimer = 1.0f;

    public Image radialIndicatorUI;

    public bool shouldUpdate = false;
    public bool working = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pollenConverterScript pollenConverterScriptInstance = GameObject.FindGameObjectWithTag("PollenConverter").GetComponent<pollenConverterScript>();

        indicatorTimer = pollenConverterScriptInstance.convertRate;
        maxIndicatortimer = pollenConverterScriptInstance.convertRate;
    }

    // Update is called once per frame
    void Update()
    {
        pollenConverterScript pollenConverterScriptInstance = GameObject.FindGameObjectWithTag("PollenConverter").GetComponent<pollenConverterScript>();
        if(working){
            if(pollenConverterScriptInstance.converting && pollenConverterScriptInstance.inRadius){
                indicatorTimer -=Time.deltaTime*2;
                radialIndicatorUI.enabled = true;
                radialIndicatorUI.fillAmount = indicatorTimer/maxIndicatortimer;
            }

            if(pollenConverterScriptInstance.selfConverting){
                indicatorTimer -=Time.deltaTime;
                radialIndicatorUI.enabled = true;
                radialIndicatorUI.fillAmount = indicatorTimer/maxIndicatortimer;
            }
            

            if(indicatorTimer <= 0){
                //Debug.Log("HI");
                radialIndicatorUI.fillAmount = maxIndicatortimer/maxIndicatortimer;
                radialIndicatorUI.enabled = false;
                radialIndicatorUI.gameObject.SetActive(false);
            }
        }else{
            if(shouldUpdate){
                indicatorTimer += Time.deltaTime/3;
                radialIndicatorUI.fillAmount = (indicatorTimer/maxIndicatortimer);

                if(indicatorTimer >= maxIndicatortimer){
                    radialIndicatorUI.enabled = false;
                    radialIndicatorUI.gameObject.SetActive(false);
                    shouldUpdate = false;
                    indicatorTimer = maxIndicatortimer;
                }
            }
        }

        if(working){
            shouldUpdate = true;
        }    
    }
}
