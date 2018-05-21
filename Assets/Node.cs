using UnityEngine;

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

        turret = Instantiate(BuildManager.Instance.GetTurretToBuild(), transform.position + turretOffset, transform.rotation, transform.parent);
    }

    void OnMouseEnter()
    {
        meshRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        meshRenderer.material.color = defaultColor;
    }
}
