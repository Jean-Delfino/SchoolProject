using System.Collections;
using System.Collections.Generic;
using Gameplay.Actors;
using Gameplay.Inventory.Items;
using UnityEngine;
using UnityEditor;

using TMPro;

public class PlayerInventory : Purse{
    [Space]
    [Header("   Money attributes")]
    [Space]

    [SerializeField] TextMeshProUGUI moneyOnScreen = default;
    [SerializeField] float initialMoney = default;
    //
    // private Actor playerStatus = default;
    //
    // private void Start(){
    //     //mainBag.SpawnAllItensMain(GetBag(), initialBagName);
    //     playerStatus = GetComponent<PlayerStatus>();
    //     ChangeMoney(initialMoney);
    //
    //     CreateBag();
    //     playerStatus.InventoryUISetup(this);
    //
    //     AddItem("Chocolate-Bar", 2);
    //     AddItem("BottleOfWater", 1);
    // }
    //
    // public bool AddItem(string uniqueIDitem, int qtd){
    //     var result = AssetDatabase.FindAssets(uniqueIDitem);
    //     var path = AssetDatabase.GUIDToAssetPath(result[0]);
    //     var itemData = (Item) AssetDatabase.LoadAssetAtPath(path, typeof(Item));
    //     //var item = Instantiate(itemData);
    //
    //     return AddItem(itemData, qtd);
    // }
    //
    // public bool AddItem(Item item, int qtd){
    //     var addItemResult = base.AddItem((Item)item, qtd);
    //     playerStatus.InventoryUIAddItem(item, GetItemQtd(item));
    //
    //     return addItemResult;
    // }
    //
    // public int GetItemQtd(Item item){
    //     return GetBag().GetItemQtd(item);
    // }
    //
    //
    // public void ChangeMoney(float amount){
    //     IncreaceMoney(amount);
    //
    //     moneyOnScreen.text = GetMoney().ToString();
    // }
    //
    // public Bag GetInventoryBag(){
    //     return this.GetBag();
    // }
    //
    // public string GetInitialBagName(){
    //     return GetBagName();
    // }
    //
    // public new bool AddItem(Item item){
    //     return base.AddItem(item);
    // }
    //
    // public Actor GetPlayerStatus(){
    //     return this.playerStatus;
    // }
}
