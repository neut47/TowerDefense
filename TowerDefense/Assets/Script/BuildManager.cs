using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    // olusturulan static ile birlikte awake komutu her oluşan buildicin build manager cagiriyor
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Birden fazla buildmanager var");
        }
        instance = this;
    }

    public GameObject archerTowerPrefab;
    public GameObject wizardTowerPrefab;



    private TowerBlueprint towerToBuild;
    private Node selectedTower;

    public TowerUI towerUI;
    //eger null donmezse insa yapilabilir, true doner.
    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }
    

    public void SelectTower (Node node)
    {
        if(selectedTower == node)
        {
            DeselectTower();
            return;
        }

        selectedTower = node;
        towerToBuild = null;

        towerUI.SetTarget(node);
    }

    // kule icin olan secimi kaldirir
    public void DeselectTower()
    {
        selectedTower = null;
        towerUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectTower();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    

}
