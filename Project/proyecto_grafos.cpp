/*
	Recorrido en grafos dirigidos, mostrando su lista de adyacencia
	Menejo de estructuras y listas
*/

#include <iostream>
#include <list>
#include <conio.h>
using namespace std;

struct Nodo {
	int nombre;			//nombre del vertice o nodo
    struct Nodo *sgte;
    struct Arista *ady;	//puntero hacia la primera arista del nodo
};

struct Arista{
    struct Nodo *destino;	//puntero al nodo de llegada
    struct Arista *sgte;
};


class Grafo {
	private:
		//Definiendo estructuras que ocuparemos para la creacion del  grafo y su lista de adyacencia
		typedef struct Nodo *Tnodo;		//Tipo Nodo
		typedef struct Arista *Tarista; //Tipo Arista
		Tnodo p;//puntero cabeza
		int V; //Numero de vertices para nuestra lista de adyacencia
    	list<int> *adj; //arreglo de listas de adyacencia
    	bool *visitado; //matriz de visitados.
	public:
		//Definicion de funciones de la clase Grafo
		Grafo(int); //Constructor
		void menu(); //menu de opciones
		void insertar_nodo();
		void agrega_arista(Tnodo &, Tnodo &, Tarista &);
		void insertar_arista();
		void vaciar_aristas(Tnodo &);
		void eliminar_nodo();
		void eliminar_arista();
		void mostrar_grafo();
		void mostrar_aristas();	
		void DFS(int);
		void iniciarVisitado(int);
};

int main(void)
{   
	int tam;
	cout<<"INGRESE TOTAL DE NODOS DEL GRAFO: ";
	cin >> tam;
	Grafo g(tam); //Creacion del objeto grafo
    int op; // opcion del menu
	int src;	 //Para el nodo de inicio del recorrido
    do
    {
        g.menu();
        cin>>op;

        switch(op)
        {
            case 1:
                    g.insertar_nodo();
                    break;
            case 2: g.insertar_arista();
                    break;
            case 3: g.eliminar_nodo();
                    break;
            case 4: g.eliminar_arista();
                    break;
            case 5: g.mostrar_grafo();
                    break;
            case 6: g.mostrar_aristas();
                    break;
        	case 7: 
        			cout << "INGRESE NODO DESDE EL QUE DESEA INICIAR EL RECORRIDO: "; cin >> src;
        			g.DFS(src);
        			g.iniciarVisitado(tam+1);
					break;
			case 0:
					cout <<"-----PROGRAMA TERMINADO-----" << endl;
					break;
            default: cout<<"OPCION NO VALIDA!!! INGRESE DE NUEVO";
                     break;


        }
        cout<<endl<<endl;
        system("pause");  system("cls");

    }while(op!=0);
    return 0;
}

//Constructor con parametro, para inicializar nuestra lista y guardar el espacio en memoria que ocupara el grafo
Grafo::Grafo(int v)
{
	V = v+1; //Espacio reservado
    adj = new list<int>[V];
    visitado = new bool[V];
    for(int i=0;i<V;i++) visitado[i] = false;
	p = NULL;
}

void Grafo::menu() //Menu del prorama
{
    cout<<"\n\tREPRESENTACION DE GRAFOS DIRIGIDOS\n\n";
    cout<<" 1. INSERTAR UN NODO                 "<<endl;
    cout<<" 2. INSERTAR UNA ARISTA              "<<endl;
    cout<<" 3. ELIMINAR UN NODO                 "<<endl;
    cout<<" 4. ELIMINAR UNA ARISTA              "<<endl;
    cout<<" 5. MOSTRAR EL GRAFO                 "<<endl;
    cout<<" 6. MOSTRAR ARISTAS DE UN GRAFO       "<<endl;
    cout<<" 7. MOSTRAR RECORRIDO DESDE UN NODO INICIAL (DFS)  "<<endl;
    cout<<" 0. SALIR                            "<<endl;

    cout<<"\n INGRESE UNA OPCION: ";
}

void Grafo::insertar_nodo() //insercion de nodos en la estructura
{
	Tnodo t,nuevo = new struct Nodo;
    cout<<"INGRESE NODO: ";
    cin>>nuevo->nombre;
    nuevo->sgte = NULL;
    nuevo->ady=NULL;

    if(p==NULL)
    {
        p = nuevo;
        cout<<"PRIMER NODO...!!!";
    }
    else
    {
        t = p;
        while(t->sgte!=NULL)
        {
            t = t->sgte;
        }
        t->sgte = nuevo;
        cout<<"NODO INGRESADO...!!!";
	}
}

void Grafo::agrega_arista(Tnodo &aux, Tnodo &aux2, Tarista &nuevo) //Funcion para agregar aristas o conexiones entre nodos
{
    Tarista q;
    if(aux->ady==NULL)
    {   aux->ady=nuevo;
        nuevo->destino=aux2;
        cout<<"PRIMERA ARISTA....!";
    }
    
    else
    {   q=aux->ady;
        while(q->sgte!=NULL)
            q=q->sgte;
        nuevo->destino=aux2;
        q->sgte=nuevo;
        cout<<"ARISTA AGREGADA...!!!!";
    }

}

/* funcion que busca las posiciones de memoria de los nodos y hace llamado a agregar_arista para insertar la arista */
void Grafo::insertar_arista()
{   int ini, fin;
    Tarista nuevo=new struct Arista;
    Tnodo aux, aux2;

    if(p==NULL)
     {
         cout<<"GRAFO VACIO...!!!!";
         return;
     }
    nuevo->sgte=NULL;
    cout<<"INGRESE NODO INICIAL: ";
    cin>>ini;
    cout<<"INGRESE NODO FINAL: ";
    cin>>fin;
    adj[ini].push_back(fin); //aqui se insertan los valores en la pila o lista
    aux=p;
    aux2=p;
    while(aux2!=NULL)
    {
        if(aux2->nombre==fin)
        {
            break;
        }

        aux2=aux2->sgte;
    }
    while(aux!=NULL)
    {
        if(aux->nombre==ini)
        {
            agrega_arista(aux,aux2, nuevo);
            return;
        }

        aux = aux->sgte;
    }
}

//Esta funcion es utilizada al borrar un nodo pues si tiene aristas es nesesario borrarlas tambien y dejar libre la memoria
void Grafo::vaciar_aristas(Tnodo &aux)
{
    Tarista q,r;
    q=aux->ady;
    while(q->sgte!=NULL)
    {
        r=q;
        q=q->sgte;
        delete(r);
    }
}

//funcion utilizada para eliminar un nodo del grafo pero para eso tambien tiene que eliminar sus aristas por lo cual
//llama a la funcion vaciar_aristas para borrarlas
void Grafo::eliminar_nodo()
{   int var;
    Tnodo aux,ant;
    aux=p;
    cout<<"ELIMINAR UN NODO\n";
    if(p==NULL)
     {
         cout<<"GRAFO VACIO...!!!!";
         return;
     }
    cout<< "INGRESE NODO A BORRAR: ";
    cin>>var;

    while(aux!=NULL)
    {
        if(aux->nombre==var)
        {
            if(aux->ady!=NULL)
                vaciar_aristas(aux);

            if(aux==p)
            {

                    p=p->sgte;
                    delete(aux);
                    cout<<"NODO ELIMINADO...!!!!";
                    return;



            }
            else
            {
                ant->sgte = aux->sgte;
                delete(aux);
                cout<<"NODO ELIMINADO...!!!!";
                return;
            }
        }
        else
        {
            ant=aux;
            aux=aux->sgte;
         }
    }

}

//funcion utilizada para eliminar una arista
void Grafo::eliminar_arista()
{
	int ini, fin;
    Tnodo aux, aux2;
    Tarista q,r;
    cout<<"\n ELIMINAR ARISTA\n";
    cout<<"INGRESE NODO INICIAL: ";
    cin>>ini;
    cout<<"INGRESE NODO FINAL: ";
    cin>>fin;
    adj[ini].pop_back(); //aqui se eliminan los valores en la pila o lista
    aux=p;
    aux2=p;
    while(aux2!=NULL)
    {
        if(aux2->nombre==fin)
        {
            break;
        }
        else
        aux2=aux2->sgte;
    }
     while(aux!=NULL)
    {
        if(aux->nombre==ini)
        {
            q=aux->ady;
            while(q!=NULL)
            {
                if(q->destino==aux2)
                {
                    if(q==aux->ady)
                        aux->ady=aux->ady->sgte;
                    else
                        r->sgte=q->sgte;
                    delete(q);
                    cout<<"ARISTA  "<<aux->nombre<<"----->"<<aux2->nombre<<" ELIMINADA.....!!!!";
                    return;
                }
            }
            r=q;
            q=q->sgte;
        }
        aux = aux->sgte;
    }
}

//funcion que imprime un grafo en su forma enlazada, lista de adyacencia
void Grafo::mostrar_grafo()
{   Tnodo ptr;
    Tarista ar;
    ptr=p;
    cout<<"NODO|LISTA DE ADYACENCIA\n";

    while(ptr!=NULL)
    {   cout<<"   "<<ptr->nombre<<"|";
        if(ptr->ady!=NULL)
        {
            ar=ptr->ady;
            while(ar!=NULL)
            {   cout<<" "<<ar->destino->nombre;
                ar=ar->sgte;
             }

        }
        ptr=ptr->sgte;
        cout<<endl;
    }
}

//funcion que muestra todas las aristas de un nodo seleccionado
void Grafo::mostrar_aristas()
{
    Tnodo aux;
    Tarista ar;
    int var;
    cout<<"MOSTRAR ARISTAS DE NODO\n";
    cout<<"INGRESE NODO: ";
    cin>>var;
    aux=p;
    while(aux!=NULL)
    {
        if(aux->nombre==var)
        {
            if(aux->ady==NULL)
            {   cout<<"EL NODO NO TIENE ARISTAS...!!!!";
                return;
             }
            else
            {
                cout<<"NODO|LISTA DE ADYACENCIA\n";
                cout<<"   "<<aux->nombre<<"|";
                ar=aux->ady;

                while(ar!=NULL)
                {
                    cout<<ar->destino->nombre<<" ";
                    ar=ar->sgte;
                }
                cout<<endl;
                return;
            }
        }
        else
        aux=aux->sgte;
    }
}

//Funcion para mostrar el recorrido desde un nodo inicial 
void Grafo::DFS(int v){
    visitado[v] = true; //marca el nodo actual como visitado e imprimelo
    cout << v << " ";

    list<int>::iterator it;
    for(it = adj[v].begin(); it!=adj[v].end();++it){ //nodos adyacentes
        if(!this->visitado[*it]){
            DFS(*it);
        }
    }
}

//Funcion para regresar la matriz de visitados a false y poder trabajar con la DFS sin tener problemas
void Grafo::iniciarVisitado(int V)
{
	//para volver todos los nodos en su estado false = no han sido visitados 
    for(int i=0;i<V;i++) visitado[i] = false;
}