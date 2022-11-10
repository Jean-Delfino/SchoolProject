using Gameplay.Actors;
using UnityEngine;

/*
    Portable food, water and other items
*/

namespace Gameplay.Inventory.Items
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 0)]

    public class Consumable : Item{
        //[SerializeField] List<StatusChange> affectedStatus = default;

        public override void UseItem(Actor pS){
            /*
        foreach(StatusChange sC in affectedStatus){
            pS.ChangeStatus(sC);
        }

        RemoveItem(pS, 1);
        */
        }

        public void RemoveItem(Actor pS, int qtd){
            FatherOfItem.TakesItemInBag(this, qtd);
            //Changes the position in the inventory if the usage is 0
        }

        public override void RemoveItem(Actor pS){
            FatherOfItem.RemoveItemInBag(this);
            //Changes the position in the inventory if the usage is 0
        }
    }
}
