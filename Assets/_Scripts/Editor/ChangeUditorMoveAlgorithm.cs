namespace _Scripts.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System;

    [CustomEditor(typeof(Unit), true)]
    public class ChangeUditorMoveAlgorithm : Editor
    {
        Unit.MoveAlgorithms moveAlgorithm;
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

            moveAlgorithm = (Unit.MoveAlgorithms)moveAlgorithmProp.enumValueIndex;

            Unit unitScript = (Unit)target;
            
            switch (moveAlgorithm)
            {
                case Unit.MoveAlgorithms.Null:
                    unitScript.SetMoveAlgorithm(typeof(NullMoveAlgorithm));
                    break;
                case Unit.MoveAlgorithms.Aviation:
                    unitScript.SetMoveAlgorithm(typeof(TerranAviationMoveAlgorithm));
                    break;
                case Unit.MoveAlgorithms.Jump:
                    unitScript.SetMoveAlgorithm(typeof(TerranJumpMoveAlgorithm));
                    break;
                case Unit.MoveAlgorithms.Infantry:
                    unitScript.SetMoveAlgorithm(typeof(TerranInfantryMoveAlgorithm));
                    break;
                case Unit.MoveAlgorithms.Wiggle:
                    unitScript.SetMoveAlgorithm(typeof(TerranWiggleMoveAlgorithm));
                    break;

            }

            //serializedObject.ApplyModifiedProperties();
        }
    }
}
