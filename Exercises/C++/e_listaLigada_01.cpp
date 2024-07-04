#include <iostream>
using namespace std;

struct Nodo
{
	int dato;
	string Nombre;
	Nodo* Liga = NULL;
};

int main()
{
	Nodo* a = new Nodo;
	Nodo* b = new Nodo;
	Nodo* c = new Nodo;
	Nodo* d = new Nodo;
	Nodo* e = new Nodo;
	Nodo* f = new Nodo;
	
	a->dato = 10; a->Nombre = "AAA"; a->Liga = b;
	b->dato = 20; b->Nombre = "BBB"; b->Liga = c;
	c->dato = 30; c->Nombre = "CCC"; c->Liga = d;
	d->dato = 40; d->Nombre = "DDD"; d->Liga = e;
	e->dato = 50; e->Nombre = "EEE"; e->Liga = f;
	f->dato = 60; f->Nombre = "FFF"; //f->Liga = NULL;
	
	while(a != NULL)
	{
		cout << a->dato << " " << (*a).Nombre << "->";
		a = a->Liga;
	}
	
	return 0;
}