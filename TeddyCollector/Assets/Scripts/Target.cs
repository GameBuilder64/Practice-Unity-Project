using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    #region

    public GameObject gameObject;
    float distance;

    #endregion

    public Target(GameObject gameObject, Vector3 position)
    {
        this.gameObject = gameObject;
        UpdateDistance(position);
    }

    public GameObject GameObject
    {
        get { return gameObject; }
    }

    public float Distance
    {
        get { return distance; }
    }


    public void UpdateDistance(Vector3 postion)
    {
        distance = Vector3.Distance(gameObject.transform.position, postion);
    }

    /// <summary>
    /// Compares the current instance with another object of the same type
    /// and returns an integer that indicates whether the current instance
    /// precedes, follows, or occurs in the same position in the sort order
    /// as the other object.
    /// </summary>
    public int CompareTo(object obj)
    {

        return 0;
    }

    //Coverts the target to a string
    public override string ToString()
    {
        return "[Target: Distance = " + distance + "]";
    }



}
