def solution(heights):
    answer = []
    for i in range(len(heights)-1,-1,-1):
        for j in range(i-1,-1,-1):
            if heights[i] < heights[j]:
                answer.append(j+1)
                break
            elif j==0:
                answer.append(0)
                break
    answer.append(0)
    return list(reversed(answer))