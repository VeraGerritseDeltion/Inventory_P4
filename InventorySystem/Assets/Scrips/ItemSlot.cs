using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
    public Item item;
    public Inventory inventory;
    public Image image;
    public bool selected;
    public bool bin;
    public bool selec;

    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
        GameObject test = transform.Find("ItemImage").gameObject;
        image = test.GetComponent<Image>();
    }

    private void Update()
    {
        if (item != null && selected == false)
        {
            image.sprite = item.object2d;
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
        if(bin == true && item != null)
        {
            Destroy(item.object3d);
        }
        if (selec == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                item.Interact();
                Selected();
            }
        }
    }

    public void OnClick()
    {
        selected = true;
        image.enabled = false;
        inventory.MoveItem(item, this);
    }

    public void Selected()
    {
        inventory.selected(this);
        if (item != null)
        {
            inventory.Ui(this);
            inventory.infoPanel.SetActive(true);
            selec = true;
        }

    }

    public void Deselect()
    {
        inventory.selected(null);
        inventory.infoPanel.SetActive(false);
        selec = false;
    }

    public void Dropping()
    {inventory.usedItemslot.selected = false;
        if (inventory.itemSelected == this && inventory.itemToMove != null)
        {
            inventory.Drop();
            
            inventory.imageOnMouse.enabled = false;
        }
    }
}
