using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSafeGround : MonoBehaviour {

    void OnMouseDown()
    {
        BuildManager.Shop.GetComponent<Shop>().AttachNode(null);
    }
}
