#include <iostream>
#define N 5
#define M 3
using namespace std;

int main(){
	int a[M][N] = {
					{1, 2, 3, 4, 5},
					{11, 12, 13, 14, 15},
					{21, 22, 23, 24, 25},
	};
	int *base = &a[0][0];
	int dato[] = {31, 32, 33, 34};
	*(base+(M*N)) = *(&dato[0]);
	base = &a[0][0];

	for(int i = 0; i < (N*M)+5; i++)
	{
		cout << i<< ": " << *(base + i) << endl;
	}
	return 0;
}