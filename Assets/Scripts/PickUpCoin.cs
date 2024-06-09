using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : Pickup
{
    public override void PickMeUp()
    {
        Invetory.currentCoins++;
        UIManager.UpdateCoins();
        Destroy(gameObject);
    }
}
