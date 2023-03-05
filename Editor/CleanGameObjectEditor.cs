using UnityEngine;
using UnityEditor;

public class CleanGameObjectEditor : MonoBehaviour
{
    [MenuItem("GameObject/Create Clean Empty &#n", false, -1)]
    static void CreateEmpty(MenuCommand menuCommand)
    {
        GameObject gameObject = new GameObject();
        gameObject.name = "GameObject";
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        GameObjectUtility.SetParentAndAlign(gameObject, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
        Selection.activeObject = gameObject;

		if((menuCommand.context as GameObject) == null) return;

		Transform root = (menuCommand.context as GameObject).transform.root;

		if(root.GetComponentInChildren<Canvas>() != null || root.GetComponent<Canvas>())
		{
			gameObject.AddComponent<RectTransform>();
		}
    }
}