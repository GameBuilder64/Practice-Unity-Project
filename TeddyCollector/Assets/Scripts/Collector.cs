using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderedArray;

public class Collector : MonoBehaviour
{
    public OrderedDynamicArray<Toy> CollectorBin;

    public PickupSpawner Pickupspawn;

    //SortedList<Target> targets = new SortedList<Target>();
    public Target targetPickup = null;

    public GameObject TargetObject = null;

    const float BaseImpulseForceMagnitude = 2.0f;
    const float ImpulseForceIncrement = 0.3f;

    // saved for efficiency
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        CollectorBin = new OrderedDynamicArray<Toy>();
        // center collector in sccreen
        Vector3 position = transform.position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        transform.position = position;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            //TheCollectorObject.GetComponent<Collector>().SetTarget(ToySpawnedArray.items[0].ThisGameObject);
            PrintoutEachElementArrayForTest();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == TargetObject)
        {
            //GameObject newtempholder = collision.gameObject;
            //newtempholder.AddComponent<Toy>();
            
            CollectorBin.Add(collision.gameObject.GetComponent<Toy>());
            Pickupspawn.ToySpawnedArray.Remove(collision.gameObject.GetComponent<Toy>());

            Pickupspawn.ToySpawnedArray.Remove(collision.gameObject.GetComponent<Toy>());

            Destroy(collision.gameObject);

            rb2d.velocity = Vector3.zero;

            TargetObject = null;

        }
    }
    
    public void SetTarget(GameObject pickup)
    {
        //targetPickup.gameObject = pickup;
        TargetObject = pickup;
        GoToTargetPickup();
    }

    void GoToTargetPickup()
    {
        /*
        // calculate direction to target pickup
        Vector2 direction = new Vector2(
            targetPickup.gameObject.transform.position.x - transform.position.x,
            targetPickup.gameObject.transform.position.y - transform.position.y);
*/
        Vector2 direction = new Vector2(
    TargetObject.transform.position.x - transform.position.x,
    TargetObject.transform.position.y - transform.position.y);

        direction.Normalize();
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(direction * BaseImpulseForceMagnitude, ForceMode2D.Impulse);
    }

    public void PrintoutEachElementArrayForTest()
    {
        foreach (Toy item in CollectorBin.items)
        {
            Debug.Log("The battlepower of the item is" + item.BattlePower);
        }
    }


}
