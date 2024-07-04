#include <iostream>
using namespace std;

struct Nodo
{
	int dato;
	string Nombre;
	Nodo* Liga = NULL;
};

int main(){
	Nodo* Lista = new Nodo;
	Nodo* Lista1 = new Nodo;
	
	Lista->Liga = Lista1;
	
	cout << Lista << " " << &(*Lista).dato << " " << &(*Lista).Nombre;
	cout << " " << &(*Lista).Liga << endl;
	
	cout << "\n" << Lista << " Dato> " << (*Lista).dato << " Nombre> " << &(*Lista).Nombre;
	cout << " Direcion> " << (*Lista).Liga << endl;
	
	cout << endl;
	
	cout << Lista1 << " " << &(*Lista1).dato << " " << &(*Lista1).Liga << endl;
	cout << Lista1 << " " << (*Lista1).dato << " " << (*Lista1).Liga << endl;
	return 0;
}