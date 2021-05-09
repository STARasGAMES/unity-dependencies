using SaG.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace SaG.Dependencies.Editor
{
    [CustomPropertyDrawer(typeof(IDependency), true)]
    public sealed class DependencyDrawer : PropertyDrawer
    {
        private SerializedProperty sourceProperty;

        private SerializedProperty explicitReferenceProperty;

#if UNITY_GUID_BASED_REFERENCES
		private SerializedProperty globalReferenceProperty;
#endif

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
#if UNITY_GUID_BASED_REFERENCES
			sourceProperty = property.FindPropertyRelativeOrFail("_" + nameof(IDependency.source));

			var source = (DependencySource)sourceProperty.enumValueIndex;

			if (source == DependencySource.Global)
			{
				return EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
			}
#endif

            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.targetObject as Component == null)
            {
                string error =
                    $"{nameof(Dependency<Component>)}<T> cannot be used on {typeof(Object).FullName} that is not an {typeof(Component).FullName}!";
                var guiContent = new GUIContent(error, error);
                EditorGUI.LabelField(position, guiContent);
                Debug.LogError(error, property.serializedObject.targetObject);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            var controlPosition = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            sourceProperty = property.FindPropertyRelativeOrFail("_" + nameof(IDependency.source));
            explicitReferenceProperty =
                property.FindPropertyRelativeOrFail("_" + nameof(Dependency<Component>.explicitReference));
#if UNITY_GUID_BASED_REFERENCES
			globalReferenceProperty =
 property.FindPropertyRelativeOrFail("_" + nameof(Dependency<Component>.globalReference));
#endif

            EditorGUI.showMixedValue = sourceProperty.hasMultipleDifferentValues;
            // I don't know why, but EditorGUI.indentLevel works strange, that's why there are messy operations on Rects...
            var sourcePosition = new Rect
            (
                controlPosition.x - EditorGUI.indentLevel * Styles.intentWidth,
                controlPosition.y,
                Styles.sourceWidth + EditorGUI.indentLevel * Styles.intentWidth,
                EditorGUIUtility.singleLineHeight
            );

            var fieldPosition = new Rect
            (
                controlPosition.x + Styles.sourceWidth - EditorGUI.indentLevel * Styles.intentWidth +
                    Styles.spaceBetweenSourceAndField,
                //sourcePosition.xMax + Styles.spaceBetweenSourceAndField,
                controlPosition.y,
                controlPosition.width - Styles.sourceWidth - Styles.spaceBetweenSourceAndField + EditorGUI.indentLevel * Styles.intentWidth,
                EditorGUIUtility.singleLineHeight
            );

            // Draw source field

            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(sourcePosition, sourceProperty, GUIContent.none);
            bool isSourceChanged = EditorGUI.EndChangeCheck();

            if (isSourceChanged && sourceProperty.ReadEnum<DependencySource>() != DependencySource.Explicit)
            {
                explicitReferenceProperty.objectReferenceValue = null;
            }

            // Draw reference field

            if (sourceProperty.hasMultipleDifferentValues)
            {
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.LabelField(fieldPosition, "\u2014", EditorStyles.textField);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                var source = (DependencySource) sourceProperty.enumValueIndex;

                if (source == DependencySource.Explicit)
                {
                    EditorGUI.PropertyField(fieldPosition, explicitReferenceProperty, GUIContent.none);
                }
#if UNITY_GUID_BASED_REFERENCES
				else if (source == DependencySource.Global)
				{
					EditorGUI.PropertyField(fieldPosition, globalReferenceProperty, GUIContent.none);
				}
#endif
                else
                {
                    EditorGUI.BeginDisabledGroup(true);

                    if (property.serializedObject.isEditingMultipleObjects)
                    {
                        EditorGUI.LabelField(fieldPosition, "\u2014", EditorStyles.textField);
                    }
                    else
                    {
                        var dependency = (IDependency) property.GetUnderlyingValue();
                        var self = (Component) property.serializedObject.targetObject;
                        var component = dependency.Resolve(self);

                        EditorGUI.ObjectField(fieldPosition, component, dependency.type, true);
                    }

                    EditorGUI.EndDisabledGroup();
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                DependencyInvalidator.InvalidateAllDependencies();
            }

            EditorGUI.EndProperty();
        }

        private static class Styles
        {
            public static readonly float sourceWidth = 76;

            public static readonly float spaceBetweenSourceAndField = 2;

            public static readonly float intentWidth = 15;
        }
    }
}