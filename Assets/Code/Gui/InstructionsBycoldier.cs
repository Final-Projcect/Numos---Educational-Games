using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsBycoldier : MonoBehaviour
{
    //
    public GameObject Instruction;
    private GameObject instisinateInstruction;
    public string tag;
    bool alredyon = false;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag && alredyon == false)
        {
            if (done==false)
            {
                instisinateInstruction = Instantiate(Instruction);
                alredyon = true;
            }
            else
                SceneManager.LoadScene("KingChallange");

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (done == false)
        {
            Destroy(instisinateInstruction);
            alredyon = false;
        }
        
    }
}
