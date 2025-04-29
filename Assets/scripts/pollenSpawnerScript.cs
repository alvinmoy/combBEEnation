using UnityEngine;
using System.Collections.Generic;

public class pollenSpawnerScript : MonoBehaviour
{
    public GameObject flower;
    public Logic logic;
    public Item item;
    public float spawnRate = 1;
    private float timer = 0;

    public GameObject canvas;

    GameObject flowerClone = null;
    flowerScript flowerCloneScript = null;
    Vector3 spawnPosition;

    GameObject[] flowerClones;
    GameObject flowerCloneReference;

    // public AudioClip spawnSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();
        // spawnFlower();
        // logic.maxFlowersCount = 1;

        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.playing){
            flowerClones = GameObject.FindGameObjectsWithTag("Flower");
            if(flowerClones.Length > 0){
                flowerCloneReference = flowerClones[Random.Range(0, flowerClones.Length)];
            }
            if (timer < spawnRate){
            timer = timer + Time.deltaTime;
            }else{
                if(logic.maxFlowers > logic.maxFlowersCount){
                    spawnFlower();
                    logic.maxFlowersCount++;
                }
                timer = 0;
            }
        }
    }

    Vector3? FindValidPosition() {
        Vector3 randomPosition;
        
        if (petalSpreaderChance(item.petalSpreaderCount) && flowerCloneReference != null) {
            flowerCloneReference = flowerClones[Random.Range(0, flowerClones.Length)];

            for(int j = 0; j < 150; j++){
                int randY = Random.Range(-1, 1);
                int randX = Random.Range(-1, 1);

                while(randX == 0 && randY == 0){
                    randX = Random.Range(-1, 1);
                    randY = Random.Range(-1, 1);
                }

                if (flowerCloneReference != null) {
                    randomPosition = new Vector3(
                        flowerCloneReference.transform.position.x - randX,
                        flowerCloneReference.transform.position.y - randY,
                        0
                    );

                    if (!logic.positionList.Contains(randomPosition) && randomPosition != flowerCloneReference.transform.position){
                        if(randomPosition.x <= 5 && randomPosition.x >= -4 && randomPosition.y <= 2 && randomPosition.y >= -4){
                            logic.positionList.Add(randomPosition);
                            return randomPosition;
                        }
                    }
                    flowerCloneReference = flowerClones[Random.Range(0, flowerClones.Length)];
                }
            }
            
            int minX = -4, maxX = 5, minY = -4, maxY = 2;

            for (int i = 0; i < 150; i++) {
                randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

                if (!logic.positionList.Contains(randomPosition)) {
                    logic.positionList.Add(randomPosition);
                    return randomPosition;
                }
            }

            if (!logic.positionList.Contains(Vector3.zero)) {
                
                logic.positionList.Add(Vector3.zero);
                return Vector3.zero;
            }
            
        }else{
            int minX = -4, maxX = 5, minY = -4, maxY = 2;

            for (int i = 0; i < 150; i++) {
                randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

                if (!logic.positionList.Contains(randomPosition)) {
                    logic.positionList.Add(randomPosition);
                    return randomPosition;
                }

                if (!logic.positionList.Contains(Vector3.zero)) {
                
                logic.positionList.Add(Vector3.zero);
                return Vector3.zero;
            }
            }
        }
        return null;
    }
        

    void spawnFlower(){
    flowerClone = null;
    flowerCloneScript = null;

    // Get the position returned from FindValidPosition
    Vector3? tempSpawnPosition = FindValidPosition();

    // Check if the position is null
    if (tempSpawnPosition.HasValue) {
        spawnPosition = tempSpawnPosition.Value;
        flowerClone = Instantiate(flower, spawnPosition, transform.rotation);
        // soundManager.instance.playSoundFXClip(spawnSound, transform, 0.5f);
    } else {
        Debug.LogWarning("No valid position found for spawning.");
    }

    

    if (flowerClone != null) {
        flowerCloneScript = flowerClone.GetComponent<flowerScript>();
    }

    if (vengeanceStingerChance(item.vengeanceStingerCount)) {
        flowerCloneScript.isVengeanceStinger = true;
        flowerCloneScript.convertRate /= 2;
    }
}

    bool vengeanceStingerChance(float count){
        float vengeanceStingerNum = Random.value;
        if(count*0.1 >= vengeanceStingerNum && item.vengeanceStingerCount > 0){
            return true;
        }else{
            return false;
        }
    }

    bool petalSpreaderChance(float count){
        float petalSpreaderNum = Random.value;
        if(count*0.1 >= petalSpreaderNum && item.petalSpreaderCount > 0){
            return true;
        }else{
            return false;
        }
    }

}

// Vector3? FindValidPosition() {
//         Vector3 randomPosition;
//         int minX1 = 3, maxX1 = 6, minY1 = 0, maxY1 = 2;
//         int randX = Random.Range(3,6), randY = Random.Range(0,2);
//         if (petalSpreaderChance(item.petalSpreaderCount) && flowerCloneReference != null){
//             Debug.Log("PETALL");
//             for (int i = 0; i < 150; i++) {
//                 do{
//                     randomPosition = new Vector3(randX, randY, 0);
//                     randomPosition += new Vector3(
//                     flowerCloneReference.transform.position.x - randomPosition.x,
//                     flowerCloneReference.transform.position.y - randomPosition.y,
//                     0);
//                 }while(randX == 4 && !logic.positionList.Contains(randomPosition));
                
//                 Debug.Log(randomPosition);
//                 if (!logic.positionList.Contains(randomPosition)) {
//                     logic.positionList.Add(randomPosition);
//                     return randomPosition;
//                 }
//             }
//         }else{
//             int minX = -4, maxX = 5, minY = -4, maxY = 3;
//             Debug.Log("ELSE");
//             if (!logic.positionList.Contains(Vector3.zero)) {
//                 logic.positionList.Add(Vector3.zero);
//                 return Vector3.zero;
//             }

//             for (int i = 0; i < 150; i++) {
//                 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

//                 if (!logic.positionList.Contains(randomPosition)) {
//                     logic.positionList.Add(randomPosition);
//                     return randomPosition;
//                 }
//             }
//         }
//         return null;
//     }
