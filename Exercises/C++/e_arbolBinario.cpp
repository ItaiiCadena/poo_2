#include <iostream>
using namespace std;

struct Nodo {
	int dato;
	Nodo* derecha = NULL;
	Nodo* izquierda = NULL;
};

void insertar(Nodo* &raiz, int x)
{
	if(raiz == NULL){
		raiz = new Nodo;
        raiz->dato = x;
        raiz->izquierda = NULL;
        raiz->derecha = NULL;
    }
    else if(x < raiz->dato)
	{
		insertar(raiz->izquierda, x);
    }
    else if(x > raiz->dato)
	{
		insertar(raiz->derecha, x);
    }
}

void preOrden(Nodo* raiz)
{
	if(raiz != NULL){
		cout << raiz->dato << " ";
        preOrden(raiz->izquierda);
        preOrden(raiz->derecha);
    }
}

void postOrden(Nodo* raiz)
{
	if(raiz != NULL)
	{
		postOrden(raiz->izquierda);
        postOrden(raiz->derecha);
        cout << raiz->dato << " ";
    }
}

void inOrden(Nodo* raiz)
{
    if(raiz != NULL)
	{
		inOrden(raiz->izquierda);
        cout << raiz->dato << " ";
        inOrden(raiz->derecha);
    }
}

void mostrarArbol(Nodo* raiz, int inicio)
{
    if(raiz == NULL) return;
    mostrarArbol(raiz->derecha, inicio+1);
    for(int i=0; i<inicio; i++)
	cout << " ";
    cout << raiz->dato << endl;
    
    mostrarArbol(raiz->izquierda, inicio+1);
}

int alturaArbol(Nodo* raiz)
{
    int izq, der;
    if(raiz == NULL)
        return -1;
    else
    {
        izq = alturaArbol(raiz->izquierda);
        der = alturaArbol(raiz->derecha);

        if(izq > der)
            return izq + 1;
        else
            return der + 1;
    }
}

int profundidadNodo(Nodo* raiz, int x) {
   int altura = 0; 
   while(raiz != NULL) {
      if(x == raiz->dato) return altura; 
      else {
         altura++; 
         if(x < raiz->dato) raiz = raiz->izquierda; 
         else if(x > raiz->dato) raiz = raiz->derecha;
      }
   }
   return -1; 
}

int main(){
	Nodo* raiz = NULL;
 	insertar(raiz, 5);
 	insertar(raiz, 3);
 	insertar(raiz, 8);
 	insertar(raiz, 2);
 	insertar(raiz, 4);
 	insertar(raiz, 6);
 	insertar(raiz, 9);
 	insertar(raiz, 1);
 	insertar(raiz, 7);
 	insertar(raiz, 10);
 	cout << "Mostrando arbol ejemplo, contiene los numeros 5 3 8 2 4 6 9 1 7 10" << endl;
 	mostrarArbol(raiz,0);
 	cout << "\nPreOrden: "; preOrden(raiz);
 	cout << "\nInOrden: "; inOrden(raiz);
    cout << "\nPostOrden: "; postOrden(raiz);
    int altu = alturaArbol(raiz);
	cout << "\nAltura del arbol: "<< altu + 1 <<endl;
	int nume = 0;
	cout<<"\nIngrese numero de nodo que desea saber su profundidad: ";cin>>nume;
	int altuNod = profundidadNodo(raiz,nume);
	cout << "\nLa profunididad del nodo " << nume << " es: " << altuNod + 1 << endl;
	
	////Segundo ejemplo
	Nodo* arbol = NULL;
	int n,x,altura,profundidad,num;
	cout << "Ejemplo con datos ingresados por el usuario" << endl;
    cout << "Ingresa numero de nodos para el arbol: ";
    cin >> n;
    for(int i=0; i<n; i++)
	{
		cout << "Ingrese nodo numero " << i << ": ";
        cin >> x;
        insertar(arbol, x);
    }
    
    mostrarArbol(arbol,0);
    cout << "\nPreOrden: "; preOrden(arbol);
    cout << "\nPostOrden: "; postOrden(arbol);
    cout <<"\InOrden: "; inOrden(arbol);
    altura = alturaArbol(arbol);
	cout << "\nAltura del arbol: " << altura << endl;
	cout << "Ingrese numero de nodo que desea saber su profundidad: "; cin >> num;
	profundidad = profundidadNodo(arbol, num);
	cout << "\nAltura del nodo " << num << " es: " << profundidad << endl;
	
	return 0;
}