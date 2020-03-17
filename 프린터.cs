using System;
using System.Linq;
using System.Collections.Generic;
public class Solution {
    public int solution(int[] priorities, int location)
        {
            int answer = 1;
            Queue<Tuple<int,int>> printPriorities = new Queue<Tuple<int,int>>();
            for (int i = 0; i < priorities.Count(); i++)
            {
                printPriorities.Enqueue(new Tuple<int, int>(i, priorities[i]));
            }
            while (true)
            {
                Tuple<int, int> temp = printPriorities.Dequeue();
                for (int i = 0; i < priorities.Count(); i++)
                {
                    if (priorities[i] > temp.Item2)
                    {
                        printPriorities.Enqueue(temp);
                        break;
                    }
                    else if (i == priorities.Count() - 1)
                    {

                        if (location == temp.Item1)
                        {
                            return answer;
                        }
                        priorities[temp.Item1] = 0;
                        answer++;
                    }
                }
            }
        }
}