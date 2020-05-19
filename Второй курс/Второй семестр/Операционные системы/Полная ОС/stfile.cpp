//информация о файле
#include <cstdlib> 
#include <iostream> 
#include <sys/types.h> 
#include <sys/stat.h> 
#include <unistd.h> 
#include <stdio.h> 
#include <errno.h> 
#include <string.h> 
#include "stfile.h" 
#include "err1.h"
using namespace std;
//функция stat возвращает информацию об указанном файле.(stat возвращает информацию о файле path и заполняет буфер &sb.)
//sb указатель на структуру,(в ней содержатся поля).&-побитовое,и
void statfile(char *path){
	struct stat sb;//структура
	if(stat(path, &sb) == -1) 
		err1();
	else{
		printf("File type: ");
		switch (sb.st_mode & S_IFMT){ 
			case S_IFBLK:
				cout << "block device\n"; 
				break;
			case S_IFCHR: 
				cout << "character device\n";
				break;
			case S_IFDIR:
				cout << "directory\n";
				break;
			case S_IFIFO:
				cout << "FIFO/pipe \n"; 
				break;
			case S_IFLNK: 
				cout << "symlink\n";
				break;
			case S_IFREG: 
				cout << "regularfile\n"; 
				break;
			case S_IFSOCK:
				cout << "socket\n"; 
				break;
			default: 
				cout << "unknown?\n"; 
				break;
		}
		printf("i-node number: %ld\n", (long) sb.st_ino);

		printf("Mode: %lo(octal)\n", (unsigned long) sb.st_mode);
		if(sb.st_mode & S_IRUSR)
			cout << "owner has read permission\n";
		if(sb.st_mode & S_IWUSR) 
			cout << "owner has write permission\n";
		if(sb.st_mode & S_IXUSR & !S_IFDIR) 
			cout << "owner has execute permission\n";
		if(sb.st_mode & S_IRGRP) 
			cout << "group has read permission\n";
		if(sb.st_mode & S_IWGRP) 
			cout << "group has write permission\n";
		if(sb.st_mode & S_IXGRP & !S_IFDIR) 
			cout << "group has execute permission\n";
		if(sb.st_mode & S_IROTH) 
			cout << "others have read permission\n";
		if(sb.st_mode & S_IWOTH) 
			cout << "others have write permission\n";
		if(sb.st_mode & S_IXOTH & !S_IFDIR) 
			cout << "others have execute permission\n";
		printf("Link count: %ld\n", (long) sb.st_nlink);
		printf("Ownership: UID=%ld GID=%ld\n", (long) sb.st_uid, (long) sb.st_gid);
		printf("Preferred I/O block size: %ld bytes\n",(long) sb.st_blksize);
		printf("File size: %lld bytes\n",(long long) sb.st_size);
		printf("Blocks allocated: %lld\n",(long long) sb.st_blocks);
	}
}
