using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

[System.Serializable]
public class ArcadeCurrentSeqUpdate : UnityEvent<string[]>
{
}

[System.Serializable]
public class ArcadeSubmitUpdate : UnityEvent<int[]>
{
}

public class ArcadeButtonGroupAction : MonoBehaviour
{
    [SerializeField]
    string[] answer;
    [SerializeField]
    ArcadeCurrentSeqUpdate currentSeqAction;
    [SerializeField]
    ArcadeSubmitUpdate submitAction;

    string[] current_seq;
    int current_index;
    int answer_length;
    string[] colors = { "Red", "Pink", "Purple", "Green", "Light Blue", "Deep Blue" };

    public void AssignBtnFunc(string name)
    {
        if (name == "Delete") { 
            if(current_index != 0)
            {
                current_seq[current_index - 1] = null;
                current_index--;
                currentSeqAction.Invoke(current_seq);
            }
        }else if(name == "Enter")
        {
            if(current_index == answer_length)
            {
                submitAction.Invoke(SubmitCurrentSeq(current_seq));
                current_seq = new string[answer_length];
                current_index = 0;
                currentSeqAction.Invoke(current_seq);
            }
        }else if (colors.Contains(name))
        {
            if(current_index < answer_length && !current_seq.Contains(name))
            {
                current_seq[current_index] = name;
                current_index++;
                currentSeqAction.Invoke(current_seq);
            }
        }
        else
        {
            throw new Exception("Button Name is not registered.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        answer_length = answer.Length;
        current_seq = new string[answer_length];
        current_index = 0;
    }

    int[] SubmitCurrentSeq(string[] guess)
    {
        int both_correct = 0; // both content and position are correct
        int half_correct = 0; // only content correct
        for(int i = 0; i < guess.Length; i++)
        {
            if (String.Equals(guess[i], answer[i]))
            {
                both_correct ++;
            }else if (answer.Contains(guess[i]))
            {
                half_correct ++;
            }
        }
        return new int[] { both_correct, half_correct };
    }
}
