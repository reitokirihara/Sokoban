using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Vector2Int tilePos;

	public Text gameText;
	private bool move = true;
	// Use this for initialization
	void Start () {
		gameText = GameObject.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
			//move up
			MovePlayer(Vector2Int.up);
		}
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
			//move up
			MovePlayer(new Vector2Int(-1, 0));
		}
		
		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
			MovePlayer(new Vector2Int(0, -1));
		}
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
			//move up
			MovePlayer(Vector2Int.right);
		}
	}

	void MovePlayer(Vector2Int dir){
		//check the new position is empty/valid
		//if it is then change our players grid and world pos
		Vector2Int newPos = GridManager.instance.toGridPos(transform.position) + dir;
		Vector2Int newBoxPos = newPos + dir;
		if(move == true){
			if(newPos.x >= 0 && newPos.x < GridManager.instance.GridSize && newPos.y >= 0 && newPos.y < GridManager.instance.GridSize){
				if(GridManager.instance.isEmptyAt(newPos) || GridManager.instance.GetObjectAtTile(newPos).name == "Target(Clone)"){
					GridManager.instance.tiles[tilePos.x + tilePos.y * GridManager.instance.GridSize].entity = null;
					GridManager.instance.tiles[newPos.x + newPos.y * GridManager.instance.GridSize].entity = gameObject;
					tilePos = newPos;
					transform.localPosition = new Vector3(newPos.x, newPos.y, 0);
				} else if(GridManager.instance.GetObjectAtTile(newPos).name == "Box(Clone)"){
					if(newBoxPos.x >= 0 && newBoxPos.x < GridManager.instance.GridSize && newBoxPos.y >= 0 && newBoxPos.y < GridManager.instance.GridSize){
						if(GridManager.instance.isEmptyAt(newBoxPos)){
							var box = GridManager.instance.GetObjectAtTile(newPos);
							Debug.Log("pushing " + box  + " to " + newBoxPos);
							GridManager.instance.tiles[tilePos.x + tilePos.y * GridManager.instance.GridSize].entity = null;
							box.transform.localPosition = new Vector3(newBoxPos.x, newBoxPos.y, 0);
							GridManager.instance.tiles[newPos.x + newPos.y * GridManager.instance.GridSize].entity = gameObject;
							GridManager.instance.tiles[newBoxPos.x + newBoxPos.y * GridManager.instance.GridSize].entity = box;
							tilePos = newPos;
							transform.localPosition = new Vector3(newPos.x, newPos.y, 0);
						} else if(GridManager.instance.GetObjectAtTile(newBoxPos).name == "Target(Clone)"){
							var box = GridManager.instance.GetObjectAtTile(newPos);
							GridManager.instance.tiles[tilePos.x + tilePos.y * GridManager.instance.GridSize].entity = null;
							box.transform.localPosition = new Vector3(newBoxPos.x, newBoxPos.y, 0);
							GridManager.instance.tiles[newPos.x + newPos.y * GridManager.instance.GridSize].entity = gameObject;
							GridManager.instance.tiles[newBoxPos.x + newBoxPos.y * GridManager.instance.GridSize].entity = box;
							tilePos = newPos;
							transform.localPosition = new Vector3(newPos.x, newPos.y, 0);
							box.GetComponent<MeshRenderer>().material.color = Color.white;
							gameText.text = "Solved!!!";
							move = false;
						}
					}
				}
			}
			else{
				Debug.Log("invalid position");
			}
		}
	}
}
