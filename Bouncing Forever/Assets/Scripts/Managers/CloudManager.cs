using UnityEngine;

public class CloudManager : SpawnableManager
{
    public static CloudManager Instance; // variable that holds the instance for the singleton setup

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
        InitializePool(initializeAmount, "Clouds", initializeSpawnPos, initializeGap, initializeY, true);
    }
}