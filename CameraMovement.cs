using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using com.ootii.Input;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] Grid grid;
	[SerializeField] GameObject MainCamera;
	
	[SerializeField] Tilemap map_tilemap;
	[SerializeField] Tilemap map_tilemap_fog;
	
	[SerializeField]
	Tile Tile;
	[SerializeField]
	Tile [] Tiles;
	
	[SerializeField] GameObject player;
	[SerializeField] GameObject playerDot;
	
	[SerializeField] GameObject mapCamera;
	
	//GameObject MainCamera;
	
	Vector3Int old_cellPosition;
	GameObject em;
	Enemy_Manager EM;
	int xcord;
	int ycord;
	int zcord;
	int actnumb;
	
    // Start is called before the first frame update
    void Start()
    {
	    actnumb = PlayerPrefs.GetInt("ActualGameNumber");
    	em = GameObject.Find("Enemy_Manager");
        EM = em.GetComponent<Enemy_Manager> ();
    	
        InputManager.AddAlias("Jump1", EnumInput.GAMEPAD_0_BUTTON);
        InputManager.AddAlias("Right", EnumInput.GAMEPAD_LEFT_STICK_X);
        InputManager.AddAlias("Down", EnumInput.GAMEPAD_LEFT_STICK_Y);
        //InputManager.AddAlias("Down", EnumInput.GAMEPAD_3_BUTTON);
        //InputManager.AddAlias("Throwing", EnumInput.GAMEPAD_1_BUTTON);
        
        InputManager.AddAlias("Jump1", EnumInput.SPACE);
        InputManager.AddAlias("Right", EnumInput.D);
        InputManager.AddAlias("Left", EnumInput.A);
        InputManager.AddAlias("Down", EnumInput.S);
        InputManager.AddAlias("Up", EnumInput.W);
        
        //InputManager.AddAlias("Jump1", EnumInput.UP_ARROW);
        InputManager.AddAlias("Right", EnumInput.RIGHT_ARROW);
        InputManager.AddAlias("Left", EnumInput.LEFT_ARROW);
        InputManager.AddAlias("Down", EnumInput.DOWN_ARROW);
        InputManager.AddAlias("Up", EnumInput.UP_ARROW);
         
        for(int i = 0; i < 200; i++){
			
			xcord = PlayerPrefs.GetInt("MapCord"+actnumb+"_roomx_"+i);
			ycord = PlayerPrefs.GetInt("MapCord"+actnumb+"_roomy_"+i);
			zcord = PlayerPrefs.GetInt("MapCord"+actnumb+"_roomz_"+i);
			
			if(zcord!=100){
				//Vector3 position = transform.position;
				Vector3Int cellPosition = new Vector3Int (xcord,ycord,zcord);
				map_tilemap_fog.SetTile(cellPosition, null);
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
    	if(PlayerPrefs.GetInt("map_active")==0){
    		
    		Vector3Int cellPosition = grid.WorldToCell(transform.position);
	        
    		//Check RoomChange to respawn Enemies
    		if(cellPosition!=old_cellPosition){
    			if(map_tilemap.GetTile(cellPosition)==Tiles[0]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[1]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[3]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[7]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[8]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[1]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[3]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[6]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[3]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[1]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[9]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[6]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[6]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[1]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[8]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[7]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[5] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[1]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[3]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[6] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[7] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[8] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[9]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[6] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[8]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[9]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[7]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[1]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[9]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[8]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[8]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[2]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[7]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[4]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[6]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[9]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[9]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[3]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[7]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[5]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[6]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[8]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[10] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[11]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[11] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[10]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[9]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[12] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[11]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[13] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[14]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[14] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[13]
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[15]){EM.reset=true;}
    			else if(map_tilemap.GetTile(old_cellPosition)==Tiles[15] 
    			        && map_tilemap.GetTile(cellPosition)!=Tiles[14]){EM.reset=true;}
    			//EM.reset=true;
    		}
    		
    		playerDot.transform.position = map_tilemap.GetCellCenterWorld(cellPosition);
	        Vector3 PosMap = map_tilemap.GetCellCenterWorld(cellPosition);
	        PosMap.z=-20;
	        mapCamera.transform.position = PosMap;
	        
	        map_tilemap_fog.SetTile(cellPosition, null);
	        
	        bool run = true;
	        int i = 0;
	        
	        xcord = cellPosition.x;
			ycord = cellPosition.y;
			zcord = cellPosition.z;
	        
			//print("is on: "+xcord+" "+ycord+" "+zcord);
			
	        while(run && i<200){
				if(xcord==PlayerPrefs.GetInt("MapCord"+actnumb+"_roomx_"+i) && ycord==PlayerPrefs.GetInt("MapCord"+actnumb+"_roomy_"+i)){run=false;}
				if(PlayerPrefs.GetInt("MapCord"+actnumb+"_roomz_"+i)==100 && run==true){
					
					run = false;
					PlayerPrefs.SetInt("MapCord"+actnumb+"_roomx_"+i,xcord);
					PlayerPrefs.SetInt("MapCord"+actnumb+"_roomy_"+i,ycord);
					PlayerPrefs.SetInt("MapCord"+actnumb+"_roomz_"+i,zcord);
					//print("saved: "+xcord+" "+ycord+" "+zcord);
					
				}
				i++;
			}
	        //cellPosition.z=-10;
	        
	        if(map_tilemap.GetTile(cellPosition)==Tiles[0]){
	//        	print("Normaler Raum");
	        	MainCamera.transform.position = grid.GetCellCenterWorld(cellPosition);
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[1]){
	//        	print("Ecke oben links");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x<grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	if(Pos.y>grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[2]){
	//        	print("Großer Raum oben mitte");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.y>grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[3]){
	//        	print("Ecke oben rechts");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x>grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	if(Pos.y>grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[4]){
	//        	print("Großer Raum links");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x<grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[5]){
	//        	print("Großer Raum mitte");
	        	Vector3 Pos = player.transform.position;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[6]){
	//        	print("Großer Raum rechts");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x>grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[7]){
	//        	print("Ecke unten links");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x<grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	if(Pos.y<grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[8]){
	//        	print("Großer Raum unten mitte");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.y<grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[9]){
	//        	print("Ecke unten rechts");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x>grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	if(Pos.y<grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[10]){
	//        	print("Korridor vertikal oben");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.y>grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.x=grid.GetCellCenterWorld(cellPosition).x;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[11]){
	//        	print("Korridor vertikal mitte");
	        	Vector3 Pos = player.transform.position;
	        	Pos.x=grid.GetCellCenterWorld(cellPosition).x;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[12]){
	//        	print("Korridor vertikal unten");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.y<grid.GetCellCenterWorld(cellPosition).y){Pos.y=grid.GetCellCenterWorld(cellPosition).y;}
	        	Pos.x=grid.GetCellCenterWorld(cellPosition).x;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[13]){
	//        	print("Korridor horizontal links");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x<grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	Pos.y=grid.GetCellCenterWorld(cellPosition).y;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[14]){
	//        	print("Korridor horizontal mitte");
	        	Vector3 Pos = player.transform.position;
	        	Pos.y=grid.GetCellCenterWorld(cellPosition).y;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
	        else if(map_tilemap.GetTile(cellPosition)==Tiles[15]){
	//        	print("Korridor horizontal rechts");
	        	Vector3 Pos = player.transform.position;
	        	if(Pos.x>grid.GetCellCenterWorld(cellPosition).x){Pos.x=grid.GetCellCenterWorld(cellPosition).x;}
	        	Pos.y=grid.GetCellCenterWorld(cellPosition).y;
	        	Pos.z=grid.GetCellCenterWorld(cellPosition).z;
	        	MainCamera.transform.position = Pos;
	        }
    	}
        if(PlayerPrefs.GetInt("map_active")==1){
        	
        	float horizontal = InputManager.GetValue("Right") - InputManager.GetValue("Left");
	    	float vertical = InputManager.GetValue("Up") - InputManager.GetValue("Down");
	    	
	    	Vector3 pos1 = mapCamera.transform.position;
        	pos1.y+=speed*vertical;
        	pos1.x+=speed*horizontal;
        	mapCamera.transform.position=pos1;
        }
    	
    	old_cellPosition = grid.WorldToCell(transform.position);
    }
}
