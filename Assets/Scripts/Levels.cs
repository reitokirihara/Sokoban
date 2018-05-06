using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

	public int[] level1 = new int[GridManager.instance.GridSize * GridManager.instance.GridSize];
	
	
	// var wall = Instantiate(WallPrefab, transform.position + new Vector3(0,4), Quaternion.identity);
	// 	var wall2 = Instantiate(WallPrefab, transform.position + new Vector3(1,4), Quaternion.identity);
	// 	var wall3 = Instantiate(WallPrefab, transform.position + new Vector3(2,4), Quaternion.identity);
	// 	var wall4 = Instantiate(WallPrefab, transform.position + new Vector3(3,4), Quaternion.identity);
	// 	var wall5 = Instantiate(WallPrefab, transform.position + new Vector3(4,4), Quaternion.identity);

	// 	tiles[0 + 4 * gridSize].entity = wall;
	// 	tiles[1 + 4 * gridSize].entity = wall;
	// 	tiles[2 + 4 * gridSize].entity = wall;
	// 	tiles[3 + 4 * gridSize].entity = wall;
	// 	tiles[4 + 4 * gridSize].entity = wall;

	// 	wall.transform.parent = transform;
	// 	wall2.transform.parent = transform;
	// 	wall3.transform.parent = transform;
	// 	wall4.transform.parent = transform;
	// 	wall5.transform.parent = transform;

	// 	var target = Instantiate(TargetPrefab, transform.position + new Vector3(3,3,0.5f), Quaternion.identity);
	// 	tiles[3 + 3 * gridSize].entity = target;
	// 	target.transform.parent = transform;

	// 	var player = Instantiate(playerPrefab, transform.position + new Vector3(2,2), Quaternion.identity);
	// 	tiles[2 + 2 * gridSize].entity = player;
	// 	player.GetComponent<PlayerController>().tilePos = new Vector2Int(2,2);
	// 	player.transform.parent = transform;

	// 	var box = Instantiate(BoxPrefab, transform.position + new Vector3(1,1), Quaternion.identity);
	// 	tiles[1 + 1 * gridSize].entity = box;
	// 	box.transform.parent = transform;
}
