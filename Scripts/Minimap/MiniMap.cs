using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public static MiniMap Instance;

    [SerializeField]
    Terrain terrian;

    [SerializeField]
    RectTransform scrollViewRectTransform;

    [SerializeField]
    RectTransform contentRectTransform;

    [SerializeField]
    MiniMapIcon miniMapIconPrefab;

    Matrix4x4 transformationMatrix;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CalculateTransformMatrix();
    }

    Dictionary<MiniMapWorldObject, MiniMapIcon> miniMapWorldObjectsLookup = new Dictionary<MiniMapWorldObject, MiniMapIcon>();

    public void RegisterMiniMapWorldObject(MiniMapWorldObject miniMapWorldObject)
    {
        var miniMapIcon = Instantiate(miniMapIconPrefab);
        miniMapIcon.transform.SetParent(contentRectTransform);
        miniMapIcon.SetIcon(miniMapWorldObject.Icon);
        miniMapIcon.SetColor(miniMapWorldObject.IconColor);
        miniMapIcon.SetText(miniMapWorldObject.Text);
        miniMapIcon.SetTextSize(miniMapWorldObject.Textsize);
        miniMapWorldObjectsLookup[miniMapWorldObject] = miniMapIcon;

    }
    private void Update()
    {
        UpdateMinimapIcons();
    }

    void UpdateMinimapIcons()
    {
        foreach (var kvp in miniMapWorldObjectsLookup)
        {
            var miniMapWorldObject = kvp.Key;
            var miniMapIcon = kvp.Value;

            var mapPosition = WorldPositionTomapPosition(miniMapWorldObject.transform.position);

            miniMapIcon.RectTransform.anchoredPosition = mapPosition;

            var rotation = miniMapWorldObject.transform.rotation.eulerAngles;
            miniMapIcon.IconRectTransform.localRotation = Quaternion.AngleAxis(rotation.y, Vector3.forward);
        }
    }

    Vector2 WorldPositionTomapPosition(Vector3 WorldPos)
    {
        var pos = new Vector2(WorldPos.x, WorldPos.z);
        return transformationMatrix.MultiplyPoint3x4(pos);
    }

    void CalculateTransformMatrix()
    {
        var miniMapDimensions = contentRectTransform.rect.size;
        var terrianDimensions = new Vector2(terrian.terrainData.size.x, terrian.terrainData.size.z);

        var scaleRatio = miniMapDimensions / terrianDimensions;
        var translation = -miniMapDimensions / 2;

        transformationMatrix = Matrix4x4.TRS(translation, Quaternion.identity, scaleRatio);
    }
}
