using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{	
	private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
		{
			PauseFunction();
		}
    }
	
	public void PauseFunction()
	{
		MonoBehaviour.print("Hit pause");
			if (this.paused)
			{
				Time.timeScale = 1f;
				MonoBehaviour.print(string.Concat(new object[]
				{
					"Time scale set to ",
					Time.timeScale,
					", ",
					this.paused
				}));
			}
			if (!this.paused)
			{
				Time.timeScale = 0f;
				MonoBehaviour.print(string.Concat(new object[]
				{
					"Time scale set to ",
					Time.timeScale,
					", ",
					this.paused
				}));
			}
			this.paused = !this.paused;
	}
	
	public void PauseMenu()
	{
		//toung king pasue manu
	}
}
