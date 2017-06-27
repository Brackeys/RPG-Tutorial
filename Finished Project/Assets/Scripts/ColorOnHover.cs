using UnityEngine;
using System.Linq;
/* Tint the object when hovered. */

public class ColorOnHover : MonoBehaviour {

	public Color color;
	public Renderer meshRenderer;

	Color[] originalColours;

	void Start() {
		if (meshRenderer == null) {
			meshRenderer = GetComponent<MeshRenderer> ();
		}
		originalColours = meshRenderer.materials.Select (x => x.color).ToArray ();
	}

	void OnMouseEnter ()
	{
		foreach (Material mat in meshRenderer.materials) {
			mat.color *= color;
		}

	}

	void OnMouseExit()
	{
		for (int i = 0; i < originalColours.Length; i++) {
			meshRenderer.materials [i].color = originalColours [i];
		}
	}

}
