#include <iostream>
#define N 3
using namespace std;

int main()
{
	int a[N][N][N] = {{1,2,3},{11, 12, 13},{21, 22, 23}};
	a[2][2][2] = 2020;
	
	int *base = &a[0][0][0];
	
	for(int i = 0; i< N*N*N; i++)
	{
		cout << *(base) << endl;
	}
	return 0;
}