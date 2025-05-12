using UnityEngine;

public class packetSpawnerScript : MonoBehaviour
{
    public GameObject packet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject packet1 = Instantiate(packet,new Vector3(-5.885F, -1.601784F, 0),Quaternion.identity);
        GameObject packet2 = Instantiate(packet,new Vector3(-7.677F, -2.649349F, 0),Quaternion.identity);
        GameObject packet3 = Instantiate(packet,new Vector3(-5.885F, -3.692582F, 0),Quaternion.identity);

        packet1.name = "packet1";
        packet2.name = "packet2";
        packet3.name = "packet3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
