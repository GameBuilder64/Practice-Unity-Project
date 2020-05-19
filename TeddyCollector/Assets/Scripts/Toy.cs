﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Toy : MonoBehaviour 
{
    #region Fields
    [SerializeField]
    private int HP;

    [SerializeField]
    private int Attack;

    [SerializeField]
    private int Defense;

    [SerializeField]
    private int Intellgence;

    public int BattlePower
    {
        get { return (HP + Attack + Defense + Intellgence); }
    }

    #endregion




    // Start is called before the first frame update
    void Start()
    {
        HP = UnityEngine.Random.Range(1, 10);
        Attack = UnityEngine.Random.Range(1, 10);
        Defense = UnityEngine.Random.Range(1, 10);
        Intellgence = UnityEngine.Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CompareTheseTwo(Toy OtherToy)
    {
        // this instance is greater than a null object
        if (OtherToy == null)
        {
            return 1;
        }

        // check for same object type
       
        if (OtherToy != null)
        {
            // return relative order
            int thisBattlePower = BattlePower;
            int otherBattlePower = OtherToy.BattlePower;
            if (thisBattlePower < otherBattlePower)
            {
                return -1;
            }
            else if (thisBattlePower == otherBattlePower)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            throw new ArgumentException("Object is not a Toy");
        }
    }

    /// <summary>
    /// Converts the rectangle to a string
    /// </summary>
    /// <returns>the string for the rectangle</returns>
    public override string ToString()
    {
        return "[BattlePower of the toy is " + BattlePower + "]";
    }

}
