using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Boat", menuName = "ScriptableObjects/Boat", order = 1)]
public class Boat : ScriptableObject
{

    public int voyages = 0;
    public int crew = 1;
    public int sails = 1;
    public int food = 10;
    public int oars = 2;
    public int fishing = 0;
    public int weapons = 0;
    public int passengers = 0;
    public int lumber = 0;
    public int goods = 0;
    public int hull = 100;


    [SerializeField] int defaultSpeed;





}
