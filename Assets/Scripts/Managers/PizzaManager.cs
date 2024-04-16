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
    
    // An array of tuples of game objects and their associated simplified game object


    [SerializeField] private Pizza pizza;
    [SerializeField] private Pizza targetPizza;

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

    public void SomethingDropped(GameObject dropped)
    {
        Topping topping = dropped.GetComponentInChildren<Topping>();
        if (topping == null)
        {
            Debug.Log("Dropped something that was not a topping");
            return;
        }

        // TODO: check position (near enough to be considered dropped onto the pizza)

        pizza.AddTopping(topping);
    }
}
