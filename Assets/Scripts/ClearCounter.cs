using System;
using UnityEngine;

public class ClearCounter : BaseCounter
{


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //на коунтері KitchenObject нема
            if (player.HasKitchenObject())
            {
                //У плєєра є KitchenObject
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //на коунтері є KitchenObject
            if (!player.HasKitchenObject())
            {
                //У плеєра нема обєкта
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
