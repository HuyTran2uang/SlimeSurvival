using UnityEngine;

public class MenuManager : MonoBehaviourSingleton<MenuManager>
{
    [SerializeField] private Menu[] _menus;

    public void Open(Menu menu)
    {
        foreach (Menu _menu in _menus)
        {
            if (menu == _menu)
                _menu.Open();
            else
                _menu.Close();
        }
    }

    public void Open(string menuName)
    {
        foreach (Menu menu in _menus)
        {
            if (menu.Name == menuName)
                menu.Open();
            else
                menu.Close();
        }
    }

    public void OpenOption()
    {
        MenuManager.Instance.Open("Option");
    }
}
