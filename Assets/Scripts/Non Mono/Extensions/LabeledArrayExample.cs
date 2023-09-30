using UnityEngine;

public class LabeledArrayExample : MonoBehaviour
{
	
	public enum Order
	{
		First,
		Second,
		Third
	}
	//Whenever you're gonna create an array or list based on an enum, please use this so that the values correctly appear in the inspector
	[LabeledArray(typeof(Order))]
	public int[] enumLabeledValues;
	//int is only an example, it could be:
	[LabeledArray(typeof(Order))]
	public GameObject[] enumLabeledPrefabs;
	[LabeledArray(typeof(Order))]
	public AudioClip[] enumLabeledSongs;

	//PLEASE DON'T CALL THEM "ENUM LABELED SONGS", in this case for the example that's the name, but call them
	//... songs? or prefabs, or seeds, tools, fruit, whatever is relevant :)
}