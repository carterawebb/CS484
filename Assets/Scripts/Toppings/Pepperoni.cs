using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepperoni : Topping
{
    public override string GetName()
    {
        return "Pepperoni";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/Pepperoni");
    }
}