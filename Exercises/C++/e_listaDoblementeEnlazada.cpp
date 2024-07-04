#include <iostream>
using namespace std;

struct Nodo 
{
	int dato;
	Nodo* ant = NULL;
	Nodo* sig = NULL;
};

class ListaDoble {
	private:
		Nodo* lista;
		Nodo* inicio;
		Nodo* final;
	public:
		ListaDoble();
		~ListaDoble();
		void insertar(int x);
		void buscar(int x);
		void eliminar(int x);
		void mostrar();
		void mostrarInverso();
};

ListaDoble::ListaDoble()
{
	lista = new Nodo;
	inicio = NULL;
	final = NULL;
}

ListaDoble::~ListaDoble()
{
	//cout << "Destruyendo memoria>>>"<<endl;
	delete lista;
}

void ListaDoble::mostrar()
{
	Nodo *actual = inicio;
	while(actual != NULL)
	{
		cout << actual->dato << "->";
		actual = actual->sig;
	}
	cout << endl;
}

void ListaDoble::mostrarInverso()
{
	Nodo *actual = final;
	while(actual != NULL)
	{
		cout << actual->dato << "->";
		actual = actual->ant;
	}
	cout << endl;
}

void ListaDoble::buscar(int x)
{
	bool encontrado = false;
	Nodo* actual = inicio;
	while(actual->sig != NULL && !encontrado)
	{
		if(actual->dato == x)
		{
			encontrado = true;
			break;
		}
		else
		{
			actual = actual->sig;
		}		
	}
	encontrado?
	cout << "Dato encontrado\n" << actual->dato << endl:cout << "No se encontraron coincidencias\n";
}

void ListaDoble::insertar(int x)
{
	Nodo* actual;
	Nodo* antActual;
	Nodo* nuevoNodo;
	bool encontrado;
	
	nuevoNodo = new Nodo;
	nuevoNodo->dato = x;
	nuevoNodo->sig = NULL;
	nuevoNodo->ant = NULL;
	
	if(inicio == NULL)
	{
		inicio = nuevoNodo;
		final = nuevoNodo;
	}
	else
	{
		encontrado = false;
		actual = inicio;
		while (actual != NULL && !encontrado)
		{
			if(actual->dato == x)
			{
				encontrado = true;
			}
			else
			{
				antActual = actual;
				actual = actual->sig;
			}
		}
		if(actual == inicio)
		{
			inicio->ant = nuevoNodo;
			nuevoNodo->sig = inicio;
			inicio = nuevoNodo;
		}
		else
		{
			if(actual != NULL)
			{
				antActual->sig = nuevoNodo;
				nuevoNodo->ant = antActual;
				nuevoNodo->sig = actual;
				actual->ant = nuevoNodo;
			}
			else
			{
				antActual->sig = nuevoNodo;
				nuevoNodo->ant = antActual;
				final = nuevoNodo;
			}
		}
	}
}

void ListaDoble::eliminar(int x)
{
	Nodo* actual;
	Nodo* antActual;
	bool encontrado;
	if(inicio == NULL)
	{
		cout << "No se pueden eliminar elementos, la lista esta vacia" << endl;
	}
	else if(inicio->dato == x)
	{
		actual = inicio;
		inicio = inicio->sig;
		if(inicio != NULL)
		{
			inicio->ant = NULL;
		}
		else
		{
			final = NULL;
		}
		delete actual;
	}
	else
	{
		encontrado = false;
		actual = inicio;
		while(actual != NULL && !encontrado)
		{
			if(actual->dato == x)
			{
				encontrado = true;
			}
			else 
			{
				actual = actual->sig;
			}
		}
		if(actual == NULL)
		{
			cout << "El numero que desea eliminar no se encuentra en la lista" << endl;
		}
		else if(actual->dato == x)
		{
			antActual = actual->ant;
			antActual->sig = actual->sig;
			if(actual->sig != NULL)
			{
				actual->sig->ant = antActual;
			}
			if(actual == final)
			{
				final = antActual;
			}
			delete actual;
		}
		else 
		{
			cout << "El numero que desea eliminar no se encuentra en la lista" << endl;
		}
	}
}

int main()
{
	ListaDoble lista;
	int busc, elim;
	lista.insertar(3);
	lista.insertar(6);
	lista.insertar(9);
	lista.insertar(12);
	lista.insertar(14);
	lista.insertar(16);
	lista.insertar(18);
	lista.mostrarInverso();
	cout << "Elemento a buscar" << endl;
	cin >> busc;
	lista.buscar(busc);
	cout <<"Elemento a eliminar" << endl;
	cin >> elim;
	lista.eliminar(elim);
	lista.mostrar();
	return 0;
}
