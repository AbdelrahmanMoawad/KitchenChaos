using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    
    public static event System.EventHandler OnAnyObjectPlacedHere;

    public static void ResetStaticData()
    {
        OnAnyObjectPlacedHere = null;
    }

    [SerializeField]private Transform ConterTopPoint;


    private KitchenObject kitchenObject;


    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter Interact was called");
    }
    public virtual void InteractAlternate(Player player)
    {
        //Debug.LogError("BaseCounter Interact Alternate was called");
    }
     public Transform GetKitchenObjectFollowTransform()
    {
        return ConterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if(kitchenObject != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this, System.EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    
}
