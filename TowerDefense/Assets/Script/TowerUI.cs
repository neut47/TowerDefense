using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public GameObject ui;
    // her kulenin kendine ait bir maliyeti var onu ayarlamak icin kullanildi
    public Text upgradeCost;
    public Button upgradeButton;

    public Text SellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.towerBlueprint.upgradeCost + "G";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        SellAmount.text = target.towerBlueprint.GetSellAmount() + "G";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectTower();
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectTower();
    }
}
