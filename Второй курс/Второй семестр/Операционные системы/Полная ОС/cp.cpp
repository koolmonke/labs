#include <cstdlib>
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include "err1.h"
#include "cp.h"
using namespace std;
#define BS 1
char buf[BS];
void copyfile(char* path, char* nname)
{
	int i = 0, ffd, sfd;
	ssize_t count;
	ffd = open(path, O_RDONLY);
	if (ffd == -1)
		err1();
	sfd = open(nname, O_WRONLY | O_CREAT | O_EXCL, 0644);
	if (sfd == -1)
		err1();
	while (count = read(ffd, buf, BS) > 0)
	{
		write(sfd, buf, count);
		i++;
	}
	if (count == -1)
		err1();
	cout << "Copy succesfull\n";
	cout << "Bytes copyed:\n" << i;
	close(ffd);
	close(sfd);
}
