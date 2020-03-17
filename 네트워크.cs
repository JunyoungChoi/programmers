using System;
using System.Collections.Generic;

public class Solution {
    Queue<int> queue = new Queue<int>();
        int answer = 0;
        List<int> visited = new List<int>();
        public int solution(int n, int[,] computers)
        {
            for (int i = 0; i < computers.GetLength(0); i++)
            {
                if ((computers[0, i] == 0 || i == 0) && !visited.Contains(i))
                {
                    visited.Add(i);
                    bfs(i, computers);
                    answer++;
                }
            }
            return answer;
        }
        public void bfs(int i, int[,] computers)
        {
            for (int j = 0; j < computers.GetLength(0); j++)
            {
                if (computers[i, j] != 0 && !visited.Contains(j)&& i!=j)
                {
                    queue.Enqueue(j);
                    visited.Add(j);
                }
            }
            if (queue.Count != 0)
            {
                bfs(queue.Dequeue(), computers);
            }
        }
}