using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{    
    private Renderer rend;
    private Color startColor;

    public Vector3 positionOffSet;
    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;

   void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    // mouse nesne uzerine geldiginde yapilacak islemler
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney)
        {
            rend.material.color = Color.green;
        }
        else
        {
            rend.material.color = Color.red;
        }
        
    }

    //mouse tiklandiginda yapilacak islemler
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (tower != null)
        {
            buildManager.SelectTower(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildTower(buildManager.GetTowerToBuild());
        //buildManager.BuildTowerOn(this);
    }
    //kule insa etme
    void buildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprint;
        Debug.Log("Kule insa edildi!");
    }

    public void UpgradeTower()
    {
        if (PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log("Yukseltme icin yeterli para yok");
            return;
        }

        PlayerStats.Money -= towerBlueprint.upgradeCost;
        //eski kule yokedildi
        Destroy(tower);

        // yenisi insa edildi
        GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;
        Debug.Log("Kule yukseltildi!");
    }

    // kule satma islemi
    public void SellTower()
    {
        // uterim maliyetinin 3/4 ünü geri verir
        PlayerStats.Money += towerBlueprint.GetSellAmount();

        Destroy(tower);
        //kule insa yerini bosa geri ceker
        towerBlueprint = null;
        isUpgraded = false;

}

    // mouse nesne uzerinden kaldirdiliginda yapilacak islemler
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
