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
    
    // An array of tuples of game objects and their associated simplified game objects
    private GameObject[,] pizzaModelWithSimplified;

    [Header("Toppings")]
    [SerializeField] public GameObject[] toppings;
    [SerializeField] public GameObject[] simplifiedToppings;

    private void Start() {
        pizzaModelWithSimplified = new GameObject[toppings.Length, 2];
        for (int i = 0; i < toppings.Length; i++) {
            pizzaModelWithSimplified[i, 0] = toppings[i];
            pizzaModelWithSimplified[i, 1] = simplifiedToppings[i];
        }
    }
}
