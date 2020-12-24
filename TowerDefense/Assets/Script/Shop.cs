using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint archerTower;
    public TowerBlueprint wizardTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    
    public void SelectArcherTower()
    {
        Debug.Log("Kule secildi");
        buildManager.SelectTowerToBuild(archerTower);
    }
    public void SelectWizardTower()
    {
        Debug.Log("Diger kule secildi");
        buildManager.SelectTowerToBuild(wizardTower);
    }

}
