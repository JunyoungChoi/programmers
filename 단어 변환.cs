using System;
using System.Collections.Generic;
public class Solution {
    List<int> visited = new List<int>();
        public int solution(string begin, string target, string[] words)
        {
            int[] ans = new int[words.Length+1];
            int destination = 0;
            int[,] graph = new int[words.Length + 1, words.Length + 1];
            for (int i = 1; i < words.Length+1; i++)
            {
                for (int j =  1; j < words.Length+1; j++)
                {
                    int cnt = 0;
                    for (int k = 0; k < begin.Length; k++)
                    {
                        if (words[i-1][k] != words[j-1][k])
                        {
                            cnt++;
                        }
                    }
                    graph[i, j] = cnt;
                }
                if (words[i-1].Equals(target))
                    destination = i;
            }
            for (int i = 0; i < words.Length; i++)
            {
                int cnt = 0;
                for (int j = 0; j < begin.Length; j++)
                {
                    if (words[i][j] != begin[j])
                    {
                        cnt++;
                    }
                }
                graph[0, i + 1] = cnt;
                graph[i + 1, 0] = cnt;
            }
            for (int a=0;a<graph.GetLength(0);a++){
                for(int b=0;b<graph.GetLength(1);b++){
                    Console.Write(graph[a,b]);
                }
                Console.WriteLine();
            }
            visited.Add(0);
            queue.Enqueue(0);
            bfs(destination, graph, ans);
            foreach (int a in ans)
            {
                Console.WriteLine(a);
            }
            return destination==0?0:ans[destination];
        }
        Queue<int> queue = new Queue<int>();
        public void bfs(int end,int[,] graph, int[] ans)
        {
            while (queue.Count != 0)
            {
                int t = queue.Dequeue();
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (!visited.Contains(i)&&graph[t,i]==1)
                    {
                        if (i == end)
                        {
                            ans[i] = ans[t] + 1;
                            return;
                        }
                        visited.Add(i);
                        queue.Enqueue(i);
                        ans[i] = ans[t]+ 1;
                        Console.WriteLine("{0} -> {1}\t{2}", t, i, ans[i]);
                    }
                }
            }
        }
}