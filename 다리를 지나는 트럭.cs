using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            int answer = 0;
            Queue<int> truckQueue = new Queue<int>(truck_weights);
            Queue<int> bridgeQueue = new Queue<int>(new int[bridge_length]);
            int truckWeightsSum = 0;
            while (truckQueue.Count()>0)
            {
                if (truckWeightsSum - bridgeQueue.Peek() + truckQueue.Peek() > weight)
                {
                    bridgeQueue.Enqueue(0);
                    
                }
                else
                {
                    truckWeightsSum += truckQueue.Peek();
                    bridgeQueue.Enqueue(truckQueue.Dequeue());
                }
                truckWeightsSum -= bridgeQueue.Peek();
                bridgeQueue.Dequeue();
                answer++;
            }
            return answer + bridge_length;
        }
        
}