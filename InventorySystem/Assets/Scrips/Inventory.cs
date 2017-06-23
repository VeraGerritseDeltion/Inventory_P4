using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public List<ItemSlot> itemslotScript = new List<ItemSlot>();
    public List<GameObject> itemSlot = new List<GameObject>();
    public List<GameObject> ItemObj = new List<GameObject>();

    public GameObject itemslotGameobject;
    public int itemslotRows;
    public Vector3 pos;
    public GameObject inventory;
    public ItemSlot itemSelected;

    public Image imageOnMouse;
    public Item itemToMove;
    public ItemSlot usedItemslot;
    public Text info;
    public GameObject infoPanel;

    void Start()
    {
        infoPanel.SetActive(false);
        itemslotRows = itemslotRows * 4 - 1;
        for (int i = 0; i < itemslotRows; i++)
        {
            itemSlot.Add(Instantiate(itemslotGameobject, pos, Quaternion.identity) as GameObject);
            itemSlot[i].transform.parent = inventory.transform;
            itemslotScript.Add(null);
            itemslotScript[i] = itemSlot[i].GetComponent<ItemSlot>();
        }
       
    }

    private void Update()
    {
        imageOnMouse.transform.position = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        if (Input.GetButtonUp("Fire1"))
        {
            OnMouseUpp();
        }
    }

    public void AddItem(Item newItem)
    {
        for (int i = 0; i < itemslotScript.Count; i++)
        {
            if (newItem != null)
            {
                if (itemslotScript[i].item == null)
                {
                    itemslotScript[i].item = newItem;
                    itemslotScript[i].item.object3d = newItem.object3d;
                    itemslotScript[i].item.UiInfo();
                    return;
                }
            }
        }
    }

    public void MoveItem(Item moveItem, ItemSlot usedSlot)
    {
        usedItemslot = usedSlot;
        if (moveItem != null)
        {
            imageOnMouse.enabled = true;
            imageOnMouse.sprite = moveItem.object2d;
            itemToMove = moveItem;
            usedItemslot = usedSlot;
        }
    }

    public void selected(ItemSlot slot)
    {
        itemSelected = slot;
    }

    public void Ui(ItemSlot slot)
    {
        if (slot.item == null)
        {
            info.enabled = false;
        }
        else
        {
            info.enabled = true;
            info.text = slot.item.UiInfo();
            
        }
    }

    public void Drop()
    {
        if (itemToMove != null&&itemSelected != null)
        {
            if (itemSelected.item == null)
            {
                itemSelected.item = itemToMove;
                imageOnMouse.enabled = false;
                usedItemslot.item = null;
                usedItemslot.selected = false;
            }
            else if (itemSelected.item != null)
            {
                Item temp = itemSelected.item;
                itemSelected.item = itemToMove;
                usedItemslot.item = temp;
                usedItemslot.selected = false;
                imageOnMouse.enabled = false;
            }
        }
    }

    public void OnMouseUpp()
    {
        if (itemSelected == null && usedItemslot != null)
        {
            usedItemslot.selected = false;
            imageOnMouse.enabled = false;
        }
        else if (itemSelected == usedItemslot && usedItemslot != null)
        {
            usedItemslot.selected = false;
            imageOnMouse.enabled = false;
        }
    }

    public void DeleteItem()
    {
        PickUp.inInv--;
        itemSelected.item = null;
    }
}

    

