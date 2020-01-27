using UnityEngine;

public class TreeManager : SpawnableManager
{
    public static TreeManager Instance; // variable that holds the instance for the singleton setup

    public int initializeAmount;
    public float initializeSpawnPos;
    public float initializeGap;
    [Tooltip("The random range to spawn between for the Y value (set X to desired value and Y to 0 if no range needed)")]
    public Vector2 initializeY;

    void Awake()
    {
        // Check if the Instance variable is not null and not 'this'
        if (Instance != null && Instance != this)
        {
            // Destroy gameObject connected to this script if Instance is already defined
            Destroy(this.gameObject);
        }
        else
        {
            // Assign 'this' to the Instance variable if Instance is null
            Instance = this;
        }
    }

    public override void Start()
    {
        base.Start();
        base.isScenery = true;
        InitializePool(2, "Trees", -8f, 12f, new Vector2(0f, 0f), false);
    }

    void Update()
    {
        // Update the timer based on the (difficulty / startingDifficulty) so at the beginning its 1f
        currentTimer += Time.deltaTime * (DifficultyManager.Instance.difficulty / DifficultyManager.Instance.startingDifficulty);

        // Check if the timer is equal to or more than the gap time
        if (currentTimer >= currentGap)
        {
            SpawnObject("Trees", 16f, new Vector2(0f, 0f), false);
            // Reset timer and pick new random gap time
            currentTimer = 0f;
            currentGap = Random.Range(gapRange.x, gapRange.y);
        }
    }
}