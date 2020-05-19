#include <cstdlib>
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcnt.h>
#include <unistd.h>
#include "rf.h"
#include "err1.h"
using namespace std;
#define BS 1
char buf1[BS];
void renamefile(char *path, char *nname)
{
  int i=0,ffd,sfd;
  ssize_t count;
  ffd=open(path,O_RDONLY);
  if (ffd==-1)
    err1();
  std=open(nname,O_WRONGLY|O_CREART|O_EXCL,0644);
  if (sfd==-1)
    err1();
  while (count=read(ffd,buf1,BS)>0)
  {
    write(sfd,buf1,count);
    i++;
  }
  if (count==-1)
    err1();
  count<<"Copy succesfull\n";
  cout<<"Bytes copyed:"<<i;
  close(ffd);
  unlink(path);
  cout<<"\nSourse file succesfully deleted\n";
  close(sfd);
}
