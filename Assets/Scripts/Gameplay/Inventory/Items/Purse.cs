using UnityEngine;

/*
    Contains the money and the itens

    Used for selling and buying stuff (NPCs)
*/

namespace Gameplay.Inventory.Items
{
    public class Purse : MonoBehaviour{
        private float _money = 0;

        [SerializeField] Bag bag = default;

        //Protection from changing the original prefab
        protected void CreateBag(){
            bag = Instantiate(bag);
        }
        public bool AddItem(Item item){
            return bag.AddItem(item);
        }

        public bool AddItem(Item item, int qtd){
            return bag.AddItem(item, qtd);
        }

        public float Money{
            get => _money;
        }
        public void IncreaceMoney(float amount){
            _money += amount;
        }

        public Bag Bag{
            get => bag;
        }

        public string BagName{
            get => bag.NameItem;
        }
    }
}
