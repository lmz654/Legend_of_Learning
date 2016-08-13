using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Question[] questions;
	private static List<Question> unansweredQuestions;
	int counter = 0;
	private Question currentQuestion;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private Text trueAnswerText;

	[SerializeField]
	private Text falseAnswerText;

	//[SerializeField]
	//private int counter;

	[SerializeField]
	private Text count;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float timebetweenQuestions = 1f;

	void Start()
	{
        Cursor.visible = true;
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) 
		{
			unansweredQuestions = questions.ToList<Question>();
		}

		setCurrentQuestion();
		//counter = 0;

	}

	void setCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];

		factText.text = currentQuestion.fact;

		if (currentQuestion.isTrue) {
			trueAnswerText.text = "Correct";
			falseAnswerText.text = "Wrong";

			++counter;
		} else {
			trueAnswerText.text = "Wrong";
			falseAnswerText.text = "Correct";
		}
		count.text = "Points: " + counter;
	}

	IEnumerator TransitionToNextQuestion()
	{
		unansweredQuestions.Remove(currentQuestion);

		yield return new WaitForSeconds(timebetweenQuestions);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void UserSelectTrue ()
	{
		animator.SetTrigger ("True");
		if (currentQuestion.isTrue) {
			Debug.Log ("Correct!");
		} else {
			Debug.Log ("Wrong!");
		}

		StartCoroutine (TransitionToNextQuestion ());
	}

	public void UserSelectFalse ()
	{
		animator.SetTrigger ("False");
		if (!currentQuestion.isTrue) {
			Debug.Log ("Correct!");
		} else {
			Debug.Log ("Wrong!");
		}

		StartCoroutine (TransitionToNextQuestion ());
	}
}
