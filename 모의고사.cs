using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int[] solution(int[] answers)
        {
            int[] person1 = { 1, 2, 3, 4, 5 };
            int[] person2 = { 2, 1, 2, 3, 2, 4, 2, 5 };
            int[] person3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };
            int[] scores = { 0, 0, 0 };
            for(int i=0;i<answers.Length;i++)
            {
                if (person1[i % 5] == answers[i])
                    scores[0]++;
                if (person2[i % 8] == answers[i])
                    scores[1]++;
                if (person3[i % 10] == answers[i])
                    scores[2]++;
            }
            int cnt = 0;
            for (int i = 0; i < 3; i++)
            {
                if (scores[i] == scores.Max())
                    cnt++;
            }
            int[] answer = new int[cnt];
            cnt=0;
            for (int i = 0; i < 3; i++)
            {
                if (scores[i] == scores.Max())
                    answer[cnt++] = i+1;
            }
                return answer;
        }

}