using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PizzaManager : MonoBehaviour {
    /// <summary>
    /// This script manages the pizza making process.
    /// 
    /// It should:
    /// - Keep track of the current pizza being made (in a list?)
    /// - Check (when done) if the pizza is correct
    /// - Keep track of the score
    /// - Subtract points for mistakes (extra toppings, wrong toppings, etc.)
    /// - Subtract points for taking too long
    /// 
    /// The user should be able to drag and drop toppings onto the pizza which
    /// will be placed on top of the last thing they dropped it on. The topping models
    /// will be associated with a simplified game object that will be placed on the pizza.
    /// </summary>
    

    [SerializeField] private Pizza pizza;
    [SerializeField] private Pizza targetPizza;

    [SerializeField] private float toppingDistanceThreshold = 1.0f;

    private void Awake()
    {
        //targetPizza = new Pizza();
        //targetPizza.AddTopping(new Pepperoni());
    }

    private void Update()
    {
        if (targetPizza && PizzaDone())
        {
            Debug.Log("Pizza done");
        }
    }

    private bool PizzaDone()
    {
        // CorrectToppings does not work
        return pizza.CorrectToppings(targetPizza);
    }

    public void SomethingGrabbed(GameObject grabbed)
    {
        Topping topping = grabbed.GetComponentInChildren<Topping>();
        if (topping == null)
        {
            Debug.Log("Grabbed something that was not a topping");
            return;
        }

        // duplicate the ingredient, leave one in the old position
        Instantiate(grabbed);
    }

    public void SomethingDropped(GameObject dropped)
    {
        Topping topping = dropped.GetComponentInChildren<Topping>();
        if (topping == null)
        {
            Debug.Log("Dropped something that was not a topping");
            return;
        }

        // check position (near enough to be considered dropped onto the pizza)
        if (Vector3.Distance(dropped.transform.position, pizza.transform.position) <= toppingDistanceThreshold)
        {
            pizza.AddTopping(topping);
        }

        // delete the object (it just got duplicated onto the pizza)
        Destroy(dropped);
    }
}
