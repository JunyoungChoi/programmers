using System;

public class Solution {
    public int solution(int[] numbers, int target)
        {
            int answer = 0;
            p(ref answer, 0, numbers, numbers[numbers.Length-1], numbers.Length - 1, target);
            p(ref answer, 0, numbers, -numbers[numbers.Length-1], numbers.Length - 1, target);

            return answer;
        }
        public void p(ref int answer, int sum, int[] numbers, int num,int cnt, int target)
        {
            if (cnt == 0)
            {
                if (sum + num == target)
                {
                    answer++;
                }
                return;
            } 
            p(ref answer, sum + num, numbers, numbers[cnt - 1], cnt - 1, target);
            p(ref answer, sum + num, numbers, -numbers[cnt-1], cnt - 1, target);
        }
}