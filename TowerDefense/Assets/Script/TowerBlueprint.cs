using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cost bilgisinin gosterilebilmesi icin gerekli, veriyi kaydeder
[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    //satma isleminde geri verilecek parayi hesaplar
    public int GetSellAmount()
    {
        return (cost / 4) * 3;
    }

}
