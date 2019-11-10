using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTester : MonoBehaviour
{
    [SerializeField]
    private CombatManager cm;
    // Start is called before the first frame update
    void Start()
    {
        List<Attack> attacks = new List<Attack>()
        {
            new Attack(5, 10, 20, "attack 1", ""),
            new Attack(15, 35, 65, "attack 2", "")
        };
        PlayerStats ps = new PlayerStats();
        ps.Attacks = attacks;

        Enemy enemy = new Enemy(80, attacks);

        cm.Fight(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
