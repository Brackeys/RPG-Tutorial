using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject {

	new public string name = "New Item";
	public Sprite icon = null;
	public bool isStackable = false;

	public virtual void Use ()
	{
		Debug.Log("Using " + name);
	}

}
