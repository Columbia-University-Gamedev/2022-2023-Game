using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel;
    public float currentMoney;
    public float currentHappiness;
    public GameGrid gameGrid;
    public boolean emergencyCalled;
    public GameEntity[] potentialHeroes; //heroes that will be available when SOE is called. Will heroes be a subclass or just a GameEntity?
    public GameEntiy? currentHero; //nullable GameEntity, set to a hero when SOE is called

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
