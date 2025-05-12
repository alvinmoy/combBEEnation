using System.Threading.Tasks;
using System.Collections; 

using UnityEngine;

public class beeBombScript : MonoBehaviour
{

    public Logic logic;
    public Item item;

    public GameObject flower;
    public Collider2D flowerCollider;
    public Collider2D selfCollider;

    Collider2D[] colliders;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();

        StartCoroutine(removeBeebomb());

        flowerCollider = flower.GetComponent<CircleCollider2D>();
        selfCollider = gameObject.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator removeBeebomb(){
        colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
        yield return new WaitForSeconds(1);

        foreach (Collider2D collider in colliders){
            colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
            if (collider != null && collider.CompareTag("Flower") )
            {
                //Debug.Log("Flower detected inside the circle!");
                flowerScript flowerScriptInstance = collider.GetComponent<flowerScript>();

                if (flowerScriptInstance != null)
                {
                    flowerScriptInstance.clickCount = flowerScriptInstance.maxClickCount;
                    flowerScriptInstance.wasSetByBeeBomb = true;
                }
                //flower.GetComponent<flowerScript>().clickCount = flower.GetComponent<flowerScript>().maxClickCount;
            }
        }
        Destroy(gameObject);
    }

}
