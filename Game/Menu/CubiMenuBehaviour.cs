using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubiMenuBehaviour : MonoBehaviour
{
    //Been a while since I used comments, welcome back!
    //Today, I'm trying to make a functional level of a non-tutorial game, so let's see if what I know can be used well or if I still need learning.
    //Let's go!

    //Reference to the GameObject Cubi
    public GameObject Cubi;

    //Reference to the Vector3 that will be used to move Cubi up and down on the menu.
    public Vector3 CubiMovementUpDown;

    //Bool to determine whether or not Cubi is twitching.
    public bool Twitching = false;

    //When the scene starts, this will run. Only runs once.
    void Start() 
    {
        //Starts the Enumerator Coroutine. This is required to use time to create function delays.
        StartCoroutine(Enumerator());

        //The Y in CubiMovementUpDown will be randomized when the script starts.
        CubiMovementUpDown.y = Random.Range(0.1f, 1);
    }

    IEnumerator Enumerator()
    {
        //After waiting a random amount between 1 to 10 seconds in Realtime, Cubi's Twitching will be set to true so it will begin.
        yield return new WaitForSecondsRealtime(Random.Range(1, 10));
        Twitching = true;

        //Will occur when Twitching = true.
        if (Twitching == true)
        {
            //Waits a random 1 to 5 seconds in Realtime, then moves Cubi's position by the Vector3 given by CubiMovementUpDown.
            yield return new WaitForSecondsRealtime(Random.Range(1, 5));
            Cubi.transform.position = Cubi.transform.position + CubiMovementUpDown;
            Twitching = false; //Sets Twitching to false, this is essential to allow the twitching to repeat.
            yield return new WaitForSecondsRealtime(1); //After 1 second in Realtime, Cubi's position will be set back to normal.
            Cubi.transform.position = Cubi.transform.position - CubiMovementUpDown;
            Twitching = true; //Sets Twitching to true.

            while (Twitching == true)
            {
                //A while loop is created so this cycle will repeat once Twitching is true.

                //Randomizes CubiMovementUpDown before the next cycle.
                CubiMovementUpDown.y = Random.Range(0.1f, 1);

                //Waits a random 1 to 5 seconds in Realtime, then moves Cubi's position by the Vector3 given by CubiMovementUpDown.
                yield return new WaitForSecondsRealtime(Random.Range(1, 5));
                Cubi.transform.position = Cubi.transform.position + CubiMovementUpDown;
                Twitching = false; //Sets Twitching to false, this is essential to allow the twitching to repeat.
                yield return new WaitForSecondsRealtime(1); //After 1 second in Realtime, Cubi's position will be set back to normal.
                Cubi.transform.position = Cubi.transform.position - CubiMovementUpDown;
                Twitching = true; //Sets Twitching to true.
            }
        }
        
    }
}
