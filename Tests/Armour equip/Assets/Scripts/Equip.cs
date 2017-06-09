using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

	public SkinnedMeshRenderer[] items;
	public SkinnedMeshRenderer targetMesh;

	GameObject[] equippedItems;

	void Start() {
		equippedItems = new GameObject[items.Length];
	}

	void Update () {

		if (Input.anyKeyDown) {
			int inputNum = 0;
			if (int.TryParse (Input.inputString, out inputNum)) {
				inputNum--; // entering '1' should result in index 0
				if (inputNum >= 0 && inputNum < items.Length) {
					ToggleEquip (inputNum);
				}
			}
		}
		
	}

	void ToggleEquip(int itemIndex) {
		if (equippedItems[itemIndex] == null) {
			SkinnedMeshRenderer newMesh = Instantiate(items[itemIndex]) as SkinnedMeshRenderer;
			newMesh.bones = targetMesh.bones;
			newMesh.rootBone = targetMesh.rootBone;
			equippedItems [itemIndex] = newMesh.gameObject;
		}
		else {
			Destroy(equippedItems[itemIndex]);
		}
	}
}
