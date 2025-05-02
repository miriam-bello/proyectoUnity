using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

//para que lo puedas guardar como un fichero.asset
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public abstract class Item : ScriptableObject
{
    public string itemNombre = "New Item";
    public Sprite icon = null;
    public int maxStack = 99;

    public abstract void Use();
}


public class Slot
{
    public Item item;
    public int cantidad;

    public Slot(Item item, int cantidad)
    {
        this.item = item;
        this.cantidad = cantidad;
    }

}


public class InventarioManager : MonoBehaviour
{
    private static GameObject inventarioInstance;
    public Slot[] contenidoInventario = { new Slot( null, 0), new Slot(null, 0), new Slot(null, 0), new Slot(null, 0), new Slot(null, 0), new Slot(null, 0), new Slot(null, 0), new Slot(null, 0) };

    private void Awake()
    {
        Nekofresa data = Resources.Load<Nekofresa>("Items/Nekofresa");
        contenidoInventario[0].item = data;

        //para solo tener un inventario singleton
        inventarioInstance = gameObject;

        RebuildUiInventario();
    }

    //para repintar la interfaz cada vez que haya un cambio
    private void RebuildUiInventario()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            Image image = childTransform.gameObject.GetComponent<Image>();
            if (contenidoInventario[i].item != null)
            {
                image.sprite = contenidoInventario[i].item.icon;
            }
            
        }
    }

    public void addItem(Item item, int cantidad)
    {
        //añadir a un stack que ya existe
        foreach (Slot slot in contenidoInventario)
        {
            if (item.itemNombre == slot.item.itemNombre)
            {
                //añadir la cantidad al item que ya está en el inventario
                slot.cantidad += cantidad;
                cantidad = slot.cantidad - slot.item.maxStack;
                if (cantidad < 0) { cantidad = 0; }
                if (slot.cantidad > slot.item.maxStack) { cantidad = slot.item.maxStack; }
            }
        }

        // si no caben mas se añaden en otro slot
        if (cantidad > 0)
        {
            for (int i = 0; contenidoInventario.Length > 0; i++)
            {
                if (contenidoInventario[i].item == null)
                {
                    contenidoInventario[i].item = item;
                    cantidad = 0;
                }
            }
        }

        //si no hay slots vacios
        if (cantidad > 0)
        {
            Debug.LogError(" No hay sitio en el inventario");

        }
        RebuildUiInventario();

    }

    public void removeItem(Item item)
    {
        foreach (Slot slot in contenidoInventario)
        {
            if (item.itemNombre == slot.item.itemNombre)
            {
                if (slot.cantidad > 0)
                {
                    slot.cantidad--;
                    break;
                }

            }
        }
        RebuildUiInventario();
    }
}
