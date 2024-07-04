#include <iostream>

using namespace std;
int main()
{
	int a[3][3][3][3] =
	{

	{{{1,2,3},{11,21,31},{21,22,23}},{{101,102,3},{1011,1021,1031},{1021,1022,1023}},{{201,202,203},{2011,2021,2031},{2021,2022,2023}}	},

	{{{1,2,3},{11,21,31},{21,22,23}},{{101,102,3},{1011,1021,1031},{1021,1022,1023}},{{201,202,203},{2011,2021,2031},{2021,2022,2023}}	},

	{{{1,2,3},{11,21,31},{21,22,23}},{{101,102,3},{1011,1021,1031},{1021,1022,1023}},{{201,202,203},{2011,2021,2031},{2021,2022,2023}}	}

	};
	
	int *base = &a[0][0][0][0];

	for(int h=0; h < 3; h++)
	{
	cout << "Hiper plano " << h << endl;
	for(int i=0; i<3;i++)
	{
	cout << "Matriz " << i << endl;
		for(int j=0; j<3;j++)
		{
			for(int k=0; k<3;k++)
			{
				cout << a[h][i][j][k] << " ";
			}
			cout << endl;
		}
		cout << "\n\n" << endl;
	}
	}
	int h, mat, i1, i2;
	cout << "\nIngrese Hiperplano: " << endl;
	cin >> h;
	cout << "Ingrese matriz: " << endl;
	cin >> mat;
	cout << "Ingrese renglon: " << endl;
	cin >> i1;
	cout << "Ingrese columna: " << endl;
	cin >> i2;
	cout << "\nNumero en direccion: ";
	cout << *(base + h*3*3*3+mat*3*3 + i1 * 3 + i2) << endl;

	return 0;
}