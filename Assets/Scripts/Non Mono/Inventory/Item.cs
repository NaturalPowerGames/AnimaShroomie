using UnityEngine;

[System.Serializable]
public class Item
{
	public string Name;
	public int Cost, Index;
	public Sprite UISprite;
	public GameObject ItemPrefab;
	public Vector2Int Coordinates;
}
