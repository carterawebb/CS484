using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // NEED THIS ON START
        //targetPizza.toppings.Add(dough.GetComponent<Dough>());
        //targetPizza.toppings.Add(sauce.GetComponent<Sauce>());
        //targetPizza.toppings.Add(pepperoni.GetComponent<Pepperoni>());

        // OR THIS DURING RUNTIME
        targetPizza.AddTopping(dough.GetComponent<Dough>());
        yield return new WaitForSeconds(0.5f);
        targetPizza.AddTopping(sauce.GetComponent<Sauce>());
        yield return new WaitForSeconds(0.5f);

        // 50/50 for adding cheese
        if (Random.Range(0, 2) == 1)
        {
            targetPizza.AddTopping(cheese.GetComponent<Cheese>());
            yield return new WaitForSeconds(0.5f);
        }

        int numToppingsToAdd = Random.Range(1, 2);
        for (int i = 0; i < numToppingsToAdd; i++)
        {
            AddRandomToppingToTargetPizza();
            yield return new WaitForSeconds(0.5f);
        }
        targetPizza.ready = true;
    }

    private void AddRandomToppingToTargetPizza()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                targetPizza.AddTopping(pepperoni.GetComponent<Pepperoni>());
                break;
            case 1:
                targetPizza.AddTopping(ham.GetComponent<Ham>());
                break;
            case 2:
                targetPizza.AddTopping(bacon.GetComponent<Bacon>());
                break;
            //case 3:
                // may want to disable if basil doesn't work
                //targetPizza.AddTopping(basil.GetComponent<Basil>());
                //break;
        }
    }

    private bool PizzaDone()
    {
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
