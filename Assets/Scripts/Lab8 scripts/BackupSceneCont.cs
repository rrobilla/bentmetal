using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupSceneCont : MonoBehaviour {
	[SerializeField] private GameObject _Iguana;
	[SerializeField] private GameObject _enemyPrefab;
	//private GameObject _enemy;
	//private GameObject _iguana;
	public static int numberOfEnemies;
	public static int numberOfIguanas = 5;
	private GameObject[] enemiesList;
	private static GameObject[] iguanas;


	// Use this for initialization
	void Start () {
		numberOfEnemies = PlayerPrefs.GetInt("numEnemies",1);
		enemiesList = new GameObject[numberOfEnemies];
		iguanas = new GameObject[numberOfIguanas];

	}
	
	// Update is called once per frame
		void Update () {


				
			for (int i = 0; i < enemiesList.Length; i++) {
				if (enemiesList [i] == null) {
					enemiesList [i] = Instantiate (_enemyPrefab) as GameObject;
					enemiesList [i].transform.position = new Vector3 (-18, 0, 5);
					float angle = Random.Range (0, 360);
					enemiesList [i].transform.Rotate (0, angle, 0);
				}
			}

			for (int i = 0; i < iguanas.Length; i++) {
				if (iguanas [i] == null) {
					iguanas[i] = Instantiate (_Iguana) as GameObject;
					iguanas [i].transform.position = new Vector3 (18, 0, 5);
					float angle = Random.Range (0, 360);
					iguanas [i].transform.Rotate (0, angle, 0);

				}
			}
			numberOfEnemies = PlayerPrefs.GetInt ("numEnemies", 1);
			if (numberOfEnemies != enemiesList.Length){
				foreach(GameObject enemy in enemiesList){
					Destroy(enemy);
				}
				//Destroy(enemiesList);
				enemiesList = new GameObject[numberOfEnemies];
			}
		}
}
