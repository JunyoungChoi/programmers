using System;

public class Solution {
    public int[] solution(int[] prices)
        {
            int[] answer = new int[prices.Length];
            for (int i = prices.Length - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    answer[i]++;
                    if (prices[i] > prices[j])
                        break;
                }
            }
            return answer;
        }
}