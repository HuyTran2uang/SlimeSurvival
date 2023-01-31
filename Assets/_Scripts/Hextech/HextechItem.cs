using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HextechItem : FixedMonoBehaviour
{
    [SerializeField] private Button _buttonUse;
    [SerializeField] private Image _image;
    [SerializeField] private Text _description;
    [SerializeField] private Text _name;

    public void SetButtonUse(List<Action> listCallBack)
    {
        foreach (Action call in listCallBack)
            _buttonUse.onClick.AddListener(() => call());
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.preserveAspect = true;
    }

    public void SetDescription(string description)
    {
        _description.text = description;
    }

    public void SetName(string name)
    {
        _name.text = name;
    }

    private void ResetHextechItem()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        _image.sprite = null;
        _description.text = null;
        _name.text = null;
    }

    protected override void LoadComponent()
    {
        _buttonUse = GetComponent<Button>();
        _image = transform.Find("Image").GetComponent<Image>();
        _description = transform.Find("Description").GetComponent<Text>();
        _name = transform.Find("Name").GetComponent<Text>();
    }

    private void OnEnable()
    {
        this.ResetHextechItem();
    }
}
