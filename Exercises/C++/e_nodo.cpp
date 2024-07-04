#include <iostream>
using namespace std;

struct Nodo
{
	int Dato;
	Nodo* link = NULL;
};

void mostrarLista(Nodo* a)
{
	int i = 0;
	cout << "============" << endl;
	cout << "|   Lista   |" << endl;
	cout << "============" << endl;
	while((*a).link != NULL){
		cout << (*a).Dato << "->";
		a = (*a).link;
		i++; if(i > 50){
			break;
		}
	}
	cout << endl;
}

void insertar(Nodo *&a) //Cola o fist in first out
{
	cout << "Introducir dato: ";
	cin >> (*a).Dato;
	(*a).link = new Nodo;
	a = (*a).link;
}

int main(){
	Nodo* a = new Nodo;
	Nodo* direccion = a;
	Nodo* ultimo;
	/*
	Nodo* a = new Nodo; 
	(*a).Dato = 17; 
	
	Nodo* b = new Nodo; 
	(*b).Dato = 92;
	
	Nodo* c = new Nodo; 
	(*c).Dato = 63;
	
	Nodo* d = new Nodo; 
	(*d).Dato = 45;
	
	(*a).link = b;
	(*b).link = c;
	(*c).link = d;
	
	while(a != NULL)
	{
		cout << (*a).Dato << endl;
		a = (*a).link;
	}
	mostrarLista(a);
	cout << endl;
	mostrarLista(b);
	cout << endl;
	mostrarLista(a);
	
	char respuesta;
	cout << "Introducir dato s/n: ";
	cin >> respuesta;
	while(respuesta == 's')
	{
		cout << "Introducir dato: ";
		cin >> (*a).Dato;
		(*a).link = new Nodo;
		a = (*a).link;
		cout << "Introducir dato s/n: ";
		cin >> respuesta;
	}*/
	
	insertar(a);
	insertar(a);
	insertar(a);
	insertar(a);
	insertar(a);
	insertar(a);
	insertar(a);
	
	mostrarLista(direccion);
	
	insertar(a);
	insertar(a);
	
	a->link = direccion;
	
	mostrarLista(direccion);
	return 0;
}
