using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    GameObject attachedNode;
    Vector3 buildOffset;
    
    public void AttachNode(GameObject node, Vector3 buildOffset = new Vector3())
    {
        if (!node)
        {
            transform.position = new Vector3(0, -100, 0);
            return;
        }

        if (!node.HasComponent<Node>())
        {
            Debug.LogError("Given GameObject is not a node");
            return;
        }

        attachedNode = node;
        this.buildOffset = buildOffset;
    }

    public void Build(GameObject turret)
    {
        Node node = attachedNode.GetComponent<Node>();
        if (node.turret)
            return;

        node.turret = Instantiate(turret, attachedNode.transform.position + buildOffset, attachedNode.transform.rotation, attachedNode.transform.parent);
    }
}
