using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Toy : MonoBehaviour, IComparable 
{
        #region Fields
        [SerializeField]
        public int HP;

        [SerializeField]
        public int Attack;

        [SerializeField]
        public int Defense;

        [SerializeField]
        public int Intellgence;

        public int battlepower;


        //access battlepower through this get
        public int BattlePower
        {
            get { return battlepower; }
        }

        #endregion




        // Start is called before the first frame update
        void Start()
        {
            //HP = UnityEngine.Random.Range(1, 10);
            //Attack = UnityEngine.Random.Range(1, 10);
            //Defense = UnityEngine.Random.Range(1, 10);
            //Intellgence = UnityEngine.Random.Range(1, 10);

            battlepower = (HP + Attack + Defense + Intellgence);

        }

        // Update is called once per frame
        void Update()
        {

        }

    public int CompareTo(object obj)
    {
        // this instance is greater than a null object
        if (obj == null)
        {
            return 1;
        }

        // check for same object type
        Toy othertoy = obj as Toy;

        if (obj != null)
        {
            // return relative order
            int thisBattlePower = BattlePower;
            int otherBattlePower = othertoy.BattlePower;
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

