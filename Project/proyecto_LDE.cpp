#include <iostream>
using namespace std;

//Definicion del nodo
struct Nodo 
{
	int dato; ///datos dentro del nodo
	Nodo* ant = NULL; //nodos que enlazan a los otras nodos, en este caso a un nodo anterior
	Nodo* sig = NULL; //en este caso a un nodo siguiente
};

class ListaDoble {
	private:
		Nodo* inicio = new Nodo; //nodo que guarda el inicio de la lista
		Nodo* final = new Nodo; //nodo que guarda el final de la lista
		int cont;
	public:
		ListaDoble(); //constructor
		~ListaDoble(); //destructor
		void insertar(int x); //funcion para insertar
		void buscar(int x); //funcion para buscar un elemento en la lista
		void eliminar(int x); //funcion para eliminar nodos
		void mostrar(); //funcion para mostrar la lista
		void mostrarInverso(); //funcion para mostrar la lista en inverso
		int length(); //Funcion para conocer el tamanio de la lista
		int primero(); //funcion para retornar el primer elemento en la lista
		int ultimo();//funcion para retornar el ultimo elemento de la lista
		
};

//implementacion del constructor
ListaDoble::ListaDoble()
{
	//ambos nodos se incializan nulos
	inicio = NULL;
	final = NULL;
	cont = 0;
}

//destructor, elimina ambos nodos
ListaDoble::~ListaDoble()
{
	cout << "Destruyendo memoria>>>"<<endl;
	delete inicio;
	delete final;
}

//Funcion que retorna el tamanio de la lista
int ListaDoble::length()
{
	return cont;
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
void ListaDoble::buscar(int x)
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
	encontrado?
	cout << "Dato encontrado\n" << actual->dato << endl:cout << "No se encontraron coincidencias\n";
}

//Funcion para retornar el primer elemento de la lista
int ListaDoble::primero()
{
	return inicio->dato;
}

//funcion para retornar el ultimo elemento de la lista
int ListaDoble::ultimo()
{
	return final->dato;
}

//funcion para insertar elementos en la lista
void ListaDoble::insertar(int x)
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
		cont++;
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
			cont++;
		}
		else
		{
			//inserta nuevoNodo entre antActual y actual
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
			cont++;
		}
	}
}

void ListaDoble::eliminar(int x)
{
	Nodo* actual; //nodo para recorrer la lista
	Nodo* antActual; //nodo antes de actual
	bool encontrado;
	if(inicio == NULL) //Si la lista esta vacia envia el siguiente mensaje
	{
		cout << "No se pueden eliminar elementos, la lista esta vacia" << endl;
	}
	else if(inicio->dato == x) //Si es nodo que se quiere eliminar es el primero en la lista
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
		cont--;
		delete actual;
	}
	else
	{
		encontrado = false;
		actual = inicio;
		while(actual != NULL && !encontrado) //buscando en la lista
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
		else if(actual->dato == x) //checando igualdad
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
			cont--;
			delete actual;
		}
		else //Si el elemento que desea eliminar no esta en la lista, manda el siguiente mensaje
		{
			cout << "El numero que desea eliminar no se encuentra en la lista" << endl;
		}
	}
}

int main()
{
	ListaDoble lista;
	int busc, ins, elim, opcion, tam, prim, ult;
	char respuesta;
	cout << "|||| PROGRAMA QUE TRABAJA CON LISTAS DOBLEMENTE LIGADAS ||||\n";
	do { //Para acceder a todas las funciones del programa
		cout << "Elija una opcion" << endl;
		cout << "1: Insertar elementos en la lista" << endl;
		cout << "2: Eliminar elementos de la lista" << endl;
		cout << "3: Buscar elementos en la lista" << endl;
		cout << "4: Mostrar la lista" << endl;
		cout << "5: Mostrar la lista en inverso" << endl;
		cout << "6: Cual es el primer elemento?" << endl;
		cout << "7: Cual es el ultimo elemento?" << endl;
		cout << "8: Tamanio de la lista" << endl;
		cout << "0: Salir" << endl;
		cin >> opcion;
		switch(opcion)
		{
			case 1:
				cout << "\nPara dejar de insertar elementos presiones 'n'" << endl;
				do //Por si el usuario desea ingresar mas de un solo dato
				{
					cout << "Ingrese elemento: ";
					cin >> ins;
					lista.insertar(ins);
					cout << "Desea insertar otro elemento s/n ";
					cin >> respuesta;
				} while(respuesta != 'n');
				cout << endl;
			break;
			case 2:
				cout << endl;
				do //por si el usuario desea eliminar mas de un solo dato
				{
					cout << "Ingrese elemento a eliminar: ";
					cin >> elim;
					lista.eliminar(elim);
					cout << "Desea eliminar otro elemento s/n ";
					cin >> respuesta;
				} while(respuesta != 'n');
				cout << endl;
			break;
			case 3:
				cout << endl;
				do //Por si el usuario desea buscar mas de un solo dato
				{
					cout << "Ingrese elemento a buscar: ";
					cin >> busc;
					lista.buscar(busc);
					cout << "Desea buscar otro elemento s/n ";
					cin >> respuesta;
				} while(respuesta != 'n');
				cout << endl;
			break;
			case 4: //Muestra la lista normal
				cout << "\n<<<<< Mostrando lista >>>>>" << endl;
				lista.mostrar();
				cout << endl;
			break;
			case 5: //Muestra la lista en inverso
				cout << "\n<<<<< Mostrando lista en su inverso >>>>>" <<endl;
				lista.mostrarInverso();
				cout << endl;
			break;
			case 6: //Muestra el primer elemento de la lista
				cout << "\nEl primer elemento de la lista es: ";
				prim = lista.primero();
				cout << prim << endl<< endl;
			break;
			case 7: //Muestra el ultimo elemento de la lista
				cout << "\nEl ultimo elemento de la lista es: ";
				ult = lista.ultimo();
				cout << ult << endl << endl;
			break;
			case 8: //Muestra el tamanio de la lista
				cout << "\nEl tamanio de la lista es de ";
				tam = lista.length();
				cout << tam << " nodos" << endl << endl << endl;
			break;
			case 0:
				cout << "\n||| PROGRAMA TERMINADO |||" << endl;
			break;
			default:
                cout << "\nValor no valido, ingrese nuevamente" << endl;
        	break;
		}
	} while(opcion != 0);
	return 0;
}