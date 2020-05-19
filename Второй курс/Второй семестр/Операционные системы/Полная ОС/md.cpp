//создание каталога
#include <cstdlib> 
#include <iostream> 
#include <sys/types.h> 
#include <sys/stat.h> 
#include "err1.h"
//mkdir создает каталог, который называется path. 0777(0-удалять может не только владелец, 777-владелец и все остальные имеют право на чтение, запись и выполнение) 
using namespace std;

void makedir(char *path){
	if(mkdir(path, 0777) == 0)
		cout << "Directory created\n";
	else 
		err1();
}

