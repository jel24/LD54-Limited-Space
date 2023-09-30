using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] Boat boat;

    [SerializeField] TextMeshProUGUI foodLabel;
    [SerializeField] TextMeshProUGUI fishingLabel;
    [SerializeField] TextMeshProUGUI goodsLabel;
    [SerializeField] TextMeshProUGUI crewLabel;
    [SerializeField] TextMeshProUGUI weaponsLabel;
    [SerializeField] TextMeshProUGUI woodLabel;
    [SerializeField] TextMeshProUGUI speedLabel;

    public void UpdateResourcePanel()
    {
        foodLabel.text = "Food: " + boat.food.ToString();
        fishingLabel.text = "Fishing: " + boat.fishing.ToString() + " per day";
        goodsLabel.text = "Goods: " + boat.goods.ToString();
        crewLabel.text = "Crew: " + boat.crew.ToString() + " (-1 food/day each)";
        weaponsLabel.text = "Weapons: " + boat.weapons.ToString();
        woodLabel.text = "Lumber: " + boat.lumber.ToString();
        speedLabel.text = "Speed: " + (7 - boat.sails).ToString() + " days journey.";

    }

    public void Embark()
    {
        SceneManager.LoadSceneAsync("Map");
    }


}
