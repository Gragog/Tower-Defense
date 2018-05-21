using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class Node : MonoBehaviour {

    public Color hoverColor;
    Color defaultColor;

    public Vector3 turretOffset;

    Renderer meshRenderer;
    public GameObject turret;

    private void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        defaultColor = meshRenderer.material.color;
    }

    void OnMouseDown()
    {
        if (turret) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        GameObject shop = BuildManager.Shop;
        shop.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        shop.GetComponent<Shop>().AttachNode(gameObject, turretOffset);

        // turret = Instantiate(BuildManager.Instance.GetTurretToBuild(), transform.position + turretOffset, transform.rotation, transform.parent);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        meshRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        meshRenderer.material.color = defaultColor;
    }
}
