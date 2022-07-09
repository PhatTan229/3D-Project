using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Book : MonoBehaviour
{
	public float waitingDuration;
	public float turningDuration;
	public Page[] pages;
	public AudioSource audi;
	public AudioClip openCloseSound;
	public AudioClip pageTurnSound;
	private int totalPages;
	private int currentPage;
	private IEnumerator Start()
	{
		totalPages = pages.Length;
		int level = DatabaseController.Instance.data.level;
		SetCurrentPage(level);
		yield return new WaitForSeconds(waitingDuration);
		pages[level].GetTurned(turningDuration);
		if (level == 0 || level == pages.Length - 1) audi.PlayOneShot(openCloseSound);
		else audi.PlayOneShot(pageTurnSound);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
			pages[1].anim.Play("RL");
        }
		if (Input.GetKeyDown(KeyCode.L))
		{
			pages[1].anim.Play("LR");
		}
	}

    private void SetCurrentPage(int page)
    {
		currentPage = page;
		for (int i = 0; i < pages.Length; i++)
        {
			bool isFront = i < page;
			pages[i].OnOnePageSetting(isFront);
        }
    }
}