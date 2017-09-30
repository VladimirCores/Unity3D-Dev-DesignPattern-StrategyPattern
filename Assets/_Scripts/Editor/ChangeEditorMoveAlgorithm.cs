namespace _Scripts.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System;

    [CustomEditor(typeof(Unit), true)]
    public class ChangeUditorMoveAlgorithm : Editor
    {
		private int lastIndex = -1;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            //serializedObject.Update();

			SerializedProperty parametersProp;
			SerializedProperty moveAlgorithmProp;

			parametersProp = serializedObject.FindProperty("parameters");
			moveAlgorithmProp = parametersProp.FindPropertyRelative("moveAlgorithm");

			int valueIndex = moveAlgorithmProp.enumValueIndex;
			if(lastIndex != valueIndex) 
			{
				lastIndex = valueIndex;

				Unit unitScript = (Unit)target;

				Unit.MoveAlgorithm newMoveAlgorithm = (Unit.MoveAlgorithm)valueIndex;

				Debug.Log("> OnInspectorGUI: newMoveAlgorithm = " + newMoveAlgorithm);

				if(newMoveAlgorithm != unitScript.GetMoveAlgorithm()) {
					unitScript.SetMoveAlgorithm(newMoveAlgorithm);
				}

				unitScript = null;
			}
		}
    }
}
