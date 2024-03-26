using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDeLejos : EnemyBehaviour
{
    // Start is called before the first frame update

    private FSM enemyFSM;
    void Start()
    {
        base.Start();
        enemyFSM = new FSM(gameObject, this);
        Wander patrullar = new Wander(this);
        enemyFSM.AddState(estados.Patrullar, patrullar);
        enemyFSM.ChangeState(estados.Patrullar);
        enemyFSM.Activate();
    }

    // Update is called once per frame
    void Update()
    {

        base.Update();
        enemyFSM.UpdateFSM();

    }
}

public enum estados{
    Patrullar,
}