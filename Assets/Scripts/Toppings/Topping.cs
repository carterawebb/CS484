using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
public abstract class Topping : MonoBehaviour
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
{
    public abstract string GetName();
    public abstract GameObject GetSimplifiedMapping();

    public static bool operator ==(Topping a, Topping b)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(a, b))
        {
            return true;
        }

        // If one is null, but not both, return false.
        if (((object)a == null) || ((object)b == null))
        {
            return false;
        }

        // Return true if names match
        return a.name == b.name;
    }

    public static bool operator !=(Topping a, Topping b)
    {
        return !(a == b);
    }
}
