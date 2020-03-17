using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    Stack<Tuple<string, int>> ansList = new Stack<Tuple<string, int>>();    // 목적지, 깊이
        Stack<Tuple<string, string, int,int>> stack = new Stack<Tuple<string, string, int,int>>();  // bfs
        List<int> visited = new List<int>();
        List<string[]> toSort = new List<string[]>();
        public string[] solution(string[,] tickets)
        {
            string[] answer = new string[] { };
            for (int i = 0; i < tickets.Length / 2; i++)
            {
                if (tickets[i, 0].Equals("ICN"))
                {
                    stack.Push(new Tuple<string, string, int,int>(tickets[i, 0], tickets[i, 1], 1,i));
                }
            }
            ansList.Push(new Tuple<string, int>("ICN", 0));
            while (stack.Count > 0)
            {
                Tuple<string, string, int,int> t = stack.Pop();
                visited.Add(t.Item4);
                ansList.Push(new Tuple<string, int>(t.Item2, t.Item3));
                int cnt = 0;
                for (int i = 0; i < tickets.Length / 2; i++)
                {
                    if (!visited.Contains(i) && tickets[i, 0].Equals(t.Item2))
                    {
                        stack.Push(new Tuple<string, string, int,int>(tickets[i, 0], tickets[i, 1], t.Item3 + 1,i));
                        cnt++;
                    }
                }
                if (cnt == 0)
                {
                    if (t.Item3 == tickets.GetLength(0))
                    {
                        List<Tuple<string, int>> ttttt = ansList.ToList();
                        string[] ansStr = new string[tickets.Length / 2 + 1];
                        for (int i = 0; i < ttttt.Count; i++)
                        {
                            ansStr[i] = ttttt[ttttt.Count - i - 1].Item1;
                        }
                        toSort.Add(ansStr);
                    }
                    try
                    {
                        int tem = stack.Peek().Item3;
                        while (tem <= ansList.Peek().Item2)
                        {
                            ansList.Pop();
                        }
                        visited.RemoveRange(tem - 1, visited.Count - tem + 1);
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < toSort.Count - 1; i++)
            {
                for (int j = i + 1; j < toSort.Count; j++)
                {
                    for (int k = 0; k < tickets.Length / 2 + 1; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (toSort[i][k][l] < toSort[j][k][l])
                            {
                                toSort[j] = null;
                                k = tickets.Length;
                                break;
                            }
                            else if (toSort[i][k][l] > toSort[j][k][l])
                            {
                                toSort[i] = null;
                                k = tickets.Length;
                                i = j;
                                k = tickets.Length;
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < toSort.Count; i++)
            {
                if (toSort[i] != null)
                {
                    answer = toSort[i].ToArray();
                }
            }
            return answer;
        
        }
}