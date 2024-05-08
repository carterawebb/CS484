using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private float pizzaToppingOffset = 0.05f;
    public List<Topping> toppings = new List<Topping>();
    public bool ready = false;

    public void Start()
    {
        float offset = 0.05f;
        foreach (Topping topping in toppings)
        {
            GameObject obj = Instantiate(topping.GetSimplifiedMapping(), transform);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + offset, obj.transform.position.z);
            obj.transform.rotation *= Quaternion.Euler(Vector3.up * Random.Range(0, 360));
            // apply gravity
            obj.GetComponent<Rigidbody>().useGravity = true;
            offset += 0.05f;
        }
    }

    public void AddTopping(Topping topping)
    {
        toppings.Add(topping);
        GameObject obj = Instantiate(topping.GetSimplifiedMapping(), transform);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pizzaToppingOffset, obj.transform.position.z);
        obj.transform.rotation *= Quaternion.Euler(Vector3.up * Random.Range(0, 360));
        // apply gravity
        obj.GetComponent<Rigidbody>().useGravity = true;
    }

    public bool CorrectToppingsAndNumber(Pizza pizza)
    {
        if (toppings.Count != pizza.toppings.Count)
        {
            return false;
        }

        foreach (Topping topping in toppings)
        {
            if (pizza.CountTopping(topping.name) != CountTopping(topping.name))
            {
                return false;
            }
        }
        return true;
    }

    /*public bool correctToppingsOrder(Pizza pizza)
    {

    }*/

    public bool CorrectToppings(Pizza pizza)
    {
        if (!pizza.ready)
        {
            return false;
        }

        foreach (Topping topping in toppings)
        {
            bool found = false;
            foreach (Topping topping2 in pizza.toppings)
            {
                if (topping.GetName() == topping2.GetName())
                {
                    found = true;
                }
            }
            if (!found)
            {
                return false;
            }
        }

        foreach (Topping topping in pizza.toppings)
        {
            bool found = false;
            foreach (Topping topping2 in toppings)
            {
                if (topping.GetName() == topping2.GetName())
                {
                    found = true;
                }
            }
            if (!found)
            {
                return false;
            }
        }
        return true;
    }

    public int CountTopping(string name)
    {
        int count = 0;
        foreach (Topping topping in toppings)
        {
            if (topping.name == name)
            {
                count++;
            }
        }
        return count;
    }
}
