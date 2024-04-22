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

    [SerializeField] private GameObject dough;
    [SerializeField] private GameObject pepperoni;
    [SerializeField] private GameObject sauce;
    [SerializeField] private GameObject pineapple;
    [SerializeField] private GameObject basil;
    [SerializeField] private GameObject ham;
    [SerializeField] private GameObject bacon;
    [SerializeField] private GameObject cheese;
    

    [SerializeField] private float toppingDistanceThreshold = 1.0f;

    private void Awake()
    {
        // overrides the serialized preset pizza
        StartCoroutine(GenerateNewTargetPizza());
    }

    private void Update()
    {
        if (targetPizza && PizzaDone())
        {
            Debug.Log("Pizza done");
        }
    }

    private IEnumerator GenerateNewTargetPizza()
    {
        yield return new WaitForSeconds(0.1f);

        // remove old pizza toppings
        foreach (Transform child in targetPizza.transform)
        {
            Destroy(child.gameObject);
        }
        targetPizza.toppings.Clear();


        // TODO: (mary) logic here for random toppings
        // use AddTopping as shown below (76-78).
        // put yield return new WaitForSeconds(0.5f);
        // in between AddTopping calls to allow the ingredients to fall properly


        // for now hard coded

        // NEED THIS ON START
        //targetPizza.toppings.Add(dough.GetComponent<Dough>());
        //targetPizza.toppings.Add(sauce.GetComponent<Sauce>());
        //targetPizza.toppings.Add(pepperoni.GetComponent<Pepperoni>());

        // OR THIS DURING RUNTIME
        targetPizza.AddTopping(dough.GetComponent<Dough>());
        yield return new WaitForSeconds(0.5f);
        targetPizza.AddTopping(sauce.GetComponent<Sauce>());
        yield return new WaitForSeconds(0.5f);
        targetPizza.AddTopping(pepperoni.GetComponent<Pepperoni>());
    }

    private bool PizzaDone()
    {
        // TODO: (mary) when is a pizza done? Right now this is called every frame
        // CorrectToppings does not work
        return pizza.CorrectToppings(targetPizza);
    }

    public void SomethingGrabbed(GameObject grabbed)
    {
        grabbed.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Topping topping = grabbed.GetComponent<Topping>();
        if (topping == null)
        {
            Debug.Log("Grabbed something that was not a topping");
            return;
        }
        
        // duplicate the ingredient, leave one in the old position
        GameObject duplicate = Instantiate(grabbed);
        duplicate.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void SomethingDropped(GameObject dropped)
    {
        Topping topping = dropped.GetComponent<Topping>();
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
