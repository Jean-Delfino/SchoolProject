using Gameplay.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class InventorySlot : MonoBehaviour{
    private InventoryUI father;

    [SerializeField] private Image icon = default;
    [SerializeField] private TextMeshProUGUI qtdItem = default;

    private Item _item;

    public void SetupSlot(Item newIt, int qtd, InventoryUI father){
        _item = newIt;

        icon.sprite = _item.ItemIcon;
        qtdItem.text = qtd.ToString();

        this.father = father;
    }

    public void ChangeSlotQtd(int qtd){
        qtdItem.text = qtd.ToString();
    }

    // public void UseItem(){
    //     father.UseItem(it);
    // }
    //
    // public void RemoveItem(){
    //     father.RemoveItem(it);
    // }

    public int GetPosition(){
        return this.transform.GetSiblingIndex();
    }
}
