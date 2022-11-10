using Gameplay.Actors;
using UnityEngine;

//using UntiyEngine.UI;

namespace Gameplay.Inventory.Items
{
    [System.Serializable]

    public abstract class Item : ScriptableObject
    {
        private Bag fatherInventory;

        [Space] [Header("Defining item attribute")] [Space] [SerializeField]
        private string uniqueID = default;

        [SerializeField] private string nameItem = default;
        [SerializeField] private Sprite itemIcon = default;

        [Space] [Header("Value and Weight")] [Space] 
    
        [SerializeField] private float price = default;

        [SerializeField] private float weight = default;

        public string UniqueID
        {
            get => uniqueID;
        }
        public float Price
        {
            get => price;
            set => price = value;
        }
        public string NameItem
        {
            get => nameItem;
        }

        public Sprite ItemIcon
        {
            get => itemIcon;
        }
        public float Weight
        {
            get =>  weight;
            set => weight = value;
        }

        public Bag FatherOfItem
        {
            get => fatherInventory;
            set => fatherInventory = value;
        }
    
        public abstract void UseItem(Actor pS);
        public abstract void RemoveItem(Actor pS);
    }
}
