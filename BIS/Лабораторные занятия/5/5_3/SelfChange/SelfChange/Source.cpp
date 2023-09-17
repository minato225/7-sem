#include <iostream>
using namespace std;

extern "C" int ChangeOp(int i);

int main() {
	cout << "Result:" << ChangeOp(100) << endl;
	return 0;
}