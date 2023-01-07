using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ListHextechItem : FixedMonoBehaviourSingleton<ListHextechItem>
{
    [SerializeField] private HextechItem[] _hextechItems;

    private void SetListHextechItem()
    {
        _hextechItems = GetComponentsInChildren<HextechItem>();
    }

    public void SetOptionHextech()
    {
        List<Hextech> listHextech = ListHextech.Instance.GetRandomThreeHexteches();

        for (int i = 0; i < 3; i++)
        {
            List<Action> listCallBack = new List<Action>(){
                listHextech[i].Use,
                MenuManager.Instance.OpenOption,
                GameManager.Instance.Resume
            };
            _hextechItems[i].SetButtonUse(listCallBack);
            _hextechItems[i].SetName(listHextech[i].Name);
            _hextechItems[i].SetDescription(listHextech[i].Description);
            _hextechItems[i].SetImage(listHextech[i].Sprite);
        }
    }

    protected override void LoadComponent()
    {
        this.SetListHextechItem();
    }
}
