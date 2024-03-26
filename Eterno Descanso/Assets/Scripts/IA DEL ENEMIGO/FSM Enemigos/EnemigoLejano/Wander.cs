using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : State
{
    // Start is called before the first frame update

      
    private EnemigoDeLejos enemigo;

    public Wander(EnemigoDeLejos _enemigo)
    {
        enemigo = _enemigo;
    }

    public override void OnEnter(GameObject _object)
    {

    }
    public override void Reason(GameObject _object)
    {

    }

    public override void Act(GameObject _object)
    {
        // Calcular la posición del punto de origen del raycast con un desplazamiento hacia adelante


        RaycastHit2D RayCastWall = Physics2D.Raycast(enemigo.Muzzle.transform.position, enemigo.transform.up, enemigo.checkDistance);


        Debug.DrawRay(enemigo.Muzzle.transform.position, enemigo.transform.up * enemigo.checkDistance, Color.blue);

        if (RayCastWall.collider != null)
        {
            
            // Aquí puedes dibujar un rayo adicional para visualizar dónde se encuentra el raycast en relación con el enemigo
            Debug.DrawRay(enemigo.Muzzle.transform.position, enemigo.transform.up * enemigo.checkDistance, Color.green);
            ;

            if (RayCastWall.collider.CompareTag("Wall")) // Asegúrate de que tus paredes tengan el tag "Wall"
            {
                Debug.DrawRay(enemigo.transform.position, enemigo.transform.up * enemigo.checkDistance, Color.red);
                ChangeDirection();
            }
        }
        //enemigo.transform.Translate(enemigo.direction * enemigo.enemySpeed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        // Cambia la dirección de manera aleatoria
        float rndm = Random.Range(1, 3);
        enemigo.transform.Rotate(0, 0, 90 * rndm);
    }
}
