#include <iostream>
using namespace std;

//Definicion del nodo
struct Nodo 
{
	int dato; ///datos dentro del nodo
	Nodo* ant = NULL; //nodos que enlazan a los otras nodos, en este caso a un nodo anterior
	Nodo* sig = NULL; //en este caso a un nodo siguiente
};

//Definicion de la clase
class ListaDoble {
	private:
		Nodo* inicio = new Nodo; //nodo que guarda el inicio de la lista
		Nodo* final = new Nodo; //nodo que guarda el final de la lista
	public:
		ListaDoble(); //constructor
		~ListaDoble(); //destructor
		void mostrar(); //funcion para mostrar la lista
		void mostrarInverso(); //funcion para mostrar la lista en inverso
		bool buscar(int x); //funcion para buscar un elemento en la lista
		void insertarPrincipio(int x); //funcion para insertar al principio
		//void insertarFinal(int x); //funcion para insertar al final
		//void eliminar(int x); //funcion para eliminar nodos
};

//implementacion del constructor
ListaDoble::ListaDoble()
{
	//ambos nodos se incializan nulos
	inicio = NULL;
	final = NULL;
}

//destructor, elimina ambos nodos
ListaDoble::~ListaDoble()
{
	cout << "Destruyendo memoria>>>"<<endl;
	delete inicio;
	delete final;
}

//Funcion que imprime en pantalla los elementos contenidos en los nodos
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

//Funcion que imprime en pantalla los elementos contenidos en los nodos de manera inversa
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

//Funcion para buscar un elemento en la lista 
bool ListaDoble::buscar(int x)
{
	bool encontrado = false;
	Nodo* actual = inicio;
	while(actual->sig != NULL && !encontrado)
	{
		if(actual->dato == x)
		{
			encontrado = true; //retorna true si el elemento se escuentra en la lista
			break;
		}
		else
		{
			actual = actual->sig;
		}		
	}
	//De lo contrario, si el elemento no esta en la lista retorna false
	return encontrado;
}

void ListaDoble::insertarPrincipio(int x)
{
	Nodo* actual; ///Nodo para movernos en la lista
	Nodo* antActual; ///Nodo antes de actual
	Nodo* nuevoNodo; //Nuevo nodo vacio
	bool encontrado;
	
	nuevoNodo = new Nodo; //creamos el nodo
	nuevoNodo->dato = x; ///agregamos el dato a insertar en este nuevo nodo
	nuevoNodo->sig = NULL; 
	nuevoNodo->ant = NULL;
	
	if(inicio == NULL) //Si la lista esta vacia, nuevoNodo es el unico nodo en la lista
	{
		inicio = nuevoNodo;
		final = nuevoNodo;
	}
	else
	{
		encontrado = false;
		actual = inicio;
		while (actual != NULL && !encontrado) //buscando en la lista
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
		if(actual == inicio) //inserta nuevo nodo antes del inicio
		{
			inicio->ant = nuevoNodo;
			nuevoNodo->sig = inicio;
			inicio = nuevoNodo;
		}
	}
}

int main()
{
	ListaDoble lista;
	lista.insertarPrincipio(2);
	lista.insertarPrincipio(4);
	lista.insertarPrincipio(5);
	lista.insertarPrincipio(8);
	lista.mostrar();
	return 0;
}