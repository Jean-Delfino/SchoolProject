using System.Collections.Generic;
using System.Linq;
using Gameplay.Inventory.Items;

namespace Utils
{
    public static class UtilItem{
        public static bool SearchItem(Bag bag, string id){
            Queue<Bag> additionalBags = new Queue<Bag>();
            Bag hold;

            additionalBags.Enqueue(bag);

            while(additionalBags.Count != 0){
                hold = additionalBags.Dequeue();

                foreach(Item it in hold.GetContent()){
                    if(it.UniqueID == id){
                        return true;
                    }
                }

                foreach(Bag bg in hold.GetContent()){
                    additionalBags.Enqueue(bg);
                }
            }

            return false;
        }

        public static bool SearchItem(Bag bag, Item it){
            Queue<Bag> additionalBags = new Queue<Bag>();
            Bag hold;

            additionalBags.Enqueue(bag);

            while(additionalBags.Count != 0){
                hold = additionalBags.Dequeue();

                if(hold.GetContent().Contains(it)){
                    return true;
                }

                foreach(Bag bg in hold.GetContent().OfType<Bag>().ToList()){
                    additionalBags.Enqueue((Bag)bg);
                }
            }

            return false;
        }

        public static bool SearchItem(Bag bag, Item it, int qtd){
            Queue<Bag> additionalBags = new Queue<Bag>();
            Bag hold;

            additionalBags.Enqueue(bag);

            while(additionalBags.Count != 0){
                hold = additionalBags.Dequeue();
                var dict = hold.GetContentDictionary();

                if(dict.ContainsKey(it) && dict[it] >= qtd){
                    return true;
                }

                foreach(Bag bg in dict.Keys.ToList().OfType<Bag>().ToList()){
                    additionalBags.Enqueue((Bag)bg);
                }
            }

            return false;
        }
    }
}
