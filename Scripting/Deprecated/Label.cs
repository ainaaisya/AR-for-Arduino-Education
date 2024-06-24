using UnityEngine;

public class Label : MonoBehaviour
{
	[SerializeField]
	private bool IsSelected;
	
	public bool Selected
	{
		get{return this.IsSelected;}
		set{IsSelected = value;}
	}
	
	[SerializeField]
	private TextMesh OverlayText;
	private TextMesh OverlayText2;
	[SerializeField]
	private string OverlayDisplayText;
	private string OverlayDisplayText2;
}