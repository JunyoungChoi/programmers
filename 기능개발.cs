using System;
using System.Linq;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] progresses, int[] speeds)
        {
            int index = 0;
            int cnt;
            int day = 1;
            List<int> sells = new List<int>();
            int[] completedDay = new int[progresses.Count()];
            while (true)
            {
                cnt = 0;
                for (int i = index; i < progresses.Count(); i++)
                {
                    progresses[i] += speeds[i];
                    if (progresses[i] >= 100)
                    {
                        completedDay[i] = day;
                    }
                }
                day++;
                for (int i = index; i < progresses.Count(); i++)
                {
                    if (completedDay[i] == 0)
                    {
                        index = i;
                        if (cnt != 0)
                        {
                            sells.Add(cnt);
                        }
                        break;
                    }
                    cnt++;
                }
                for (int i = 0; i < progresses.Count(); i++)
                {
                    if (progresses[i] < 100)
                        break;
                    else if (i == progresses.Count() - 1)
                    {
                        sells.Add(progresses.Count() - sells.Sum());
                        return sells.ToArray();
                    }
                }
            }
}
}