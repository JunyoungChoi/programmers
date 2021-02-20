#include <string>
#include <vector>
#include <queue>
using namespace std;
priority_queue<string, vector<string>, greater<string>> pq;
vector<string> bus[11];
int strToint(string time) {
	int ret;
	string t1 = time.substr(0, 2);
	string t2 = time.substr(3, 2);
	ret = stoi(t1) * 60 + stoi(t2);
	return ret;
}
string intTostr(int time) {
	string ret;
	ret.resize(5);
	sprintf((char*)ret.c_str(), "%02d:%02d", time / 60, (time % 60));
	return ret;
}
string solution(int n, int t, int m, vector<string> timetable) {
	string answer = "";
	for (string time : timetable) {
		pq.push(time);
	}
	string startTime = "09:00";
	for (int i = 1; i <= n; i++) {
		string curTime = intTostr(strToint(startTime) + (i - 1) * t);
		if (pq.top() > curTime)
			continue;
		int nPassenger = 0;
		while (nPassenger < m && !pq.empty()) {
			string waitingTime = pq.top();
			if (waitingTime <= curTime) {
				pq.pop();
				nPassenger++;
				bus[i].push_back(waitingTime);
			}
			else
				break;
		}
	}

	if (bus[n].size() != m) {
		answer = intTostr(strToint(startTime) + (n - 1) * t);
	}
	else {
			answer = intTostr(strToint(bus[n].back()) - 1);
	}
	return answer;
}