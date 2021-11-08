using System;
using UnityEngine;

[CreateAssetMenu( fileName = "README_folderNameHere", menuName = "Readme")]
public class ReadmeData : ScriptableObject
{
	public string ReadmeTitle;
	public Section[] Sections = new Section[]{};

	[Serializable]
	public class Section {
		public string heading = "";
		[TextArea(3,5)]
		public string text = "";
	}
}