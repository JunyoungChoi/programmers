using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] heights)
        {
            int[] answer = new int[heights.Length];
            Stack<int> stack = new Stack<int>(heights);
            int popNum = stack.Pop();
            for(int i=stack.Count-1;i>=0;i--)
            {
                if (popNum < heights[i])
                {
                    answer[stack.Count] = i+1;
                    popNum = stack.Pop();
                    i = stack.Count;
                    continue;
                }
                else if (i == 0)
                {
                    answer[stack.Count] = 0;
                    popNum = stack.Pop();
                    i = stack.Count; 
                    continue;
                }
            }
            return answer;
        }
}