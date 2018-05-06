using System;
using UnityEngine;
public class Tile: MonoBehaviour{
    public TileType type;
    public GameObject entity;

    public bool isEmpty(){
        return entity == null;
    }
}