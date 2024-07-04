#include <iostream>
#include <windows.h>
using namespace std;

int main(){
	int matriz[3][3][3][3] = { ///Matriz por default
	{{{1,2,3},{11,21,31},{21,22,23}},{{101,102,3},{1011,1021,1031},{1021,1022,1023}},{{201,202,203},{2011,2021,2031},{2021,2022,2023}}},
	{{{1,2,3},{11,21,31},{21,22,23}},{{101,102,3},{1011,1021,1031},{1021,1022,1023}},{{201,202,203},{2011,2021,2031},{2021,2022,2023}}},
	{{{1,2,3},{11,21,31},{21,22,23}},{{101,102,3},{1011,1021,1031},{1021,1022,1023}},{{201,202,203},{2011,2021,2031},{2021,2022,2023}}}
	};
	
	int opcion, opc, opci, h, m, f, c, H, M, F, C, contador; //Variables que se utilizaran en el do-while y switch
	int *base, *base2; //Para el polinomio de direccionamiento
	int mat[0][0][0][0]; //nueva matriz
	do{
		cout << "1: Utilizar matriz por default (Datos tomados de la clase)" << endl;
		cout << "2: Crear una nueva matriz" << endl;
		cout << "0: Salir" << endl;
		cout << "Elija una opcion" << endl;
		cin >> opcion;
		system("cls");
		switch(opcion){
			case 1:
				system("cls");
				do{
					cout << "1: Polimonio de direccionamiento" << endl;
					cout << "2: Mostrar matriz" << endl;
					cout << "0: regresar" << endl;
					cin>> opc;
					system("cls");
					switch(opc){
						case 1: //Para buscar un dto en la matriz mediante direccionamiento
							system("cls");
							cout << "\nIngrese los siguientes datos" << endl;
							cout << "Hiperplano: ";
							cin >> h;
							cout << "Matriz: ";
							cin >> m;
							cout << "Fila: ";
							cin >> f;
							cout << "Columna: ";
							cin >> c;
							base = &matriz[0][0][0][0];
							cout << "Numero en direccionamiento: ";
							cout << *(base + h*3*3*3+m*3*3 + f * 3 + c) << endl;
							system("pause");
						break;
						case 2: //Para imprimir la matriz por default
							system("cls");
							for(int h=0; h < 3; h++)
							{
								cout << "Hiperplano " << h << endl;
								for(int i=0; i<3;i++)
								{
									cout << "Matriz " << i << endl;
									for(int j=0; j<3;j++)
									{
										for(int k=0; k<3;k++)
										{
											cout << matriz[h][i][j][k] << " ";
										}
											cout << endl;
									}
									cout << "\n" << endl;
								}
							}
							system("pause");
						break;
					} 
				}while(opc != 0);	
				system("pause");
			break;
			case 2: //Para crear un matriz desde cero
				system("cls");
				do{
					cout << "1: Ingresar diminsiones de la matriz" << endl;
					cout << "2: Llenar la matriz desde 1 a N" << endl;
					cout << "3: Ingresar los datos de la matriz manualmente" << endl;
					cout << "4: Polinomio de direccionamiento" << endl;
					cout << "5: Mostrar matriz" << endl;
					cout << "0: regresar" << endl;
					cin >> opci;
					system("cls");
					switch(opci){
						case 1:
							system("cls");
							cout << "Numero de hiperplanos: ";
							cin >> h;
							cout << "Numero de matrices: ";
							cin >> m;
							cout << "Numero de filas por matriz: ";
							cin >> f; 
							cout << "Numero de columnas por matriz: ";
							cin >> c;
							mat[h][m][f][c];
							system("pause");
						break;
						case 2:
							system("cls");
							contador = 0;
							for(int w=0; w < h; w++)
							{
								for(int i=0; i<m;i++)
								{
									for(int j=0; j<f;j++)
									{
										for(int k=0; k<c;k++)
										{
											mat[w][i][j][k] = contador++;
										}
									}
								}
							}
							system("pause");
						break;
						case 3:
							system("cls");
							for(int w=0; w < h; w++)
							{
								for(int i=0; i<m;i++)
								{
									for(int j=0; j<f;j++)
									{
										for(int k=0; k<c;k++)
										{
											cout << "Ingrese dato: ";
											cin >> mat[w][i][j][k];
										}
									}
								}
							}
							system("pause");
						break;
						case 4:
							system("cls");
							cout << "\nIngrese los siguientes datos" << endl;
							cout << "Hiperplano: ";
							cin >> H;
							cout << "Matriz: ";
							cin >> M;
							cout << "Fila: ";
							cin >> F;
							cout << "Columna: ";
							cin >> C;
							base2 = &mat[0][0][0][0];
							cout << "Numero en direccionamiento: ";
							cout << *(base + H*m*f*c+M*f*c + F * m + C) << endl;
							system("pause");	
						break;
						case 5:
							system("cls");
							for(int w=0; w < h; w++)
							{
								cout << "Hiperplano " << w << endl;
								for(int i=0; i<m; i++)
								{
									cout << "Matriz " << i << endl;
									for(int j=0; j<f;j++)
									{
										for(int k=0; k<c;k++)
										{
											cout << mat[w][i][j][k] << " ";
										}
											cout << endl;
									}
									cout << "\n" << endl;
								}
							}
							system("pause");
						break;
					}
				}while(opci != 0);
				system("pause");
			break;
			case 0:
				system("cls");
				cout << "---Programa terminado---" << endl;
				system("pause");
			break;
		}	
	}while(opcion != 0);
	
	return 0;
}