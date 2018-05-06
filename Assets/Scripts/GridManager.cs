using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GridManager : MonoBehaviour {
	

	const int gridSize = 5;
	public int GridSize {
		get{
			return gridSize;
		}
	}


	public Tile[] tiles = new Tile[gridSize*gridSize];	//used for collision and pathfinding
	public GameObject tilePrefab;
	public GameObject playerPrefab;
	public GameObject BoxPrefab;
	public GameObject TargetPrefab;
	public GameObject WallPrefab;
	// Use this for initialization
	public static GridManager instance;
	public int levelNum;

	void Start () {
		levelNum = 1;

		if(instance == null){
			instance = this;
		}

		var camHeight = Camera.main.orthographicSize * 2;
		var camWidth = camHeight * (16/9);
		transform.position = new Vector3(-(camWidth - gridSize), -(camHeight - gridSize));
		//instantiate tiles
		for(int y = gridSize - 1; y >= 0; y--){
			for(int x = 0; x < gridSize; x++){
				var tile = Instantiate(tilePrefab, transform.position + new Vector3(x,y,1), Quaternion.identity);
				tile.transform.parent = transform;
				tile.GetComponent<Tile>().type = TileType.Empty;
				tiles[x + y * gridSize] = tile.GetComponent<Tile>();
			}
		}
		loadLevel();
	}

	public void loadLevel(){
		//open file
		//read one char at a time and instantiate accordingly
		//close the file
		// FileStream inStream = File.Open("one.lvl", FileMode.Open);

		// inStream.

		try {
			using(StreamReader sr = new StreamReader("Assets/Levels/one.lvl")){
				
				while(!sr.EndOfStream)
				{
					String data = sr.ReadLine();
					String[] line = data.Split(' ');
					for(int i = 0; i < line.Length; i++) {
						switch(line[i]){
							case "1":
								//instantiate whatever
								var player = Instantiate(playerPrefab, transform.position + new Vector3(i%gridSize, (int)i/gridSize), Quaternion.identity);
								player.transform.parent = transform;
							//player
								break;
							case "2":
								var box = Instantiate(BoxPrefab, transform.position + new Vector3(i%gridSize, (int)i/gridSize), Quaternion.identity);
								box.transform.parent = transform;
								break;
							case "3":
								var target = Instantiate(TargetPrefab, transform.position + new Vector3(i%gridSize, (int)i/gridSize), Quaternion.identity);
								target.transform.parent = transform;
								break;
							case "4":
								var wall = Instantiate(WallPrefab, transform.position + new Vector3(i%gridSize, (int)i/gridSize), Quaternion.identity);
								wall.transform.parent = transform;
								break;
							default:
								break;
						}
					}
				}
			}
		} catch(Exception e) {
			Debug.LogError("The file could not be read");
			Debug.LogError(e.Message);
		}

	}

	public Vector2Int toGridPos(Vector3 pos){
		return new Vector2Int((int)Mathf.Round(pos.x - transform.position.x), (int)Mathf.Round(pos.y - transform.position.y));
	}

	public Vector3 toWorldPos(Vector2Int pos){
		return new Vector3(transform.position.x + pos.x, transform.position.y + pos.y, 0);
	}
	
	public TileType GetTileTypes(Vector2Int pos){
		return tiles[pos.x + pos.y * gridSize].type;
	}

	public GameObject GetObjectAtTile(Vector2Int pos){
		return tiles[pos.x + pos.y * gridSize].GetComponent<Tile>().entity;
	}

	public bool isEmptyAt(Vector2Int pos){
		return tiles[pos.x + pos.y * gridSize].GetComponent<Tile>().isEmpty();
	}
}
