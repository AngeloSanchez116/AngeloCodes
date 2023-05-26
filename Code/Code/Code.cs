using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Code : MonoBehaviour
{

    public int value = 0;
    public string name = "Angelo";
    public float fValue = 1.5f;
    public double fValue2 = 1.6f;

    public int[] valueList = {1,2,3,4,5,6};
    public List<float> valueList2 = new List<float>();

    [SerializeField]
    private Transform gameobjectTransform;

    private int hiddenvalue = 100;
    [SerializeField]
    private float privatedValue; // that you can see in the inspector
    protected int value3;

    private void Start()
    {
        value = 10;
        name = "Code";

        gameobjectTransform = GetComponent<Transform>(); 
    }

    private void Update()
    {
        print("Hello Whoever is reading this");
        Debug.Log("I hope this makes the cut");

        switch (value) { 
        
            case 0:
                // do action if value equal case number
                break;
        }

        for (int i = 0; i < hiddenvalue; i++)
        {
            if (hiddenvalue == i)
            {
                //loop unto 99
            }
        }

        while (value < hiddenvalue) { 
        
            //keeps looping unto value is greater than hiddenvalue;
        }

        do 
        { 
            //does the action at least once before is checking condition
        } 
        while (value3 < hiddenvalue);
        
    }


    public void myfunction()
    {
        seccondFunc(value);// function can call other functions

        if (value > hiddenvalue)
        {

            // do action if condition is true;
        }
        else if (value < hiddenvalue)
        {

            //do action if the pervious condition is  false;
        }
        else
        {

            //do action if all pervious condition are false;
        }
    }

    public void seccondFunc(int value) { 
    
        //the function can takes a value
    
    }
}

public class Code2 : Code 
{
    //Code2 reference code

    public void function3() { 
    
        myfunction();// you can call a function that you refernece

    }
}
