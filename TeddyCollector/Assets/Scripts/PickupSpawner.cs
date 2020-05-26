using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderedArray;

public class PickupSpawner : MonoBehaviour
{

    public OrderedDynamicArray<Toy> ToySpawnedArray;
    //Public OrderedDynamicArray<GameObject> testarray = new OrderedDynamicArray<GameObject>();
    // needed for spawning
    [SerializeField]
    GameObject prefabPickup;


    public GameObject TheCollectorObject;

    private int count = 0;

    Vector3 location = Vector3.zero;
    float minSpawnX;
    float maxSpawnX;
    float minSpawnY;
    float maxSpawnY;

    // collision-free spawn support
    const int MaxSpawnTries = 20;
    float pickupColliderRadius;
    Vector2 min = new Vector2();
    Vector2 max = new Vector2();


    // resolution support
    const int BaseWidth = 800;
    const int BaseHeight = 600;
    const int BaseBorderSize = 100;
    // Start is called before the first frame update
    void Start()
    {
        ToySpawnedArray = new OrderedDynamicArray<Toy>();
        float widthRatio = (float)Screen.width / BaseWidth;
        float heightRatio = (float)Screen.height / BaseHeight;
        float resolutionRatio = (widthRatio + heightRatio) / 2;
        int spawnBorderSize = (int)(BaseBorderSize * resolutionRatio);

        // save spawn boundaries for efficiency
        Vector3 upperLeftCornerScreen = new Vector3(spawnBorderSize,
            spawnBorderSize, -Camera.main.transform.position.z);
        Vector3 lowerRightCornerScreen = new Vector3(
            Screen.width - spawnBorderSize,
            Screen.height - spawnBorderSize,
            -Camera.main.transform.position.z);
        Vector3 upperLeftCorner = Camera.main.ScreenToWorldPoint(upperLeftCornerScreen);
        Vector3 lowerRightCorner = Camera.main.ScreenToWorldPoint(lowerRightCornerScreen);
        minSpawnX = upperLeftCorner.x;
        maxSpawnX = lowerRightCorner.x;
        minSpawnY = upperLeftCorner.y;
        maxSpawnY = lowerRightCorner.y;

        // spawn and destroy a pickup to cache collider value
        GameObject tempPickup = Instantiate(prefabPickup) as GameObject;
        CircleCollider2D collider = tempPickup.GetComponent<CircleCollider2D>();
        pickupColliderRadius = collider.radius;
        Destroy(tempPickup);
    }

    // Update is called once per frame
    void Update()
    {
        while (count < 10)
        {
            SpawnPickup();
            count++;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            PrintoutEachElementArrayForTest();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            //This was the only way to move towards the object for now, but Need better way 
            //TheCollectorObject.GetComponent<Collector>().SetTarget(ToySpawnedArray.items[0].ThisGameObject);


            if (TheCollectorObject.GetComponent<Collector>().TargetObject == null)
            {
                //Debug.Log("TargetObject is null");
                foreach (Toy item in ToySpawnedArray.items)
                {
                    //Debug.Log("Got the first item");
                    TheCollectorObject.GetComponent<Collector>().SetTarget(item.ThisGameObject);
                    
                    if(TheCollectorObject.GetComponent<Collector>().TargetObject != null)
                    {
                        break;
                    }
                }
            }
        }


    }

    void SpawnPickup()
    {
       
        //generate random location and calculate pickup collision rectangle
        location.x = UnityEngine.Random.Range(minSpawnX, maxSpawnX);
        location.y = UnityEngine.Random.Range(minSpawnY, maxSpawnY);
        SetMinAndMax(location);

        int spawnTries = 1;
        while (Physics2D.OverlapArea(min, max) != null &&
            spawnTries < MaxSpawnTries)
        {
            // change location and calculate new rectangle points
            location.x = UnityEngine.Random.Range(minSpawnX, maxSpawnX);
            location.y = UnityEngine.Random.Range(minSpawnY, maxSpawnY);
            SetMinAndMax(location);

            spawnTries++;
        }


        // create new pickup if found collision-free location
        if (Physics2D.OverlapArea(min, max) == null)
        {
            GameObject pickup = Instantiate<GameObject>(prefabPickup,
                                    location, Quaternion.identity);

            pickup.GetComponent<Toy>().HP = UnityEngine.Random.Range(1, 10);
            pickup.GetComponent<Toy>().Attack = UnityEngine.Random.Range(1, 10);
            pickup.GetComponent<Toy>().Defense = UnityEngine.Random.Range(1, 10);
            pickup.GetComponent<Toy>().Intellgence = UnityEngine.Random.Range(1, 10);

            pickup.GetComponent<Toy>().battlepower = (pickup.GetComponent<Toy>().HP 
                + pickup.GetComponent<Toy>().Attack + pickup.GetComponent<Toy>().Defense + pickup.GetComponent<Toy>().Intellgence);

            pickup.GetComponent<Toy>().ThisGameObject = pickup;

            //adds the item to the Dynamic Arry
            ToySpawnedArray.Add(pickup.GetComponent<Toy>());
            //Debug.Log(pickup.GetComponent<Toy>().battlepower);
            //Debug.Log("BattlePower of Toy is" + ToySpawnedArray.items[0].GetComponent<Toy>().HP);


        }
    }

    void SetMinAndMax(Vector3 location)
    {
        min.x = location.x - pickupColliderRadius;
        min.y = location.y - pickupColliderRadius;
        max.x = location.x + pickupColliderRadius;
        max.y = location.y + pickupColliderRadius;
    }

    public void PrintoutEachElementArrayForTest()
    {
        foreach (Toy item in ToySpawnedArray.items)
        {
            Debug.Log("The battlepower of the item is" + item.BattlePower);
        }
    }


}
