using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldSpawn : MonoBehaviour
{
    public int worldSize = 20;
    public float maxDistanceFromCenter;
    public float withinLayerRandomRange = .5f;
    public float layerDelayScalar = 3;
    public Material mainmat;
    public Material secondMat;
    public GameObject tree1;
    public Transform navParent;
    public Transform vegParent;
    //public NavMeshSurface surface;
    public GameObject enemy;
    public GameObject player;
    public GameObject hedge;
    public GameObject chest;
    public GameObject hedgeEntrance;
    private GameObject vegInstance;
    private System.Random RND = new System.Random();

    // Use this for initialization
    void Start() //maybe change back to start
    {

        int player_x = worldSize/2;   int player_z = 0;
        int enemy_1x = 0;             int enemy_1z = worldSize/2;
        int enemy_2x = 0;             int enemy_2z = -worldSize/2;
        int enemy_3x = -worldSize/2;  int enemy_3z = 0;


        maxDistanceFromCenter = Mathf.Sqrt(Mathf.Pow(worldSize/2, 2) + Mathf.Pow(worldSize/2, 2));
        //blocks = new GameObject[worldSize*worldSize + 50];

        GameObject enemyInstance;
        GameObject playerInstance = Instantiate(player, new Vector3(player_x,2,player_z), Quaternion.Euler(0,-90,0));
        playerInstance.name = "(" + player_x.ToString() + "," + player_z.ToString() + ")";

        enemyInstance = Instantiate(enemy, new Vector3(enemy_1x,2,enemy_1z), Quaternion.Euler(0,90,0));
        enemyInstance.name = "(" + enemy_1x.ToString() + "," + enemy_1z.ToString() + ")";
        //enemyInstance.name = "Enemy1";

        enemyInstance = Instantiate(enemy, new Vector3(enemy_2x,2,enemy_2z), Quaternion.Euler(0,90,0));
        enemyInstance.name = "(" + enemy_2x.ToString() + "," + enemy_2z.ToString() + ")";

        enemyInstance = Instantiate(enemy, new Vector3(enemy_3x,2,enemy_3z), Quaternion.Euler(0,90,0));
        enemyInstance.name = "(" + enemy_3x.ToString() + "," + enemy_3z.ToString() + ")";

        CreateWorld();
        //shouldn't need this, as all the objects in the world that are part of the nav mesh should have been created in createWorld()
        //surface.BuildNavMesh();

    }


    public void CreateWorld()
    {

        if(worldSize%2 == 0){worldSize++;}


        float hedge_y = 1.4f;
        float chest_y = 0.5f;
        float tree1_y = 0.5f;

        CreateHedges(hedge_y);
        CreateChests(chest_y);

        for (int x = -worldSize/2; x <= worldSize/2; x++)
        {
            for (int z = -worldSize / 2; z <= worldSize / 2; z++)
            {
              //create block
              GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
              block.transform.SetParent(navParent, false);
              block.isStatic = true;
              int y = RND.Next(0,2);
              //float y = (float)RND.NextDouble(); //if wanting to makeit look less geometric
              switch(y){
                case 0:
                  block.GetComponent<Renderer>().material = secondMat; block.name = "Rock"; break;
                case 1:
                  block.GetComponent<Renderer>().material = mainmat; block.name = "Grass"; break;
                default:
                  block.GetComponent<Renderer>().material = mainmat; block.name = "Grass"; break;
              }
              block.transform.position = new Vector3(x, 0, z);

              string name = "(" + x.ToString() + "," + z.ToString() + ")";
              if(GameObject.Find(name) == null)
              { //creates trees and chests and powerups
                int rand = RND.Next(0,100);
                int y_rotation = RND.Next(0,361);
                if(rand == 55)// || rand == 6)
                {
                  vegInstance = Instantiate(tree1, new Vector3((float)x,(float)tree1_y,(float)z), Quaternion.Euler(0,y_rotation,0));
                  vegInstance.transform.SetParent(vegParent, false);
                  vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
                }
              }
              StartCoroutine(DropBlock(block));
            }
        }
  }

public void CreateChests(float chest_y)
{
  //while x >= name
  //while x <= -name
  int outerCircleSize = 12;
  int name = worldSize/2 - outerCircleSize;
  GameObject obj;
  for(int x = name; x <= worldSize/2; x++)
  {
    for(int z = -worldSize/2; z <= worldSize/2; z++)
    {
      string nameX = "(" + x.ToString() + "," + z.ToString() + ")";
      if(GameObject.Find(nameX) == null)
      {
        if(RND.Next(0, 60) == 8)
        {
          int y_rotation = RND.Next(0,361);
          vegInstance = Instantiate(chest, new Vector3((float)x,(float)chest_y,(float)z), Quaternion.Euler(0,y_rotation,0));
          vegInstance.transform.SetParent(vegParent, false);
          vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
        }
      }
    }
  }
  for(int x = -name; x >= -worldSize/2; x--)
  {
    for(int z = -worldSize/2; z <= worldSize/2; z++)
    {
      string nameX = "(" + x.ToString() + "," + z.ToString() + ")";
      if(GameObject.Find(nameX) == null)
      {
        if(RND.Next(0, 60) == 8)
        {
          int y_rotation = RND.Next(0,361);
          vegInstance = Instantiate(chest, new Vector3((float)x,(float)chest_y,(float)z), Quaternion.Euler(0,y_rotation,0));
          vegInstance.transform.SetParent(vegParent, false);
          vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
        }
      }
    }
  }
  for(int z = name; z <= worldSize/2; z++)
  {
    for(int x = -worldSize/2; x <= worldSize/2; x++)
    {
      string nameX = "(" + x.ToString() + "," + z.ToString() + ")";
      if(GameObject.Find(nameX) == null)
      {
        if(RND.Next(0, 60) == 8)
        {
          int y_rotation = RND.Next(0,361);
          vegInstance = Instantiate(chest, new Vector3((float)x,(float)chest_y,(float)z), Quaternion.Euler(0,y_rotation,0));
          vegInstance.transform.SetParent(vegParent, false);
          vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
        }
      }
    }
  }
  for(int z = -name; z >= -worldSize/2; z--)
  {
    for(int x = -worldSize/2; x <= worldSize/2; x++)
    {
      string nameX = "(" + x.ToString() + "," + z.ToString() + ")";
      if(GameObject.Find(nameX) == null)
      {
        if(RND.Next(0, 60) == 8)
        {
          int y_rotation = RND.Next(0,361);
          vegInstance = Instantiate(chest, new Vector3((float)x,(float)chest_y,(float)z), Quaternion.Euler(0,y_rotation,0));
          vegInstance.transform.SetParent(vegParent, false);
          vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
        }
      }
    }
  }
}
public void CreateHedges(float hedge_y)
{


    //float outer = ((1/3)*(worldSize/2));
    int outerCircleSize = 12;
    int name = worldSize/2 - outerCircleSize;
    GameObject obj;
    obj = Instantiate(hedgeEntrance, new Vector3((float)-name, (float)hedge_y, (float)0), Quaternion.Euler(0,0,90));
      obj.name = "(" + (-name).ToString() + "," + (0).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3((float)-name, (float)hedge_y, (float)1), Quaternion.Euler(0,0,90));
      obj.name = "(" + (-name).ToString() + "," + (1).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3((float)-name, (float)hedge_y, (float)-1), Quaternion.Euler(0,0,90));
      obj.name = "(" + (-name).ToString() + "," + (-1).ToString() + ")";
      obj.transform.SetParent(vegParent, false);

    obj = Instantiate(hedgeEntrance, new Vector3((float)name, (float)hedge_y, (float)0), Quaternion.Euler(0,0,90));
      obj.name = "(" + (name).ToString() + "," + (0).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3((float)name, (float)hedge_y, (float)1), Quaternion.Euler(0,0,90));
      obj.name = "(" + (name).ToString() + "," + (1).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3((float)name, (float)hedge_y, (float)-1), Quaternion.Euler(0,0,90));
      obj.name = "(" + (name).ToString() + "," + (-1).ToString() + ")";
      obj.transform.SetParent(vegParent, false);


    obj = Instantiate(hedgeEntrance, new Vector3( (float)0, (float)hedge_y, (float)-name), Quaternion.Euler(0,0,90));
      obj.name = "(" + (0).ToString() + "," + (-name).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3( (float)-1, (float)hedge_y, (float)-name), Quaternion.Euler(0,0,90));
      obj.name = "(" + (-1).ToString() + "," + (-name).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3( (float)1, (float)hedge_y, (float)-name), Quaternion.Euler(0,0,90));
      obj.name = "(" + (1).ToString() + "," + (-name).ToString() + ")";
      obj.transform.SetParent(vegParent, false);

    obj = Instantiate(hedgeEntrance, new Vector3( (float)0, (float)hedge_y, (float)name), Quaternion.Euler(0,0,90));
      obj.name = "(" + 0.ToString() + "," + (name).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3( (float)-1, (float)hedge_y, (float)name), Quaternion.Euler(0,0,90));
      obj.name = "(" + (-1).ToString() + "," + (name).ToString() + ")";
      obj.transform.SetParent(vegParent, false);
    obj = Instantiate(hedgeEntrance, new Vector3( (float)1, (float)hedge_y, (float)name), Quaternion.Euler(0,0,90));
      obj.name = "(" + (1).ToString() + "," + (name).ToString() + ")";
      obj.transform.SetParent(vegParent, false);

  for(int j = name; j<=(worldSize/2); j++)
  {
    GameObject obj1;
    obj1 = Instantiate(hedge, new Vector3((float)-j, (float)hedge_y, (float)-j), Quaternion.Euler(0,0,90));
      obj1.name = "(" + (-j).ToString() + "," + (-j).ToString() + ")";
      obj1.transform.SetParent(vegParent, false);
    obj1 = Instantiate(hedge, new Vector3((float)-j, (float)hedge_y, (float)j), Quaternion.Euler(0,0,90));
      obj1.name = "(" + (-j).ToString() + "," + (j).ToString() + ")";
      obj1.transform.SetParent(vegParent, false);
    obj1 = Instantiate(hedge, new Vector3((float)j, (float)hedge_y, (float)-j), Quaternion.Euler(0,0,90));
      obj1.name = "(" + (j).ToString() + "," + (-j).ToString() + ")";
      obj1.transform.SetParent(vegParent, false);
    obj1 = Instantiate(hedge, new Vector3((float)j, (float)hedge_y, (float)j), Quaternion.Euler(0,0,90));
      obj1.name = "(" + (j).ToString() + "," + (j).ToString() + ")";
      obj1.transform.SetParent(vegParent, false);
  }

  for(int h = -1; h <= 1; h++)
  {

      int x;
      int z = h * ((worldSize/2) - outerCircleSize);
      for(x = -worldSize/2; x <= worldSize/2; x++)
      {
        if(z == 0)
        {
          //
        }
        else if(x <= z)
        {
          if(((-1* x) <= z) || ((-1* x) <= (-1* z)))
          {
            string strnam = "(" + x.ToString() + "," + z.ToString() + ")";
            if(GameObject.Find(strnam) == null)
            {
              vegInstance = Instantiate(hedge, new Vector3((float)x, (float)hedge_y, (float)z), Quaternion.Euler(0,0,90));
              vegInstance.transform.SetParent(vegParent, false);
              //vegMap[x,z] = 2;
              vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
              //vegInstance.isStatic = true;
            }
          }
        }
        else if(x >= z)
        {
          if(((-1* x) >= z) || ((-1* x) >= (-1* z)))
          {
            string strnam = "(" + x.ToString() + "," + z.ToString() + ")";
            if(GameObject.Find(strnam) == null)
            {
              vegInstance = Instantiate(hedge, new Vector3((float)x, (float)hedge_y, (float)z), Quaternion.Euler(0,0,90));
              vegInstance.transform.SetParent(vegParent, false);
            //vegMap[x,z] = 2;
              vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
              //vegInstance.isStatic = true;
            }
          }
        }
      }
    }

    for(int h = -1; h <= 1; h++){
      int z;
      int x = h * ((worldSize/2) - outerCircleSize);
      for(z = -worldSize/2; z <= worldSize/2; z++){
        if(x == 0){
          //
        }
        else if(z <= x){
          if(((-1*z) <= x) || ((-1*z) <= (-1*x))){

            string strnam = "(" + x.ToString() + "," + z.ToString() + ")";
            if(GameObject.Find(strnam) == null)
            {
              vegInstance = Instantiate(hedge, new Vector3((float)x, (float)hedge_y, (float)z), Quaternion.Euler(0,0,90));
              vegInstance.transform.SetParent(vegParent, false);
              //vegMap[x,z] = 2;
              vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
              //vegInstance.isStatic = true;
            }
          }
        }
        else if(z >= x){
          if(((-1*z) >= x) || ((-1*z) >= (-1*x))){
            string strnam = "(" + x.ToString() + "," + z.ToString() + ")";
            if(GameObject.Find(strnam) == null)
            {
              vegInstance = Instantiate(hedge, new Vector3((float)x, (float)hedge_y, (float)z), Quaternion.Euler(0,0,90));
              vegInstance.transform.SetParent(vegParent, false);
            //  vegMap[x,z] = 2;
              vegInstance.name = "(" + x.ToString() + "," + z.ToString() + ")";
              //vegInstance.isStatic = true;
            }
          }
        }
      }
    }
  }

    IEnumerator DropBlock(GameObject block)
    {
        float x = block.transform.position.x;
        float z = block.transform.position.z;
        float distanceFromCenter = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));
        float minimumDropTime = (maxDistanceFromCenter - distanceFromCenter)  * layerDelayScalar;

        yield return new WaitForSeconds(Random.Range(minimumDropTime, minimumDropTime + withinLayerRandomRange));
        //for random drop
        //yield return new WaitForSeconds(Random.Range(0.0f, 10.0f));
        Renderer blockRenderer = block.GetComponent<Renderer>();
        blockRenderer.material.color = new Color(0, 255, 0);
        Rigidbody gameObjectsRigidBody = block.AddComponent<Rigidbody>(); // Add the rigidbody.
        gameObjectsRigidBody.mass = 5;


        yield return new WaitForSeconds(0.1f);
        int x_1 = (int) x;
        int z_1 = (int) z;
        string name = "(" + x_1.ToString() + "," + z_1.ToString() + ")";
        if(GameObject.Find(name) != null)
        {
          GameObject veg = GameObject.Find(name);
          Rigidbody vegRB = veg.AddComponent<Rigidbody>();
          Collider m_collider = veg.GetComponent<Collider>();
          vegRB.mass = 20;
          m_collider.enabled = false;
        }


        yield return new WaitForSeconds(0.1f);
        blockRenderer.enabled = false;
      //  surface.BuildNavMesh();
    }


}
