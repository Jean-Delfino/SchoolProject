using System.Collections.Generic;
using System.Linq;
using Gameplay.Actors;
using UnityEngine;
using Utils;

/*
    A bag can be stored inside of a bag

    Each item has a bag, but not each bag has a bag

    The bag player is not inside any bag
*/
namespace Gameplay.Inventory.Items
{
    [CreateAssetMenu(fileName = "Bag", menuName = "Items/Bag", order = 0)]

    public class Bag : Item{
        private Dictionary<Item, int> _content = new();

        [SerializeField] float weightLimit = default;

        public List<Item> GetContent(){
            return _content.Keys.ToList();
        }

        public bool SearchItem(Item item){
            return UtilItem.SearchItem(this, item);
        }

        public bool SearchItem(Item item, int qtd){
            return UtilItem.SearchItem(this, item);
        }

        public Dictionary<Item, int> GetContentDictionary(){
            return _content;
        }

        public Item GetItem(int index){
            if(index < 0 || index > _content.Count) return null;

            return _content.ElementAt(index).Key;
        }

        public bool ItemExist(Item item){
            return _content.ContainsKey(item);
        }

        public bool AddItem(Item item){
            return AddItem(item, 1);
        }

        public int GetItemQtd(Item item){
            if(_content.ContainsKey(item)){
                return _content[item];
            }

            return 0;
        }

        public bool AddItem(Item item, int qtd){
            float totalWeight = (item.Weight * qtd) + Weight;
            if(totalWeight > weightLimit) return false;
            
            item.FatherOfItem = this;

            if(_content.ContainsKey(item)){
                _content[item] += qtd; 
            }else{
                _content.Add(item, qtd);
            }

            Weight = totalWeight;
            Price += (item.Price * qtd);
            return true;
        }

        public bool RemoveItemInBag(int index){
            if(index < 0 || index > _content.Count) return false;

            _content.Remove(_content.ElementAt(index).Key);
            int qtd = _content.ElementAt(index).Value;

            RemoveValueAndWeight(index, qtd);
            return true;
        }

        public bool RemoveItemInBag(Item item){
            if(!_content.ContainsKey(item)) return false;

            _content.Remove(item);
            int qtd = _content[item];

            RemoveValueAndWeight(item, qtd);
            return true;
        }

        public bool TakesItemInBag(int index, int qtd){
            if(index < 0 || index > _content.Count) return false;

            int qtdValue = _content.ElementAt(index).Value;
            if(qtdValue < qtd) return false;

            qtdValue = _content[_content.ElementAt(index).Key] = qtdValue - qtd; 

            if(qtdValue == 0){
                _content.Remove(_content.ElementAt(index).Key);
            }

            RemoveValueAndWeight(index, qtd);
            return true;
        }

        public bool TakesItemInBag(Item item, int qtd){
            if(!_content.ContainsKey(item)) return false;

            int qtdValue = _content[item];
            if(qtdValue < qtd) return false;

            qtdValue = _content[item] = qtdValue - qtd; 

            if(qtdValue == 0){
                _content.Remove(item);
            }

            RemoveValueAndWeight(item, qtd);
            return true;
        }
    
        private void RemoveValueAndWeight(int index, int qtd){
            RemoveValueAndWeight(_content.ElementAt(index).Key, qtd);
        }

        private void RemoveValueAndWeight(Item item, int qtd)
        {
            Weight -= (item.Weight * qtd);
            Price -= (item.Price * qtd);
        }

        public override void UseItem(Actor pS){}
    
        public override void RemoveItem(Actor pS){} 
    }
}
