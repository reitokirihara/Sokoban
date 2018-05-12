using System;
using UnityEngine;
public class Tile: MonoBehaviour{
    public TileType type;
    GameObject entity;

    public bool isEmpty(){
        return entity == null;
    } 

    public void setEntity(GameObject entity){
        this.entity = entity;
    }

    public GameObject getEntity(){
        return entity;
    }
}