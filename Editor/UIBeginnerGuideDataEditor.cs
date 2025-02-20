using UnityEditor;
using UnityEngine;

namespace ZBeginnerGuide
{
    public class GuideMenu
    {
        [MenuItem("ZBeginnerGuide/Create Beginner Guide", false, 55)]
        public static void AddList()
        {
            GuideImagePreviewWindow.ShowWindow();
        }
    }

    public class GuideImagePreviewWindow : EditorWindow
    {
        private Texture2D previewTexture;

        public static void ShowWindow()
        {
            var window = GetWindow<GuideImagePreviewWindow>("新手引导图片预览");
            window.LoadPreviewTexture();
        }

        private void LoadPreviewTexture()
        {
            previewTexture = ResourceManager.Load<Texture2D>("Image/beginnerguide_atlas/CircleFill");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("图片预览", EditorStyles.boldLabel);
            
            if (previewTexture != null)
            {
                // 显示图片信息
                EditorGUILayout.LabelField($"图片名称: {previewTexture.name}");
                EditorGUILayout.LabelField($"尺寸: {previewTexture.width} x {previewTexture.height}");
                EditorGUILayout.LabelField($"格式: {previewTexture.format}");
                
                // 预览图片
                float previewSize = 200f;
                Rect previewRect = EditorGUILayout.GetControlRect(GUILayout.Width(previewSize), GUILayout.Height(previewSize));
                EditorGUI.DrawPreviewTexture(previewRect, previewTexture);
            }
            else
            {
                EditorGUILayout.HelpBox("无法加载预览图片", MessageType.Error);
            }
        }
    }
}
    