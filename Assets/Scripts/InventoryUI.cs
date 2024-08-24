using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //일단 보류
    //[SerializeField] public GameObject InventoryPanel;
    //[SerializeField] public GameObject InvenLeftPanel;
    //[SerializeField]
    //GameObject
    //    ArmorPanel, RingsPanel, BowPanel;
    //[SerializeField]
    //Button
    //    aButton, rButton, bButton;
    //[SerializeField]
    //Button
    //    ArmorButton, ArmorButton1, ArmorButton2, ArmorButton3, ArmorButton4, ArmorButton5, ArmorButton6, ArmorButton7, ArmorButton8, ArmorButton9;
    //[SerializeField]
    //GameObject
    //    Panel, Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9;
    //[SerializeField] Button Select;
    //Monster monster;
    //private void Start()
    //{
    //    colorBlock = Select.colors;
    //    ArmorPanel.SetActive(true);
    //    RingsPanel.SetActive(false);
    //    BowPanel.SetActive(false);
    //}
    //private void LateUpdate()
    //{
    //    if (Panel)
    //    {
    //        if (monster.BanditArmorBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BanditArmor;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel1)
    //    {
    //        if (monster.BanditGlovesBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BanditGloves;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel2)
    //    {
    //        if (monster.BanditBootsBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BanditBoots;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel3)
    //    {
    //        if (monster.BattleGuardHelmBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BattleGuardHelm;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel4)
    //    {
    //        if (monster.BattleGuardArmorBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BattleGuardArmor;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel5)
    //    {
    //        if (monster.BattleGuardGlovesBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BattleGuardGloves;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel6)
    //    {
    //        if (monster.BattleGuardBootsBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.BattleGuardBoots;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel7)
    //    {
    //        if (monster.GreyKnightArmorBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.GreyKnightArmor;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel8)
    //    {
    //        if (monster.GreyKnightGlovesBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.GreyKnightGloves;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //    else if (Panel9)
    //    {
    //        if (monster.GreyKnightBootsBool)
    //        {
    //            colorBlock.normalColor = Color.green;
    //            Select.colors = colorBlock;
    //            selectGameObj = monster.GreyKnightBoots;
    //        }
    //        else
    //        {
    //            colorBlock.normalColor = Color.white;
    //            Select.colors = colorBlock;
    //        }
    //    }
    //}
    //public void ArmorValueChanged()
    //{
    //    ArmorPanel.SetActive(true);
    //    RingsPanel.SetActive(false);
    //    BowPanel.SetActive(false);
    //}
    //public void RingsValueChanged()
    //{
    //    ArmorPanel.SetActive(false);
    //    RingsPanel.SetActive(true);
    //    BowPanel.SetActive(false);
    //}
    //public void BowsValueChanged()
    //{
    //    ArmorPanel.SetActive(false);
    //    RingsPanel.SetActive(false);
    //    BowPanel.SetActive(true);
    //}
    //public void AB()
    //{
    //    Panel.SetActive(true);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //}
    //public void AB1()
    //{
    //    Panel.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel1.SetActive(true);
    //}
    //public void AB2()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel2.SetActive(true);
    //}
    //public void AB3()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel3.SetActive(true);
    //}
    //public void AB4()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel4.SetActive(true);
    //}
    //public void AB5()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel5.SetActive(true);
    //}
    //public void AB6()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel6.SetActive(true);
    //}
    //public void AB7()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel7.SetActive(true);
    //}
    //public void AB8()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel9.SetActive(false);
    //    Panel8.SetActive(true);
    //}
    //public void AB9()
    //{
    //    Panel.SetActive(false);
    //    Panel1.SetActive(false);
    //    Panel2.SetActive(false);
    //    Panel3.SetActive(false);
    //    Panel4.SetActive(false);
    //    Panel5.SetActive(false);
    //    Panel6.SetActive(false);
    //    Panel7.SetActive(false);
    //    Panel8.SetActive(false);
    //    Panel9.SetActive(true);
    //}

    //ColorBlock colorBlock;
    //GameObject selectGameObj;
    //public void SelectOnClick()
    //{
    //    if (colorBlock.normalColor == Color.green)
    //    {
            
    //    }

    //}
}
