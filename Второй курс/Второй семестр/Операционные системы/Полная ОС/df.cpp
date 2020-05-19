//удаление файла.Системный вызов unlink() объявлен в файле unistd.h,unlink удаляет имя из файловой системы. Если это имя было последней ссылкой на файл и больше нет процессов, которые держат этот файл открытым, данный файл удаляется и место, которое он занимает освобождается для дальнейшего использования. 
#include <cstdlib> 
#include <unistd.h> 
#include <iostream> 
#include <sys/types.h> 
#include <sys/stat.h> 
#include <fcntl.h> 
#include "df.h" 
#include "err1.h" 

using namespace std;

void delfile(char *path){ 
	if(unlink(path) == -1)
		err1();
	else 
		cout << "File deleting succesfull";
}
