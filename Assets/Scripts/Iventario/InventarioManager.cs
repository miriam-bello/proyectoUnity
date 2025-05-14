using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//para que lo puedas guardar como un fichero.asset
[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventory/Item")]
// clase Item (nombre, icono, y numero maximo estaqueable)
public abstract class Item : ScriptableObject
{
    public string itemNombre = "Nuevo Item";
    public Sprite icon = null;
    public int maxStack = 99;

    public abstract void Use(PilaDeItem pilaDeItem);
}

// clase Pila de Item que contiene un item y que cantidad tiene de este
[System.Serializable]
public class PilaDeItem
{
    public Item item;
    public int cantidad;

    public PilaDeItem(Item item, int cantidad)
    {
        this.item = item;
        this.cantidad = cantidad;
    }
}


//---------------Manejador del inventario---------------------
public class InventarioManager : MonoBehaviour
{
    private static GameObject inventarioInstance;
    public PilaDeItem[] inventario = { new PilaDeItem(null, 0), new PilaDeItem(null, 0), new PilaDeItem(null, 0), new PilaDeItem(null, 0), new PilaDeItem(null, 0), new PilaDeItem(null, 0), new PilaDeItem(null, 0), new PilaDeItem(null, 0) };


    //--------------- instancia del InventarioManager ---------------
    public static InventarioManager GetInstance()
    {
        return GameObject.FindWithTag("Inventario").GetComponent<InventarioManager>();
    }

    private void Awake()
    {
        SemillasPurrrengena data = Resources.Load<SemillasPurrrengena>("Items/SemillasPurrrengena");
        inventario[0].item = data;
        inventario[0].cantidad = 2;

       //para solo tener un inventario singleton
       inventarioInstance = gameObject;

        RebuildUiInventario();
    }
   

    //para repintar la interfaz cada vez que haya un cambio
    public void RebuildUiInventario()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            PilaDeItem slot = inventario[i];

            if (slot.cantidad < 1)
            {
                slot.item = null;
            }

            Transform childTransform = transform.GetChild(i);
            Image image = childTransform.gameObject.GetComponent<Image>();
            if (slot.item != null)
            {
                image.color = image.color.WithAlpha(1);
                image.sprite = slot.item.icon;

            }
            else {
                //para que no se vea cuando no hay nada
                image.color = image.color.WithAlpha(0);
                image.sprite = null;
            }

            childTransform.gameObject.GetComponent<SlutScript>().SetCantidad(slot.cantidad);
        }
    }

    //añadir al inventario
    public void addItem(Item item, int cantidad)
    {
        //añadir a un stack que ya existe
        foreach (PilaDeItem pilaDeItem in inventario)
        {
            if (pilaDeItem.item == null)
            {
                continue;
            }
            else
            {
                if (item.itemNombre == pilaDeItem.item.itemNombre)
                {
                    //añadir la cantidad al item que ya está en el inventario
                    pilaDeItem.cantidad += cantidad;
                    cantidad = pilaDeItem.cantidad - pilaDeItem.item.maxStack;
                    if (cantidad < 0) { cantidad = 0; }
                    if (pilaDeItem.cantidad > pilaDeItem.item.maxStack) { cantidad = pilaDeItem.item.maxStack; }
                }
            }

        }

        // si no caben mas se añaden en otro slot
        if (cantidad > 0)
        {
            for (int i = 0; i < inventario.Length; i++)
            {
                PilaDeItem pilaDeItem = inventario[i];
                if (pilaDeItem.item == null)
                {
                    pilaDeItem.item = item;
                    pilaDeItem.cantidad = cantidad;
                    cantidad = 0;
                    break;
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


    //usar item en la posicion selecionada del inventario
    public void useItemAt(int slutPosition)
    {
        Item item = inventario[slutPosition].item;
        if (item == null)
        {
            return;
        }
        
        item.Use(inventario[slutPosition]);

    }

}
