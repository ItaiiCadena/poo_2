#include <iostream>
using namespace std;

int main()
{
	int a[] = {12, 13, 14, 15};
	
	/*for(int i=0; i<4; i++)
	{
		cout << a[i] << endl; //Valor que contiene en esa direccion
		cout << &a[i] << endl; //Dirección en memoria donde se almacena el valor
	}*/

	int *b = NULL;
	
	
	b = &a[3];
	cout << a[3] << endl;
	cout << b << endl;
	
	
	return 0;
}