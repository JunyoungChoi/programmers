using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int solution(int n, int[,] results)
        {
            HashSet<int>[] win = new HashSet<int>[n];
            HashSet<int>[] lose = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                win[i] = new HashSet<int>();
                lose[i] = new HashSet<int>();
            }
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 0; j < results.GetLength(0); j++)
                {
                    if (results[j, 0] == i)
                        win[i-1].Add(results[j, 1]);
                    else if (results[j, 1] == i)
                        lose[i-1].Add(results[j, 0]);
                }
                foreach (int j in lose[i-1])
                {
                    foreach (int k in win[i-1])
                    {
                        win[j-1].Add(k);
                    }
                }
                foreach (int j in win[i-1])
                {
                    foreach (int k in lose[i-1])
                    {
                        lose[j-1].Add(k);
                    }
                }
            }
            int answer = 0;
            for (int i = 1; i < n + 1; i++)
            {
                if (win[i - 1].Count + lose[i - 1].Count == n - 1)
                    answer++;
            }
                return answer;
        }
}