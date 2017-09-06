namespace _Scripts.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System;

    [CustomEditor(typeof(Unit), true)]
    public class ChangeUditorMoveAlgorithm : Editor
    {
        Unit.MoveAlgorithm moveAlgorithm;
        SerializedProperty parametersProp;
        SerializedProperty moveAlgorithmProp;

        void OnEnable()
        {
            parametersProp = serializedObject.FindProperty("parameters");
            moveAlgorithmProp = parametersProp.FindPropertyRelative("moveAlgorithm");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();

            moveAlgorithm = (Unit.MoveAlgorithm)moveAlgorithmProp.enumValueIndex;

            Unit unitScript = (Unit)target;
            unitScript.SetMoveAlgorithm(Unit.getTypeForMoveAlgorithm(moveAlgorithm));
        }
    }
}
