using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    public int score = 0;
    public Text txtFPS;
    private int fps = 0;
    [SerializeField]
    private float timeDelayUpdatePfs = 0f;

    public List <GameObject> Block = new List<GameObject>();
    public float maxObject = 3;

    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);  

        }
        CaculateFPS();
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 1f, spawnRate);
    }

    private void SpawnBlock()
    {
        if(Block.Count >= maxObject)
        {
            return;
        }
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        GameObject obj = Instantiate(block, spawnPos, Quaternion.identity);
        obj.gameObject.SetActive(true);
        Block.Add(obj);       
    }
    public void OnScore()
    {
        scoreText.text = score.ToString();
    }
    public void OnFPS(int fps)
    {
        txtFPS.text = "FPS: " + fps;
    }
    public void CaculateFPS()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        timeDelayUpdatePfs += Time.unscaledDeltaTime;
        if (fps >= 120)
        {
            fps = 120;
        }
        if (timeDelayUpdatePfs >= 0.5f)
        {
            OnFPS(fps);
            timeDelayUpdatePfs = 0f;
        }
    }

}
