using System;

public class Solution {
   public int solution(string arrangement)
        {
            int answer = 0;
            int line = 0;
            int cnt = 0;
            //Queue<char> queue = new Queue<char>(arrangement);
            for(int i=0;i<arrangement.Length-1;i++)
            {
                if (arrangement[i] == '(' && arrangement[i+1] ==')')
                {
                    i++;
                    answer+=line;
                }
                else if (arrangement[i] == '(')
                {
                    line++;
                    cnt++;
                }
                else if (arrangement[i] == ')')
                {
                    line--;
                }

            }
            return cnt+answer;
        }
}