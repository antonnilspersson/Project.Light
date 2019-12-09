
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    public Image[] slot;
    public Inventory weapon;
    public EquipSystem equip;
    float inactive = 0.2f;

    void Update()
    {
        Crossbow();
        Revolver();
        Rifle();
    }

    void Crossbow()
    {
        Color color = slot[0].color;
        if (weapon.crossbow == 1)
        {
            if(equip.equipSlot == 2)
                color.a = 1f;
            else
                color.a = inactive;
        }
        else
            color.a = 0f;

        slot[0].color = color;
    }

    void Revolver()
    {
        Color color = slot[1].color;
        if (weapon.gun == 1)
        {
            if (equip.equipSlot == 3)
                color.a = 1f;
            else
                color.a = inactive;
        }
        else
            color.a = 0f;

        slot[1].color = color;
    }

    void Rifle()
    {
        Color color = slot[2].color;

        if (weapon.rifle == 1)
        {
            if (equip.equipSlot == 4)
                color.a = 1f;
            else
                color.a = inactive;
        }
        else
            color.a = 0f;

        slot[2].color = color;
    }
}
