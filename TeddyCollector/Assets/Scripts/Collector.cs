using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    //SortedList<Target> targets = new SortedList<Target>();
    Target targetPickup = null;


    const float BaseImpulseForceMagnitude = 2.0f;
    const float ImpulseForceIncrement = 0.3f;

    // saved for efficiency
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == targetPickup.GameObject)
        {
            // add remove collected pickup from list of targets and game
            // go to next target if there is one

        }
    }
    
    void SetTarget(GameObject pickup)
    {
        targetPickup.gameObject = pickup;
        GoToTargetPickup();
    }

    void GoToTargetPickup()
    {
        // calculate direction to target pickup
        Vector2 direction = new Vector2(
            targetPickup.gameObject.transform.position.x - transform.position.x,
            targetPickup.gameObject.transform.position.y - transform.position.y);
        direction.Normalize();
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(direction * BaseImpulseForceMagnitude, ForceMode2D.Impulse);
    }


}
