#include <cstdlib>
#include <unistd.h>
#include <iostream>
#include <sys/types.h>
#include <dirent.h>
#include <errno.h>
#include <string.h>
#include "err1.h"
#include "rd.h"
using namespace std;
void deldir(char *path)
{
  Dir *dir;
  int u;
  struct dirent *sdir;
  dir=opendir(path);
  if (dir==NULL) err1();
  chdir(path);
  while ((sdir=readdir(dir))!=NULL)
  {
    cout<<sdir->d_name<<"\n";
    u=unlink(sdir->d_name);
    if (u==-1 && errno==EISDIR)
    {
      if (strcmp(".",sdir->d_name)==0||strcmp("..",sdir->d_name)==0) continue;
      deldir(sdir->d_name);
    }
    if (u==-1 && errno==!EISDIR) err1();
  }
  closedir(dir);
  chdir("..");
  if (rmdir(path)==-1) err1();
} 
