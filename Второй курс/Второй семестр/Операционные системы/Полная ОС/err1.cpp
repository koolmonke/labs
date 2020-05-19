//обработчик ошибок
#include <iostream> 
#include <errno.h> 
#include <string.h> 
#include "err1.h" 

using namespace std;

void err1(){
	cout << "Error: " << strerror(errno) << "\n";
	return;
}


/*Она выводит сообщение с ошибкой, которое получает от функции strerror.
 * Данная функция по номеру ошибки возвращает строковое описание ошибки.
 * А номер ошибки она получает из функции errno, которая возвращает номер последней ошибки.*/